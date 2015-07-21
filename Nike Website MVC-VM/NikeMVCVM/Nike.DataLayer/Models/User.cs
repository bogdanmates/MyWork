using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nike.DataLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ScreenName { get; set; }
        public string Gender { get; set; }
        public int Zipcode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string emailAddress { get; set; }
        public string Password { get; set; }

        public User(string password, string emailAddress, DateTime dateOfBirth, int zipcode, string gender, string screenName, string lastName, string firstName)
        {
            Password = password;
            this.emailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
            Zipcode = zipcode;
            Gender = gender;
            ScreenName = screenName;
            LastName = lastName;
            FirstName = firstName;
        }

        public User(string password, string emailAddress, DateTime dateOfBirth, int zipcode, string gender, string screenName, string lastName, string firstName,int id)
        {
            Password = password;
            this.emailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
            Zipcode = zipcode;
            Gender = gender;
            ScreenName = screenName;
            LastName = lastName;
            FirstName = firstName;
            Id = id;
        }

        public User()
        {
            // TODO: Complete member initialization
        }
    }
}
