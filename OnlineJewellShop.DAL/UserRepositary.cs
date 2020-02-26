using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    
    public class UserRepositary
    {
        public  List<UserDetails> Lists()
        {
            DbConnect dbConnect = new DbConnect();
            return dbConnect.Data.ToList();
        }
        public void AddUser(UserDetails user)
        {
            DbConnect dbConnect = new DbConnect();
            dbConnect.Data.Add(user);
            dbConnect.SaveChanges();
        }


    }
}
