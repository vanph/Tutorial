using Practice.Problems.Lesson0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice.WinFroms.fromTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowEmployee_Click(object sender, EventArgs e)
        {

            var employeRepository = new EmployeRepository();

            var employees = employeRepository.GetEmployees(file);

            foreach (var emp in employees)
            {
                dataGridViewEmployee.Column[ColumnFirstName].;
            }
        }

        

    
    }
}
