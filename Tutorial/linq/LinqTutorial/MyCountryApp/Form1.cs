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
        //Field
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;

        public Form1()
        {
            InitializeComponent();
            _cityRepository = new CityRepository();
            _districtRepository = new DistrictRepository();
        }

        private void btnSearchCity_Click(object sender, EventArgs e)
        {
            var keyWord = txtCityFilter.Text;
            var cities = _cityRepository.GetAll().ToList();
            
            if (string.IsNullOrEmpty(keyWord))
            {
                grdCity.DataSource = cities;
            }
            else
            {
                keyWord = keyWord.ToLower();
                grdCity.DataSource = cities.Where(x=>x.Code.Contains(keyWord) || x.Name.ToLower().Contains(keyWord)).ToList();
                //grdCity.DataSource = cities.Where(x => x.Code.Contains(keyWord) || x.Name.ContainsByStringComparison(keyWord,StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            
        }

        private void btnSearchDistrict_Click(object sender, EventArgs e)
        {
            var districts = _districtRepository.GetAll();
            grdDistrict.DataSource = districts;
            
        }
    }
}
