using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineJewellShop.DAL
{
    //public class Connection
    //{
    //    public static SqlConnection getConnection()
    //    {
    //        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    //        SqlConnection sqlConnection = new SqlConnection(connectionString);
    //        return sqlConnection;
    //    }
    //}

   //Interface for UserRepositary
    public interface IUserRepositary
    {
        void AddUser(User user);
        User Login(User user);
        IEnumerable<User> DisplayUser();
        User GetUser(string userId);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
    public class UserRepositary:IUserRepositary
    {
        //public  List<User> Lists()
        //{
        //    using (DbConnect dbConnect = new DbConnect())
        //    {
        //        return dbConnect.Data.ToList();
        //    }
        //}
        // for SignUp of User 
        public void AddUser(User user)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                if (user.ConformPassword == user.Password)
                { 
                    dbConnect.Data.Add(user);
                    dbConnect.SaveChanges();
                }
            }
        }
        //for Login
        public User Login(User user)
        { 
            using (DbConnect dbConnect = new DbConnect())
            {
               
                User userDetails = dbConnect.Data.Where(x => x.MailId == user.MailId).Where(y => y.Password == user.Password).SingleOrDefault();
                //if (userDetails != null)
                //{
                //    return userDetails.Role;
                //}
                //List<UserDetails> loginList = dbConnect.Data.ToList();
                //foreach (var value in loginList)
                //{
                //    if (user.UserID == value.UserID && user.Password == value.Password)
                //    {
                //        return value.Role;
                //    }
                //}
                return userDetails;
            }
        }
        //Display the User for admin
        public IEnumerable<User> DisplayUser()
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                List<User> userDetails = dbConnect.Data.Where(x => x.Role == "User").ToList();

                return userDetails;
            }
        }
        //Getting user object with userid
        public User GetUser(string userId)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
               
                User User = dbConnect.Data.Where(id => id.UserID == userId).SingleOrDefault();
                return User;
            }
        }
        //Updating User with user object
        public void UpdateUser(User user)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                dbConnect.Entry(user).State = EntityState.Modified;
                dbConnect.SaveChanges();
            }
        }
        //Deleting User with user object
        public void DeleteUser(User user)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                User userDetails = dbConnect.Data.Where(id => id.UserID == user.UserID).SingleOrDefault();
                dbConnect.Data.Attach(userDetails);
                dbConnect.Data.Remove(userDetails);
                dbConnect.SaveChanges();
            }
        }

    }
}
