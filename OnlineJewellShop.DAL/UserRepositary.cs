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
        SqlConnection sqlConnection = Connection.getConnection();

        public int SignUp(UserDetails user)
        {
            try
            {
                string sql = "SP_SignUp";

                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    SqlParameter paramm = new SqlParameter();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    paramm.ParameterName = "@UserId";
                    paramm.Value = user.userID;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 18;
                    sqlCommand.Parameters.Add(paramm);

                    paramm = new SqlParameter();
                    paramm.ParameterName = "@password";
                    paramm.Value = user.password;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 18;
                    sqlCommand.Parameters.Add(paramm);

                    paramm = new SqlParameter();
                    paramm.ParameterName = "@MailId";
                    paramm.Value = user.mailId;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 20;
                    sqlCommand.Parameters.Add(paramm);

                    paramm = new SqlParameter();
                    paramm.ParameterName = "@PhoneNumber";
                    paramm.Value = user.phoneNumber;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 13;
                    sqlCommand.Parameters.Add(paramm);
                    paramm = new SqlParameter();
                    paramm.ParameterName = "@RoleOfMemeber";
                    paramm.Value = "User";
                    paramm.SqlDbType = SqlDbType.VarChar;
                    paramm.Size = 5;
                    sqlCommand.Parameters.Add(paramm);

                    sqlConnection.Open();
                    int row = sqlCommand.ExecuteNonQuery();
                    return row;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public string Login(UserDetails user)
        {

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SP_Select_AdminProcedure", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@UserId";
                    sqlParameter.Value = user.userID;
                    sqlParameter.SqlDbType = SqlDbType.VarChar;
                    sqlParameter.Size = 18;
                    sqlCommand.Parameters.Add(sqlParameter);

                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@password";
                    sqlParameter.Value = user.password;
                    sqlParameter.SqlDbType = SqlDbType.VarChar;
                    sqlParameter.Size = 18;
                    sqlCommand.Parameters.Add(sqlParameter);
                    //sqlParameter = new SqlParameter();
                    sqlCommand.Parameters.Add("@RoleOfMemeber", SqlDbType.VarChar, 5);
                    sqlCommand.Parameters["@RoleOfMemeber"].Direction = ParameterDirection.Output;
                    sqlConnection.Open();
                    sqlCommand.ExecuteReader();
                    if (Convert.ToString(sqlCommand.Parameters["@RoleOfMemeber"].Value) == "User")
                        return "User";
                    else if (Convert.ToString(sqlCommand.Parameters["@RoleOfMemeber"].Value) == "Admin")
                        return "Admin";
                    else
                        return "Login failed";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "sorry for the issue";
            }
            finally
            {
                sqlConnection.Close();
            }


        }
        public DataTable ViewDetails()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SP_VIEWCUSTOMER ", sqlConnection))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SP_VIEWCUSTOMER ", sqlConnection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception e)
            {
                DataTable dataTable = new DataTable();
                Console.WriteLine(e.Message);
                return dataTable;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void DeleteCustomerDetails(string user)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SP_DELETECUSTOMER ", sqlConnection))
                {
                    SqlParameter paramm = new SqlParameter();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    paramm.ParameterName = "@UserId";
                    paramm.Value = user;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 18;
                    sqlCommand.Parameters.Add(paramm);
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SP_DELETECUSTOMER", sqlConnection);
                    sqlDataAdapter.DeleteCommand = sqlCommand;
                    sqlCommand.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void UpdateCustomerDetails(string userID, string phoneNumber, string mailId, string role)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SP_Update", sqlConnection))
                {
                    SqlParameter paramm = new SqlParameter();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    paramm.ParameterName = "@UserId";
                    paramm.Value = userID;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 18;
                    sqlCommand.Parameters.Add(paramm);

                    paramm = new SqlParameter();
                    paramm.ParameterName = "@MailId";
                    paramm.Value = mailId;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 20;
                    sqlCommand.Parameters.Add(paramm);

                    paramm = new SqlParameter();
                    paramm.ParameterName = "@PhoneNumber";
                    paramm.Value = phoneNumber;
                    paramm.SqlDbType = SqlDbType.Char;
                    paramm.Size = 13;
                    sqlCommand.Parameters.Add(paramm);
                    paramm = new SqlParameter();
                    paramm.ParameterName = "@RoleOfMemeber";
                    paramm.Value = role;
                    paramm.SqlDbType = SqlDbType.VarChar;
                    paramm.Size = 5;
                    sqlCommand.Parameters.Add(paramm);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            finally
            {
                sqlConnection.Close();
            }

        }



    }
}
