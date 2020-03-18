using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineJewellShop.Entity;
using OnlineJewellShop.DAL;
namespace OnlineJewellShop.BL
{
    public interface IAccountBL
    {
         void SignUp(User user);
         User Login(User user);
    }
    public class AccountBL: IAccountBL
    {
        UserRepositary repositary = new UserRepositary();
        public void SignUp(User user)
        {
          repositary.AddUser(user);
        }
        public User Login(User user)
        {
            return repositary.Login(user);
        }
    }
}
