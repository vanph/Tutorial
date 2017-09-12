using System;
using System.Windows.Forms;
using MyCountryApplication.Modal;
using MyCountryApplication.ViewModel;
using System.Text;
using System.IO;
using CsvHelper;
using System.Collections.Generic;

namespace MyCountryApplication.View
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchDistricts()
        {
            var keyword = txtSearch.Text;
            var cityChoose = cbbCitySearch.SelectedItem as City;
            var cityCode = cityChoose != null ? cityChoose.CityCode : String.Empty;

            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInformations(keyword, cityCode);
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                cbbCitySearch.SelectedIndex = -1;
                SearchDistricts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GrvDistrict_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grvDistrict.SelectedRows.Count > 0)
                {
                    var selectedDistrict = grvDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;

                    if (selectedDistrict == null) return;

                    lblCityName.Text = selectedDistrict.CityName;
                    lblDistrictCode.Text = selectedDistrict.DistrictCode;
                    lblDistrictName.Text = selectedDistrict.DistrictName;
                }
            }
            catch (Exception ex)
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
                    MessageBox.Show(StringMessages.EditDistrictSuccess, StringMessages.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchDistricts();
                }

            }
            catch (Exception ex)
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
                    var selectedDistrictInfo = grvDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;

                    if (selectedDistrictInfo == null) return;

                    var districtEdit = _myCountryBusiness.GetDistrictByCode(selectedDistrictInfo.DistrictCode);
                    var frm = new DistrictDetailForm(districtEdit) {Text = StringMessages.EditDistrictTitle};

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(StringMessages.EditDistrictSuccess, StringMessages.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(@"Please select the row you want to edit", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
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
                    if (MessageBox.Show(StringMessages.DeleteDistrictConfirmMessage, @"Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var selectedDistrict = grvDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;

                        if (selectedDistrict == null) return;

                        //_myCountryBusiness.DeleteDistrict(_myCountryBusiness.GetDistrictByCode(selectedDistrict.DistrictCode));
                        _myCountryBusiness.DeleteDistrict(selectedDistrict.DistrictCode);
                        MessageBox.Show(StringMessages.DeleteDistrictSuccess, StringMessages.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SearchDistricts();
                    }
                }
                else
                {
                    MessageBox.Show(@"Please select the row you want to delete", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
       
            try
                
            {
                using (SaveFileDialog fSave = new SaveFileDialog (){ Filter = "CSV|*.csv", ValidateNames = true })
                {
                    
                    if (fSave.ShowDialog() == DialogResult.OK)
                    {
                        using (var sw = new StreamWriter(fSave.FileName))
                        {
                            var write = new CsvWriter(sw);

                            write.WriteHeader( typeof(DistrictViewModel));

                            foreach( DistrictViewModel dict in  grvDistrict.DataSource as List<DistrictViewModel>)
                            {
                                write.WriteRecord(dict);   
                            }
                        }
                        MessageBox.Show("OK");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
