using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Models.Pages;
using System;
using EPiServerSiteCMS.Models.UserManagement;

namespace EPiServerSiteCMS.Controllers
{
    public class RegisterController : PageController<Register>
    {
        public ActionResult Index()
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
                return View();
}


        [HttpPost]
        public ActionResult Register(string FirstName, string LastName, string ScreenName, DateTime DateOfBirth, string Email, string ZipCode, string password, string confirmPassword, string Gender)
        {
            Register registerVM = new Register();

            //if a field doesn't contain data
            //pressing Register button will
            //redirect to the same page
            //empty field check
            if (FirstName == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.FirstName = FirstName;
            //empty field check
            if (LastName == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.LastName = LastName;
            //empty field check
            //added
            if (ScreenName == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.ScreenName = ScreenName;
            //empty field check
            if ((DateOfBirth == null) || (DateOfBirth == Convert.ToDateTime("1/1/0001")))
            {
                return RedirectToAction("Index");
            }
            registerVM.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            //empty field check
            if (Email == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.Email = Email;

            //registerVM.ConfirmEmail = confirmEmail;
            //registerVM.CellPhone = CellPhone;

            //empty field check
            if (ZipCode == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.ZipCode = ZipCode;
            //empty field check
            if (password == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.Password = password;
            //empty field check
            if (confirmPassword == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.ConfirmPassword = confirmPassword;
            //empty field check
            //added
            if (Gender == "")
            {
                return RedirectToAction("Index");
            }
            registerVM.Gender = Gender;
            
            bool success = false;
            if (ModelState.IsValid)
            {
                //add user 
                success = UserManager.CreateUser(registerVM);
            }
            //check if adding the user succeeded
            if (success == true)
            {
                //registerVM.MessageToBeShown = "User successfully created";
                return RedirectToAction("Index", "StartPage");
            }
            else
            {
                //registerVM.MessageToBeShown = "Something wrong";
                return RedirectToAction("Index");
            }
        }
    }
}