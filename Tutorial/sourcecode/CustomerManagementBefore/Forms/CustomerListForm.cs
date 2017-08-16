using System;
using System.Linq;
using System.Windows.Forms;
using CustomerManagement.DataAccess;

namespace CustomerManagement.Forms
{
    public partial class CustomerListForm : Form
    {

        public CustomerListForm()
        {
            InitializeComponent();
            grdCustomer.AutoGenerateColumns = false;
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            var dbContext = new DataModel();

            var customers = dbContext.Customers.ToList();

            grdCustomer.DataSource = customers;
        }


        private void cmdFilterByColumn_Click(object sender, EventArgs e)
        {
            var dbContext = new DataModel();

            var customers = dbContext.Customers.Where( x => x.CompanyName.Contains(txtCompanyNameFilter.Text)).ToList();

            grdCustomer.DataSource = customers;
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
            //var dbContext = new DataModel();
            //int indexRowCurrent = grdCustomer.CurrentCell.RowIndex;
            //int indexColumnCurrent = grdCustomer.CurrentCell.ColumnIndex;
            
        }
        private void AddNewCustomer()
        {
            var CustomerDetailForm = new CustomerDetailForm();
            CustomerDetailForm.ShowDialog(); 

        }
        private void EditCurrentRow()
        {

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

        private void grdCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblCustomerIdentifier_Click(object sender, EventArgs e)
        {
           
        }

        private void lblCompanyName_Click(object sender, EventArgs e)
        {
           
        }
    }
}