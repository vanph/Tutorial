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
            lblCityName.Text = "";
            lblDistrictCode.Text = "";
            lblDistrictName.Text = "";
            _myCountryBusiness = new MyCountryBusiness();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCites();
            SearchDistricts();
        }

        public void LoadCites()
        {
            cbbCitySearch.DataSource = _myCountryBusiness.GetCities();
            cbbCitySearch.DisplayMember = nameof(City.Name);
            cbbCitySearch.SelectedIndex = -1;
        }

        
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchDistricts();
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchDistricts()
        {
            var keyword = txtSearch.Text;
            var cityChoose = cbbCitySearch.SelectedItem as City;
            var cityCode = cityChoose != null ? cityChoose.CityCode : String.Empty;

            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInfomations(keyword, cityCode);
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {                
                txtSearch.Text = "";
                cbbCitySearch.SelectedIndex = -1;
                SearchDistricts();
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
                var frm = new DistrictDetailForm()
                {
                    Text = StringMessages.AddDistrictTitle
                };

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(StringMessages.EditDistrictSuccess,StringMessages.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchDistricts();
                }

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
                    var selectedDistrictInfo = grvDistrict.SelectedRows[0].DataBoundItem as DistrictInformation;
                    if (selectedDistrictInfo != null)
                    {
                        var districtEdit = _myCountryBusiness.GetDistrictByCode(selectedDistrictInfo.DistrictCode);
                        var frm = new DistrictDetailForm(districtEdit);
                        frm.Text = StringMessages.EditDistrictTitle;
                        if(frm.ShowDialog()== DialogResult.OK)
                        {
                            MessageBox.Show(StringMessages.EditDistrictSuccess, StringMessages.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }       
                    
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
                    if (MessageBox.Show(StringMessages.DeleteDistrictConfirmMessage, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var selectRow = grvDistrict.SelectedRows[0].DataBoundItem as DistrictInformation;
                        _myCountryBusiness.DeleteDistrict(_myCountryBusiness.GetDistrictByCode(selectRow.DistrictCode));
                        MessageBox.Show(StringMessages.DeleteDistrictSuccess, StringMessages.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SearchDistricts();
                    }
             
                }
                else
                {
                    MessageBox.Show("Please select the row you want to delete", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                //Todo: implement export function
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
