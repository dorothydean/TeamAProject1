using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationFinal
{
    class CustomerDB
    {
        public static List<Customer> GetAllCustomers()
        {
            //step 1: Establish a db connection
            SqlConnection con = GetConnection();

            //step 2: Prepare query (command object)
            SqlCommand selQuery = new SqlCommand();
            selQuery.Connection = con;
            selQuery.CommandText =
                @"SELECT CustomerID
                        , DateOfBirth
                        , FirstName
                        , LastName
                        , Title
                  FROM Customer";

            //step 3: Open connection
            try
            {
                con.Open();

                //step 4: Execute query and get results
                SqlDataReader rdr =
                    selQuery.ExecuteReader();

                List<Customer> customerList =
                    new List<Customer>();
                //step 5: do something with results
                while (rdr.Read())
                {
                    Customer c = new Customer();
                    c.Title = (string)rdr["Title"];
                    c.DateOfBirth = (DateTime)rdr["DateOfBirth"];
                    c.FirstName = (string)rdr["FirstName"];
                    c.LastName = (string)rdr["LastName"];
                    customerList.Add(c);
                }
                return customerList;
            }
            finally
            {
                //step 6: close connection
                con.Close();
            }
        }

        //adds customer to database
        public static void AddCustomer(Customer cus)
        {
            SqlConnection con = GetConnection();

            SqlCommand addCustomer = new SqlCommand();
            addCustomer.Connection = con;
            addCustomer.CommandText =
                @"INSERT INTO Customer(DateOfBirth, FirstName, LastName, Title)
                  VALUES(@DOB, @FName, @LName, @Title)";
            addCustomer.Parameters.AddWithValue("@DOB", cus.DateOfBirth);
            addCustomer.Parameters.AddWithValue("@FName", cus.FirstName);
            addCustomer.Parameters.AddWithValue("@LName", cus.LastName);
            addCustomer.Parameters.AddWithValue("@Title", cus.Title);


            try
            {
                con.Open();
                int rowsAffected =
                    addCustomer.ExecuteNonQuery();

            }
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
