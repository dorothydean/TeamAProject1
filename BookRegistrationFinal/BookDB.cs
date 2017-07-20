using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationFinal
{
    static class BookDB
    {
        public static List<Book> GetAllBooks()
        {
            //step 1: Establish a db connection
            SqlConnection con = GetConnection();

            //step 2: Prepare query (command object)
            SqlCommand selQuery = new SqlCommand();
            selQuery.Connection = con;
            selQuery.CommandText =
                @"SELECT ISBN
                        , Price
                        , Title
                  FROM Book";

            //step 3: Open connection
            try
            {
                con.Open();

                //step 4: Execute query and get results
                SqlDataReader rdr =
                    selQuery.ExecuteReader();

                List<Book> bookList =
                    new List<Book>();
                //step 5: do something with results
                while (rdr.Read())
                {
                    Book  b = new Book();
                    b.ISBN = (string)rdr["ISBN"];
                    b.Price = (Decimal)rdr["Price"];
                    b.Title = (string)rdr["Title"];

                    bookList.Add(b);
                }
                return bookList;
            }
            finally
            {
                //step 6: close connection
                con.Close();
            }
        }

        //adds book to database
        public static void AddBook(Book book)
        {
            SqlConnection con = GetConnection();

            SqlCommand addBook = new SqlCommand();
            addBook.Connection = con;
            addBook.CommandText =
                @"INSERT INTO Book(ISBN, Price, Title)
                  VALUES(@ISBN, @Price, @Title)";
            addBook.Parameters.AddWithValue("@ISBN", book.ISBN);
            addBook.Parameters.AddWithValue("@Price", book.Price);
            addBook.Parameters.AddWithValue("@Title", book.Title);

            try
            {
                con.Open();
                int rowsAffected =
                    addBook.ExecuteNonQuery();

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
