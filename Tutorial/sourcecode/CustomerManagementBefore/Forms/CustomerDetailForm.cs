using CustomerManagement.DataAccess;
using System;
using System.Windows.Forms;
using CustomerManagement.MasterData;

namespace CustomerManagement.Forms
{
    public partial class CustomerDetailForm : Form
    {
        private object grdCustomer;

        public CustomerDetailForm()
        {
            InitializeComponent();

            foreach (var country in Countries.Names)
            {
                cboCountry.Items.Add(country);
            }

        }
       

        private void OnSave(object sender, EventArgs e)
        {
            var dbContext = new DataModel();
            var customer = new Customer();

            customer.CompanyName = txtCompanyName.Text;
            customer.ContactName = txtContactName.Text;
            customer.City = txtContactName.Text;
            customer.PostalCode = txtPostalCode.Text;
            customer.Country = cboCountry.GetItemText(this.cboCountry.SelectedItem);
            customer.CustomerID = txtCustomID.Text;
            dbContext.Customers.Add(customer);
          
            dbContext.SaveChanges();


            MessageBox.Show("inserted");
            
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTitles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textCustomID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
