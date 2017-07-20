using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistrationFinal
{
    public partial class frmRegisterBook : Form
    {
        private Registration regToBeAddedd;

        public frmRegisterBook(Registration reg = null)
        {
            regToBeAddedd = reg;
            InitializeComponent();
        }

        private void frmRegisterBook_Load(object sender, EventArgs e)
        {
            PopulateCustomerList();
            PopulateBookList();
        }

        private void PopulateCustomerList()
        {
            cboxCustomer.Items.Clear();

            try
            {
                List<Customer> customers =
                                CustomerDB.GetAllCustomers();

                foreach (Customer c in customers)
                {
                    cboxCustomer.Items.Add(c);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("We are having trouble loading data, try again later");
                Application.Exit();
            }
        }

        private void PopulateBookList()
        {
            cboxBook.Items.Clear();

            try
            {
                List<Book> books =
                                BookDB.GetAllBooks();

                foreach (Book b in books)
                {
                    cboxBook.Items.Add(b);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("We are having trouble loading data, try again later");
                Application.Exit();
            }
        }

        private void btnRegisterBook_Click(object sender, EventArgs e)
        {
            Registration addReg = new Registration()
            {
                CustomerID = Convert.ToString(((Customer)cboxCustomer.SelectedItem).Title)
                , ISBN = ((Book)cboxBook.SelectedItem).ISBN
                , RegDate = Convert.ToDateTime(dateTimePicker1.Value)
            };

            try
            {
                if (addReg != null)
                {
                    BookRegistrationDB.RegisterBook(addReg);
                    MessageBox.Show("Registration added!!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("We are having server issues, please try again later");
            }
        }

        
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var addCustForm = new frmAddCustomer();
            addCustForm.ShowDialog();
            PopulateCustomerList();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var addBookForm = new frmAddBook();
            addBookForm.ShowDialog();
            PopulateBookList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
