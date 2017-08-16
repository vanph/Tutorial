using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CustomerManagement.DataAccess;

namespace CustomerManagement.Forms
{
    public partial class CustomerListForm : Form
    {
        private readonly NorthWindEntities _dbContext;
        private readonly BindingSource _customerBindingSource = new BindingSource();

        public CustomerListForm()
        {
            InitializeComponent();
            grdCustomer.AutoGenerateColumns = false;
            grdCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdCustomer.MultiSelect = false;
            _dbContext = new NorthWindEntities();
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            var customers = _dbContext.Customers.ToList();

            // Bind to the BindingList
            _customerBindingSource.DataSource = customers;
            _customerBindingSource.Position = 0;

            customerBindingNavigator.BindingSource = _customerBindingSource;
            customerBindingNavigator.DeleteItem = null;
            customerBindingNavigator.AddNewItem = null;

            grdCustomer.DataSource = _customerBindingSource;

        }


        private void cmdFilterByColumn_Click(object sender, EventArgs e)
        {
        }


        private void cmdEditCurrentCustomer_Click(object sender, EventArgs e)
        {
            EditCurrentRow();
        }

        private void cmdAddNewCustomer_Click(object sender, EventArgs e)
        {
            AddNewCustomer();
        }
        private void RemoveCurrentRow()
        {           
            if (grdCustomer.SelectedRows.Count > 0)
            {

                //casting: reference type -> reference type
                var selectedCustomer = grdCustomer.SelectedRows[0].DataBoundItem as Customer;
                if (selectedCustomer == null)
                {
                    MessageBox.Show(@"Please select a customer");
                }
                else
                {
                    var customer = _dbContext.Customers.FirstOrDefault(x => x.CustomerID == selectedCustomer.CustomerID);
                    if (customer != null)
                    {
                        _dbContext.Customers.Remove(customer);
                        //delete orders linked to the customer
                        _dbContext.SaveChanges();

                        MessageBox.Show(@"Successfully removed the selected customer");
                    }
                    else
                    {
                        MessageBox.Show(@"Cannot found the selected customer");
                    }
                }

            }

        }
        private void AddNewCustomer()
        {
            var titles = GetContactTitles();
            var detailForm = new CustomerDetailForm();

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }

        }
        private void EditCurrentRow()
        {
            if (grdCustomer.SelectedRows.Count > 0)
            {
                var selectedCustomer = grdCustomer.SelectedRows[0].DataBoundItem as Customer;
                if (selectedCustomer != null)
                {
                    var titles = GetContactTitles();
                    var detailForm = new CustomerDetailForm(selectedCustomer, titles);

                    if (detailForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("OK");
                    }
                }
            }

         
        }
        private void cmdRemoveCurrentCustomer_Click(object sender, EventArgs e)
        {
            RemoveCurrentRow();
        }

        private void OnGridCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                RemoveCurrentRow();
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EditCurrentRow();
            }

        }

        private void OnBindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddNewCustomer();
        }

        private void OnBindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            RemoveCurrentRow();
        }

        private void OnGridCustomer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                EditCurrentRow();
            }
        }

        private void grdCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (grdCustomer.SelectedRows.Count > 0)
            {
                var selectedCustomer = grdCustomer.SelectedRows[0].DataBoundItem as Customer;
                if (selectedCustomer != null)
                {
                    lblCustomerIdentifier.Text = selectedCustomer.CustomerID;
                }
            }
           
        }

        public List<string> GetContactTitles()
        {
           return _dbContext.Customers.Select(cust => cust.ContactTitle).Distinct().ToList();
        }
    }
}