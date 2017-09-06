﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountryApplication;
using MyCountryApplication.Modal;

namespace MyCountryApplication
{
    public partial class MainForm : Form
    {
       private readonly MyCountryBusiness _myCountryBusiness;
        public MainForm()
        {
            InitializeComponent();
            grvDistrict.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// select all line
            grvDistrict.AutoGenerateColumns = false;// don't auto generate column 

            _myCountryBusiness = new MyCountryBusiness();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillNameCitiesToSearch();
            FillDataGrvDistrict();
        }

        public void FillNameCitiesToSearch()
        {
            cbbCitySearch.DataSource = _myCountryBusiness.GetCities();
            cbbCitySearch.DisplayMember = "Name";
            cbbCitySearch.SelectedIndex = -1;
        }

        public void FillDataGrvDistrict()
        {
            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInfomation();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text;
            var cityChoose = cbbCitySearch.SelectedItem as City;
            var cityCode = cityChoose != null ? cityChoose.CityCode : String.Empty;

            if(String.IsNullOrEmpty(keyword) && String.IsNullOrEmpty(cityCode))
            {
                FillDataGrvDistrict();
            }
            else

            grvDistrict.DataSource= _myCountryBusiness.GetDistrictInfomation(keyword, cityCode);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGrvDistrict();
        }

        private void grvDistrict_SelectionChanged(object sender, EventArgs e)
        {
            if(grvDistrict.SelectedRows.Count > 0)
            {
                var selectRow = grvDistrict.SelectedRows[0].DataBoundItem as DistrictInformation;
                lblCityName.Text = selectRow.CityName;
                lblDistrictCode.Text = selectRow.DistrictCode;
                lblDistrictName.Text = selectRow.DistrictName;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new DistrictDetailForm();
            frm.ShowDialog();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
        }

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    var frm = new DistrictDetailForm();
        //    frm.ShowDialog();

        //    if (grvDistrict.SelectedRows.Count > 0)
        //    {
        //        var selectRow = grvDistrict.SelectedRows[0].DataBoundItem as DistrictInformation;
                
        //    }
        //}
    }
}
