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

        private readonly MyCountryBusiness _myCountryBusiness;


        public MainForm()
        {

            InitializeComponent();
            grvDistrict.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // select all line
            grvDistrict.AutoGenerateColumns = false;
            _myCountryBusiness = new MyCountryBusiness();
          }
        



        private void FillDataCbbCity()
        {
            //var query = context.Cities.Select(x => x.Name);
            //var cities = query.ToList();

            cbbCity.DataSource = _myCountryBusiness.GetCities();
            cbbCity.DisplayMember = "Name";

        }

        private void FillDataGrvDistrict()
        {

            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInformations();


        }


        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGrvDistrict();
        }


        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGrvDistrict();
        }

        

            

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

