using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nike.Business.ViewModels
{
    public class RegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ScreenName { get; set; }
        public string Gender { get; set; }
        public int Zipcode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public RegisterVM(string firstName, string lastName, string screenName, int zipcode, string gender, DateTime dateOfBirth, string emailAddress, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            ScreenName = screenName;
            Zipcode = zipcode;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            this.EmailAddress = emailAddress;
            Password = password;
        }

        public RegisterVM()
        {
        }
    }
}
