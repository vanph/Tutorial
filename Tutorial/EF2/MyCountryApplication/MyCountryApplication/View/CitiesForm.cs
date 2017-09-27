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
        private readonly ICityBusiness _cityBusiness;
        public CitiesForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            _cityBusiness = new CityBusiness();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CitiesForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = _cityBusiness.GetCityInfomations();
        }

    }
}
