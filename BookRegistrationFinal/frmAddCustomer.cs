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
    public partial class frmAddCustomer : Form
    {
        private Customer custToBeAdded;
        public frmAddCustomer(Customer cust = null)
        {
            custToBeAdded = cust;

            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer addCust = new Customer()
            {
                Title = txtTitle.Text
                ,FirstName = txtFirstName.Text
                ,LastName = txtLastName.Text
                ,DateOfBirth = dateTimePickerCust.Value
            };

            try
            {
                if (custToBeAdded == null)
                {
                    CustomerDB.AddCustomer(addCust);
                    MessageBox.Show("Customer added!!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("We are having server issues, please try again later");
            }

            this.Close();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            if (custToBeAdded != null)
            {
                btnAddCustomer.Text = "Add Customer";
                this.Text = "Add Customer";
                txtTitle.Enabled = true;

                txtTitle.Text = Convert.ToString(custToBeAdded.Title);
                txtFirstName.Text = custToBeAdded.FirstName;
                txtLastName.Text = custToBeAdded.LastName;
                //dateTimePickerCust = custToBeAdded.DateOfBirth;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
