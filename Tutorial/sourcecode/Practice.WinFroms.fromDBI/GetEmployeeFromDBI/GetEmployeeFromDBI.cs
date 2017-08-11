using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Practice.WinFroms.fromDBI.Model;

namespace Practice.WinFroms.GetEmployeeFromDBI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowEmployee_Click(object sender, EventArgs e)
        {
            gridViewEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //gridViewEmployee.DataSource = GetAllEmployee().Tables[0];
            var context = new Model1();
            var query = context.EmployeeInfoes.Where(x => x.Name_Employee.Contains("A")).Select(x => new { Name = x.Name_Employee});
            var employees = query.ToList();

            gridViewEmployee.DataSource = employees;
        }

      

        DataSet GetAllEmployee()
        {
            DataSet data = new DataSet();

            string query = "select*from EmployeeInfo";
            using (SqlConnection connection = new SqlConnection(ConnectionEmployee.connectionEmployee))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        private void gridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
