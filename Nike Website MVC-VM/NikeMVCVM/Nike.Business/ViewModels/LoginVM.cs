using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nike.Business.ViewModels
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginVM(string emailAddress, string password)
        {
            this.EmailAddress = emailAddress;
            this.Password = password;
        }

        public LoginVM()
        {
        }
    }
}
