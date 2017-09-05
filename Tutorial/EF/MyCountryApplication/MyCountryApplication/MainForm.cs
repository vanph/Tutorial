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
    public partial class mainForm : Form
    {
        MyCountryEntities dbContext;


        public mainForm()
        {
            dbContext = new MyCountryEntities();
            InitializeComponent();
            FillDataCbbCity();
            FillDataGrvDistrict();

        }



        private void FillDataCbbCity()
        {
            //var query = context.Cities.Select(x => x.Name);
            //var cities = query.ToList();

            cbbCity.DataSource = dbContext.Cities.ToList();
            cbbCity.DisplayMember = "Name";

        }

        private void FillDataGrvDistrict()
        {
            grvDistrict.DataSource = (from districts in dbContext.Districts
                                      join cities in dbContext.Cities on districts.CityCode equals cities.CityCode
                                      select new { DistrictCode = districts.DistrictCode, Name = districts.Name, CityName = cities.Name }).ToList();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGrvDistrict();
        }

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


        }
    }


}

