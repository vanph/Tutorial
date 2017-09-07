using System;
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
            cbbCitySearch.DisplayMember = nameof(City.Name);
            cbbCitySearch.SelectedIndex = -1;
        }

        public void FillDataGrvDistrict()
        {
            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInfomation();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var keyword = txtSearch.Text;
                var cityChoose = cbbCitySearch.SelectedItem as City;
                var cityCode = cityChoose != null ? cityChoose.CityCode : String.Empty;

                if (String.IsNullOrEmpty(keyword) && String.IsNullOrEmpty(cityCode))
                {
                    FillDataGrvDistrict();
                }
                else
                {

                    grvDistrict.DataSource = _myCountryBusiness.GetDistrictInfomation(keyword, cityCode);
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGrvDistrict();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grvDistrict_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grvDistrict.SelectedRows.Count > 0)
                {
                    var selectRow = grvDistrict.SelectedRows[0].DataBoundItem as DistrictInformation;
                    lblCityName.Text = selectRow.CityName;
                    lblDistrictCode.Text = selectRow.DistrictCode;
                    lblDistrictName.Text = selectRow.DistrictName;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new DistrictDetailForm();
                frm.Text = "Add New Dictrict";
                frm.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDistrict.SelectedRows.Count > 0)
                {
                    var selectRow = grvDistrict.SelectedRows[0].DataBoundItem as DistrictInformation;
                    var districtEdit = _myCountryBusiness.GetDistrictByCode(selectRow.DistrictCode);
                    var frm = new DistrictDetailForm(districtEdit);
                    frm.Text = "Edit Dictrict";
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select the row you want to Edit!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDistrict.SelectedRows.Count > 0)
                {
                    var selectRow = grvDistrict.SelectedRows[0].DataBoundItem as DistrictInformation;
                    _myCountryBusiness.DeleteDistrict(_myCountryBusiness.GetDistrictByCode(selectRow.DistrictCode));
                }
                else
                {
                    MessageBox.Show("Please select the row you want to Delete", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
