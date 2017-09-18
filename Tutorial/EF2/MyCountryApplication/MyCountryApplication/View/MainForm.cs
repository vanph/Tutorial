using System;
using System.Windows.Forms;
using MyCountryApplication.ViewModel;
using System.IO;
using CsvHelper;
using MyCountry.DataAccess.Model;
using MyCountryApplication.Common;

namespace MyCountryApplication.View
{
    public partial class MainForm : Form
    {
        private readonly MyCountryBusiness _myCountryBusiness;
        private int _pageNumber = 1;
        private int _totalPage;
        public MainForm()
        {
            InitializeComponent();
            grvDistrict.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// select all line
            grvDistrict.AutoGenerateColumns = false;// don't auto generate column 
            lblCityName.Text = "";
            lblDistrictCode.Text = "";
            lblDistrictName.Text = "";
            lblTotalPage.Text = "1";
            _myCountryBusiness = new MyCountryBusiness();

           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCites();
            SearchDistricts();
            txtIndexPage.Text = Convert.ToString(_pageNumber);
            pannelSearch.Visible = false;
            panelExport.Visible = false;
            grvDistrict.Visible = false;
            panelTool.Visible = false;
            panelInfo.Visible = false;

            
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
                _pageNumber = 1;
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
            var cityCode = cityChoose != null ? cityChoose.CityCode : string.Empty;

            int _totalCount;
            grvDistrict.DataSource = _myCountryBusiness.GetDistrictInformations(out _totalCount, keyword, cityCode, _pageNumber, Constants.PageSize);
            _totalPage = (_totalCount % Constants.PageSize == 0) ? _totalCount / Constants.PageSize : _totalCount / Constants.PageSize + 1;
            txtIndexPage.Text = _pageNumber.ToString();
            lblTotalPage.Text = _totalPage.ToString();
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
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;

                    var selectedDistrict = grvDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;

                    if (selectedDistrict == null) return;

                    lblCityName.Text = selectedDistrict.CityName;
                    lblDistrictCode.Text = selectedDistrict.DistrictCode;
                    lblDistrictName.Text = selectedDistrict.DistrictName;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;

                    lblCityName.Text = "";
                    lblDistrictCode.Text = "";
                    lblDistrictName.Text = "";
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
                    var frm = new DistrictDetailForm(districtEdit) { Text = StringMessages.EditDistrictTitle };

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
                using (SaveFileDialog fSave = new SaveFileDialog() { Filter = @"CSV|*.csv", ValidateNames = true })
                {

                    if (fSave.ShowDialog() == DialogResult.OK)
                    {
                        using (var sw = new StreamWriter(fSave.FileName))
                        {
                            var write = new CsvWriter(sw);

                            write.WriteHeader(typeof(DistrictViewModel));

                            var keyword = txtSearch.Text;
                            var cityChoose = cbbCitySearch.SelectedItem as City;
                            var cityCode = cityChoose != null ? cityChoose.CityCode : string.Empty;
                            var totalCount = 0;

                            //no pagination when exporting
                            var districts = _myCountryBusiness.GetDistrictInformations(out totalCount, keyword, cityCode, 1, int.MaxValue);

                            foreach (var dict in districts)
                            {
                                write.WriteRecord(dict);
                            }
                        }

                        MessageBox.Show(StringMessages.ExportSuccess);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_pageNumber - 1 > 0)
            {
                btnNext.Enabled = true;
                _pageNumber = _pageNumber - 1;
                SearchDistricts();
                btnPrev.Focus();
            }
            else
            {
                btnPrev.Enabled = false;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_pageNumber <= _totalPage)
            {
                btnPrev.Enabled = true;
                _pageNumber = _pageNumber + 1;
                SearchDistricts();
                btnNext.Focus();
            }
            else
            {
                btnNext.Enabled = false;
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new LoginForm()
                {
                    Text = StringMessages.LoginTitle
                };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Constants.IsLoggedIn = true;
                    if (Constants.IsLoggedIn)
                    {
                        lblNoticeLogin.Text = StringMessages.NameUser("luong tran");
                        lblNoticeLogin.Visible = true;
                        pannelSearch.Visible = true;
                        panelExport.Visible = true;
                        grvDistrict.Visible = true;
                        panelTool.Visible = true;
                        panelInfo.Visible = true;
                    }
                };


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DistrictToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new MainForm()
                {
                    Text = StringMessages.DistrictTitle
                };
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new AboutForm()
                {
                    Text = StringMessages.AboutTitle
                };

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtIndexPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;

            }

            if (e.KeyChar == (char)13 && !string.IsNullOrEmpty(txtIndexPage.Text))
            {
                _pageNumber = int.Parse(txtIndexPage.Text);

                if (_pageNumber < 1 || _pageNumber > _totalPage)
                {
                    MessageBox.Show(StringMessages.ValidatePageNumber(1,_totalPage));
                }
                else
                {
                    SearchDistricts();
                }
            }
        }

        private void CityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new CitiesForm();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Text = StringMessages.CitiesFormTilte;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }
    }
}
