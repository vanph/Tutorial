using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CustomerManagement.DataAccess;
using CustomerManagement.MasterData;

namespace CustomerManagement.Forms
{
    public partial class CustomerDetailForm : Form
    {
        public Customer Customer { get; set; }
        public bool Adding { get; set; }
        public CustomerDetailForm()
        {
            InitializeComponent();
            Adding = true;
        }
        public CustomerDetailForm(Customer customer, List<string> contactTitles)
        {
            InitializeComponent();
            
            Customer = customer;
            cboTitles.DataSource = contactTitles;
            cboCountry.DataSource = Countries.Names;

            if (string.IsNullOrWhiteSpace( customer.CompanyName))
            {
                cboTitles.SelectedIndex = -1;
                cboCountry.SelectedIndex = -1;
                Adding = true;
                Text = "Adding";
            }
            else
            {

                Adding = false;

                Text = "Editing";

                txtCompanyName.Text = Customer.CompanyName;
                txtContactName.Text = Customer.ContactName;
                txtAddress.Text = Customer.Address;
                txtCity.Text = Customer.City;
                txtPostalCode.Text = Customer.PostalCode;

                int index = cboTitles.FindString(Customer.ContactTitle);
                if (index != -1)
                {
                    cboTitles.SelectedIndex = index;
                }

                index = cboCountry.FindStringExact(Customer.Country);
                if (index != -1)
                {
                    cboCountry.SelectedIndex = index;
                }
            }
        }

        //[Localizable(false)]
        //public sealed override string Text
        //{
        //    get { return base.Text; }
        //    set { base.Text = value; }
        //}

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Adding)
            {
                Customer = new Customer
                {
                    CompanyName = txtCompanyName.Text,
                    ContactName = txtContactName.Text,
                    ContactTitle = cboTitles.Text,
                    Address = txtAddress.Text,
                    Country = cboCountry.Text,
                    City = txtCity.Text,
                    PostalCode = txtPostalCode.Text
                };

                DialogResult = DialogResult.OK;
                
            }
            else
            {
                Customer.CompanyName = txtCompanyName.Text;
                Customer.ContactName = txtContactName.Text;
                Customer.ContactTitle = cboTitles.Text;
                Customer.Address = txtAddress.Text;
                Customer.Country = cboCountry.Text;
                Customer.City = txtCity.Text;
                Customer.PostalCode = txtPostalCode.Text;

                DialogResult = DialogResult.OK;
            }

            
        }
    }
}
