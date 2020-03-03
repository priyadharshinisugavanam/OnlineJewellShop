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
    public class Connection
    {
        public static SqlConnection getConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }

    public class DbConnect : DbContext
    {
        public DbSet<UserDetails> Data { get; set; }
        public DbConnect() : base("DBConnection")
        {

        }

    }
    public class UserRepositary
    {
        public  List<UserDetails> Lists()
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                return dbConnect.Data.ToList();
            }
        }
        public void AddUser(UserDetails user)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                dbConnect.Data.Add(user);
                dbConnect.SaveChanges();
            }
        }
        public string Login(UserDetails user)
        { 
            using (DbConnect dbConnect = new DbConnect())
            {
                List<UserDetails> loginList = dbConnect.Data.ToList();
                foreach (var value in loginList)
                {
                    if (user.UserID == value.UserID && user.Password == value.Password)
                    {
                        return value.Role;
                    }
                }
                return "not";
            }
        }


    }
}
