using Nike.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nike.DataLayer.Mappers
{
    public class UserMapper
    {
        #region Public Members
        public void addUser(Nike_User u)
        {
            using (var db = new NikeDBEntities())
            {
                db.Nike_User.Add(u);
                db.SaveChanges();
            }
        }


        public Boolean checkUserExists(Nike_User u)
        {
            List<Nike_User> userList;
            using (var db = new NikeDBEntities())
            {
                userList = db.Nike_User.ToList();
                foreach (var item in userList)
                {
                    if (item.emailAddress == u.emailAddress)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<Nike_User> GetAllUsers()
        {
            List<Nike_User> userList;
            using (var db = new NikeDBEntities())
            {
                userList = db.Nike_User.ToList();
                return userList;
            }
        }
        #endregion
    }
}
