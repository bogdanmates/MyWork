using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using System.Web.Security;
using Mediachase.BusinessFoundation.Data;
using System.Configuration;
using System.Web.ModelBinding;
using Mediachase.Commerce.Security;
using Mediachase.Commerce.Core;
using Mediachase.Commerce.Customers;
using EPiServerSiteCMS.Models.Pages;
using EPiServerSiteCMS.Models.ViewModels;


namespace EPiServerSiteCMS.Models.UserManagement
{
    public static class UserManager
    {
        private static bool RoleExists(string roleName)
        {
            if (DataContext.Current == null)
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["EcfSqlConnection"].ConnectionString;
                Mediachase.BusinessFoundation.Data.DataContext.Current = new Mediachase.BusinessFoundation.Data.DataContext(connectionstring);
            }

            try
            {
                // If we got a SecurityContext
                if (SecurityContext.Current != null)
                {
                    if (SecurityContext.Current.GetAllRegisteredRoles().Any())
                        return SecurityContext.Current.GetAllRegisteredRoles().FirstOrDefault(x => x.RoleName == roleName) != null;
                }

                // ... and if we dont
                if (SecurityContext.Current == null)
                {
                    string ProviderName = "CustomerSecurityProvider";
                    SecurityContext securityContext = SecurityContext.CreateInstance(ProviderName);

                    if (securityContext != null && securityContext.GetAllRegisteredRoles().Any())
                        return securityContext.GetAllRegisteredRoles().FirstOrDefault(x => x.RoleName == roleName) != null;
                }

            }
            catch { }

            return false;

        }

        //to be removed
        //private static bool EmailMatch(string email, string confirmEmail)
        //{
        //    return email.Equals(confirmEmail);
        //}

        //check password match
        //returns boolean
        private static bool PasswordMatch(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword);
        }

        //check if user exists 
        //returns boolean
        public static bool ExistsUser(Login loginVM)
        {
            //search for the user
            string userName = Membership.GetUserNameByEmail(loginVM.Email);
            //if not found
            if (userName == null)
            {
                return false;
            }
            //if found
            //retrieves the user
            MembershipUser user = Membership.GetUser(userName);
            //check password match
            if (!user.GetPassword().Equals(loginVM.Password))
            {
                return false;
            }

            return true;

        }

        private static bool isNumber(string toBeVerified)
        {
            for (int i = 0; i < toBeVerified.Length; i++)
            {
                if (toBeVerified[i] < '0' || toBeVerified[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private static int GetMaxCode()
        {
            int maxCode = 0;
            MembershipUserCollection membershipUserCollection = Membership.GetAllUsers();
            foreach (MembershipUser membershipUser in membershipUserCollection)
            {
                if (isNumber(membershipUser.UserName) && Convert.ToInt32(membershipUser.UserName) > maxCode)
                {
                    maxCode = Convert.ToInt32(membershipUser.UserName);
                }
            }
            return maxCode;
        }


        //create a user
        public static bool CreateUser(Register registerVM)
        {
            //removed
            //if (!EmailMatch(registerVM.Email, registerVM.ConfirmEmail))
            //{
            //    return false;
            //}
            //if ((registerVM.FirstName == null) || (registerVM.LastName == null) || (registerVM.ScreenName == null) || (registerVM.DateOfBirth == null) || (registerVM.Email == null) || (registerVM.ZipCode == null) ||
            //    (registerVM.Password == null) || (registerVM.ConfirmPassword == null) || (registerVM.Gender == null) )
            //{
            //    return false;
            //}

            //check password match
            if (!PasswordMatch(registerVM.Password, registerVM.ConfirmPassword))
            {
                return false;
            }
            //verify if user already exists
            string userName = Membership.GetUserNameByEmail(registerVM.Email);
            //if user already exists
            if (userName != null)
            {
                return false;
            }
            //if user doesn't already exist
            if (userName == null)
            {
                MembershipUser user = Membership.CreateUser((GetMaxCode() + 1).ToString(), registerVM.Password, registerVM.Email);
                user.IsApproved = true;
                Membership.UpdateUser(user);
                try
                {
                    if (RoleExists(AppRoles.EveryoneRole))
                    {
                        SecurityContext.Current.AssignUserToGlobalRole(user, AppRoles.EveryoneRole);
                    }
                    if (RoleExists(AppRoles.RegisteredRole))
                    {
                        SecurityContext.Current.AssignUserToGlobalRole(user, AppRoles.RegisteredRole);
                    }
                    
                    //add a contact
                    CustomerContact contact = CustomerContact.CreateInstance(user);
                    if (contact != null)
                    {
                        contact.UserId = registerVM.Email;
                        contact.FirstName = registerVM.FirstName;
                        contact.LastName = registerVM.LastName;
                        contact.Password = registerVM.Password;
                        contact.BirthDate = registerVM.DateOfBirth;
                        contact.Code = registerVM.Email;
                        contact.Email = registerVM.Email;
                        // 
                        AddressViewModel billingAddress = new AddressViewModel();
                        AddressViewModel shippingAddress = new AddressViewModel();
                        //
                        //billing address
                        CustomerAddress custommerBillingAddress = 
                            CustomerAddress.CreateForApplication(AppContext.Current.ApplicationId);
                        contact.AddContactAddress(custommerBillingAddress);

                        //shipping address
                        CustomerAddress customShippingAddress =
                            CustomerAddress.CreateForApplication(AppContext.Current.ApplicationId);
                        contact.AddContactAddress(customShippingAddress);

                        
                        contact.SaveChanges();
                    }
                    return true;
                }
                catch { }
            }
            return false;
        }
    }
}