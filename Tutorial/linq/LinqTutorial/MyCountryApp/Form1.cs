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
using MyCountry.Model;

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
            //Multicast delegate
            btnClickMe.Click += OnClickMe2_Click;            
        }

        private void btnSearchCity_Click(object sender, EventArgs e)
        {
            var keyWord = txtCityFilter.Text;
            //var cities = _cityRepository.GetAll().ToList();

            //if (string.IsNullOrEmpty(keyWord))
            //{
            //    grdCity.DataSource = cities;
            //}
            //else
            //{
            //    keyWord = keyWord.ToLower();
            //    grdCity.DataSource = cities.Where(x => x.Code.Contains(keyWord) || x.Name.ToLower().Contains(keyWord)).ToList();
            //    //grdCity.DataSource = cities.Where(x => x.Code.Contains(keyWord) || x.Name.ContainsByStringComparison(keyWord,StringComparison.InvariantCultureIgnoreCase)).ToList();
            //}
            

            if (string.IsNullOrEmpty(keyWord))
            {
                grdCity.DataSource = _cityRepository.GetPagedData(null,10,1).ToList();
            }
            else
            {
                keyWord = keyWord.ToLower();
                grdCity.DataSource = _cityRepository.GetPagedData(x => x.Code.Contains(keyWord) || x.Name.ToLower().Contains(keyWord), 10,1).ToList();
                //grdCity.DataSource = cities.Where(x => x.Code.Contains(keyWord) || x.Name.ContainsByStringComparison(keyWord,StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

        }

        private void btnSearchDistrict_Click(object sender, EventArgs e)
        {
            var districts = _districtRepository.GetAll();
            grdDistrict.DataSource = districts;

        }

        private void OnButtonSearchSumaryClicked(object sender, EventArgs e)
        {
            //GetSummary1();
            GetSummary2();
        }

        private void GetSummary1()
        {
            var districts = _districtRepository.GetAll();
            var cities = _cityRepository.GetAll();

            var result = from district in districts
                         join city in cities on district.CityCode equals city.Code
                         select new { DistrictCode = district.Code, DistrictName = district.Name, CityName = city.Name };

            var keyWord = txtSummaryFilter.Text;

            if (string.IsNullOrEmpty(keyWord))
            {
                grdSummary.DataSource = result.ToList();
            }
            else
            {
                grdSummary.DataSource = result.Where(x => x.DistrictCode.Contains(keyWord)).ToList();
            }
        }

        private void GetSummary2()
        {
            var districts = _districtRepository.GetAll();
            var cities = _cityRepository.GetAll();

            var keyWord = txtSummaryFilter.Text;

            if (string.IsNullOrEmpty(keyWord))
            {
                grdSummary.DataSource = (from district in districts
                                         join city in cities on district.CityCode equals city.Code
                                         select new { DistrictCode = district.Code, DistrictName = district.Name, CityName = city.Name }).ToList();
            }
            else
            {
                //grdSummary.DataSource = (from district in districts.Where(x=>x.Code.Contains(keyWord))
                //                         join city in cities on district.CityCode equals city.Code
                //                         select new { DistrictCode = district.Code, DistrictName = district.Name, CityName = city.Name }).ToList();
                grdSummary.DataSource = (from district in districts
                                         join city in cities on district.CityCode equals city.Code
                                         where district.Code.Contains(keyWord)
                                         select new { DistrictCode = district.Code, DistrictName = district.Name, CityName = city.Name }).ToList();
            }
        }

        private void OnClickMe_Click(object sender, EventArgs e)
        {
            //Register: btnClickMe, button2
            var btn = sender as Button;
            if(btn != null)
            {
                btn.Text = "You clicked me.";
            }
        }

        private void OnClickMe2_Click(object sender, EventArgs e)
        {
            //Register: btnClickMe
            MessageBox.Show("You just clicked!");
            
        }


    }
}
