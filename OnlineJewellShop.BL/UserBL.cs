using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.BL
{
    public interface IUserBL
    {
        User GetUser(string id);
        IEnumerable<User> DisplayUser();
        void UpdateUser(User users);
        void DeleteUser(User users);
    }
    public class UserBL:IUserBL
    {
        IUserRepositary user;
        public UserBL()
        {
            user = new UserRepositary();
        }
       
        public User GetUser(string id)
        {
            return user.GetUser(id);
        }

        public IEnumerable<User> DisplayUser()
        {
            return user.DisplayUser();
        }
        public void UpdateUser(User users)
        {
            user.UpdateUser(users);
        }
        public void DeleteUser(User users)
        {
            user.DeleteUser(users);
        }

    }
}

