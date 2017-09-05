using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountryApplication.Model;

namespace MyCountryApplication
{
    public partial class MainForm : Form
    {
<<<<<<< HEAD
        private readonly MyCountryBusiness _myCountryBusiness;


        public MainForm()
        {

            InitializeComponent();
            grvDistrict.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // select all line
            grvDistrict.AutoGenerateColumns = false;
            _myCountryBusiness = new MyCountryBusiness();
=======
        MyCountryEntities dbContext;


        public mainForm()
        {
            dbContext = new MyCountryEntities();
            InitializeComponent();
            FillDataCbbCity();
            FillDataGrvDistrict();

>>>>>>> b30ac85a0718306b1c07b928ef0f67ea4eb0930d
        }



        private void FillDataCbbCity()
        {
            //var query = context.Cities.Select(x => x.Name);
            //var cities = query.ToList();

<<<<<<< HEAD
            cbbCity.DataSource = _myCountryBusiness.GetCities();
=======
            cbbCity.DataSource = dbContext.Cities.ToList();
>>>>>>> b30ac85a0718306b1c07b928ef0f67ea4eb0930d
            cbbCity.DisplayMember = "Name";

        }

        private void FillDataGrvDistrict()
        {
<<<<<<< HEAD
            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInformations();

=======
            grvDistrict.DataSource = (from districts in dbContext.Districts
                                      join cities in dbContext.Cities on districts.CityCode equals cities.CityCode
                                      select new { DistrictCode = districts.DistrictCode, Name = districts.Name, CityName = cities.Name }).ToList();
        }
>>>>>>> b30ac85a0718306b1c07b928ef0f67ea4eb0930d

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGrvDistrict();
        }

<<<<<<< HEAD
        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGrvDistrict();
        }
=======
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtKeyword.Text.ToLower();
            var cityChoose = cbbCity.GetItemText(cbbCity.SelectedItem);

            if (keyword == null && cityChoose == null)
            {
                FillDataGrvDistrict();
            }

            else if (keyword == null && cityChoose != null)
            {
                grvDistrict.DataSource = (from districts in dbContext.Districts
                                          join cities in dbContext.Cities on districts.CityCode equals cities.CityCode
                                          where cities.Name == cityChoose
                                          select new { DistrictCode = districts.DistrictCode, Name = districts.Name, CityName = cities.Name }).ToList();
            }

            else if (keyword != null && cityChoose == null)
            {
                grvDistrict.DataSource = (from districts in dbContext.Districts
                                          join cities in dbContext.Cities on districts.CityCode equals cities.CityCode
                                          where (districts.Name.ToLower().Contains(keyword) || districts.DistrictCode.ToLower().Contains(keyword))
                                          select new { DistrictCode = districts.DistrictCode, Name = districts.Name, CityName = cities.Name }).ToList();
            }

            else
            {
                grvDistrict.DataSource = (from districts in dbContext.Districts
                                          join cities in dbContext.Cities on districts.CityCode equals cities.CityCode
                                          where (districts.Name.ToLower().Contains(keyword) || districts.DistrictCode.ToLower().Contains(keyword))
                                                && cities.Name == cityChoose
                                          select new { DistrictCode = districts.DistrictCode, Name = districts.Name, CityName = cities.Name }).ToList();
            }

>>>>>>> b30ac85a0718306b1c07b928ef0f67ea4eb0930d

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtKeyword.Text;
            var cityChoose = cbbCity.SelectedItem as City;
            var cityCode = cityChoose != null ? cityChoose.CityCode : string.Empty;
            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInformations(keyword, cityCode);
        }



        private void GrvDistrict_SelectionChanged(object sender, EventArgs e)
        {
            if (grvDistrict.SelectedRows.Count > 0)
            {
                //var selectDistrict = grvDistrict.SelectedRows[0].DataBoundItem as District;
                //var selectCity = grvDistrict.SelectedRows[0].DataBoundItem as City;

                //lblCityName.Text = selectCity.Name;
                //lblDistrictCode.Text = selectDistrict.DistrictCode;
                //lblDistrictName.Text = selectDistrict.Name;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillDataCbbCity();
            FillDataGrvDistrict();
        }
    }


}

