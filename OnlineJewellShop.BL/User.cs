using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineJewellShop.Entity;
using OnlineJewellShop.DAL;
namespace OnlineJewellShop.BL
{
    public class User
    {
        UserRepositary repositary = new UserRepositary();
        public void SignUp(UserDetails user)
        {
          repositary.AddUser(user);
        }
    }
}
