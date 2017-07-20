using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationFinal
{
    class BookRegistrationDB
    {
        //registers to customer book in database
        //DO we need to register each book to one customer or can multiple books be registered to multiple people??
        public static void RegisterBook(Registration reg)
        {
            SqlConnection con = GetConnection();

            SqlCommand addReg = new SqlCommand();
            addReg.Connection = con;
            addReg.CommandText =
                @"insert into Registration(CustomerID, ISBN, RegDate)
                    VALUES(@CID, @ISBN, @Date)";
            addReg.Parameters.AddWithValue("@CID", reg.CustomerID);
            addReg.Parameters.AddWithValue("@ISBN", reg.ISBN);
            addReg.Parameters.AddWithValue("@Date", reg.RegDate);
           
            try
            {
                con.Open();
                int rowsAffected =
                    addReg.ExecuteNonQuery();
            }
            //finally
            //{
            //    con.Dispose();
            //}

            //try
            //{
            //    con.Open();
            //    int rowsAffected =
            //        updateCmd.ExecuteNonQuery();
                
            //}
            catch (SqlException ex)
            {
                //log exception information
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost;Initial Catalog=BookRegistration;Integrated Security=True");
        }
    }
}
