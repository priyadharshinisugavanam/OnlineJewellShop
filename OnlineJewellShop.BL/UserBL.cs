using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System.Collections.Generic;
namespace OnlineJewellShop.BL
{
    public interface IUserBL
    {
        User GetUser(string id);
        User GetMail(string id);
        IEnumerable<User> DisplayUser();
        int UpdateUser(User users);
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
        public User GetMail(string id)
        {
            return user.GetMail(id);
        }

        public IEnumerable<User> DisplayUser()
        {
            return user.DisplayUser();
        }
        public int UpdateUser(User users)
        {
            return user.UpdateUser(users);
        }
        public void DeleteUser(User users)
        {
            user.DeleteUser(users);
        }

    }
}

