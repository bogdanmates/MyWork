using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nike.Business.ViewModels;
using Nike.DataLayer.Mappers;
using Nike.DataLayer.Models;
using Nike.DataLayer;

namespace Nike.Business.BusinessLogic
{
    public static class UserBL
    {

        #region Public Members
        public static Boolean CheckLoginCredentials(LoginVM userVm)
        {
            UserMapper userMapper = new UserMapper();
            List<Nike_User> parsedList = userMapper.GetAllUsers();

            foreach (var item in parsedList)
            {
                if ((item.emailAddress == userVm.EmailAddress) && (item.Password == userVm.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public static void AddUser(RegisterVM registerVm)
        {
            UserMapper userMapper = new UserMapper();
            Nike_User newUser = new Nike_User(registerVm.FirstName, registerVm.LastName, registerVm.ScreenName, registerVm.Gender,
                registerVm.Zipcode, registerVm.EmailAddress, registerVm.DateOfBirth, registerVm.Password);

            userMapper.addUser(newUser);
        }


        public static Boolean registerUser(RegisterVM registerVm)
        {
            UserMapper userMapper = new UserMapper();
            Nike_User newUser = new Nike_User(registerVm.FirstName, registerVm.LastName, registerVm.ScreenName, registerVm.Gender,
                registerVm.Zipcode, registerVm.EmailAddress, registerVm.DateOfBirth, registerVm.Password);

            Boolean succes = userMapper.checkUserExists(newUser);
            if (!succes)
            {
                userMapper.addUser(newUser);
                return true;
            }
            return false;
        }



        public static List<Nike_User> displayUserList()
        {
            var um = new UserMapper();
            var users = um.GetAllUsers();
            return users;
        }
        #endregion
    }
}
