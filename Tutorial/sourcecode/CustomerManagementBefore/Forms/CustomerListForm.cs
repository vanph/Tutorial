using System;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class CustomerListForm : Form
    {

        public CustomerListForm()
        {
            InitializeComponent();
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            
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

        }
        private void AddNewCustomer()
        {


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
    }
}