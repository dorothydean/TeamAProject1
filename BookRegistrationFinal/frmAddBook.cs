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
    public partial class frmAddBook : Form
    {
        private Book bookToBeAdded;
        public frmAddBook(Book book = null)
        {
            //bookToBeAdded = new Book();

            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Book addBook = new Book()
            {
                ISBN = txtISBN.Text
                ,Title = txtTitle.Text
                ,Price = Convert.ToDecimal(txtPrice.Text)
                
            };

            try
            {
                if (bookToBeAdded == null)
                {
                    BookDB.AddBook(addBook);
                    MessageBox.Show("Book added!!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("We are having server issues, please try again later");
            }

            this.Close();
        }

        private void frmAddBook_Load(object sender, EventArgs e)
        {
            if (bookToBeAdded != null)
            {
                btnAddBook.Text = "Update Book";
                this.Text = "Update Book";
                txtISBN.Enabled = true;

                txtISBN.Text = bookToBeAdded.ISBN;
                txtTitle.Text = bookToBeAdded.Title;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
