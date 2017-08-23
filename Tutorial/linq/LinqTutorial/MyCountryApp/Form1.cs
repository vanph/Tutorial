using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountry.Repository;

namespace MyCountryApp
{
    public partial class Form1 : Form
    {
        private CityRepository _cityRepository;
        public Form1()
        {
            InitializeComponent();
            _cityRepository = new CityRepository();
        }

        private void btnSearchCity_Click(object sender, EventArgs e)
        {
            var cities = _cityRepository.GetCities();
            grdCity.DataSource = cities;
        }

        
    }
}
