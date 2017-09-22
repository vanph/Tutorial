using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountry.DataAccess.Persistence;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.View
{
    public partial class CitiesForm : Form
    {
        public CitiesForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CitiesForm_Load(object sender, EventArgs e)
        {
            
            var myCountryBusiness = new MyCountryBusiness();

            dataGridView1.DataSource = myCountryBusiness.GetCityInfomations();
        }




    }
    }
