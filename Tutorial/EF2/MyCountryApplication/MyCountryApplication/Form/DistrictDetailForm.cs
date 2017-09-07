using System;
using System.Windows.Forms;
using MyCountryApplication.Modal;

namespace MyCountryApplication
{
    public partial class DistrictDetailForm : Form
    {        
        private readonly MyCountryBusiness _myCountryBusiness;
        private District _district;
        private Boolean _adding { get; set; }
        private District _dictrictEdit;
        public DistrictDetailForm()
        {
            InitializeComponent();            
            _adding = true;
            _myCountryBusiness = new MyCountryBusiness();
        }

        public DistrictDetailForm(District district)
        {
            InitializeComponent();
            _myCountryBusiness = new MyCountryBusiness();

            var districtCode = district != null ? district.DistrictCode : string.Empty;

          if(string.IsNullOrEmpty(districtCode))
            {
                _adding = true;
            }
            else
            {
                _adding = false;
                _dictrictEdit = district;
            }
            
        }
        private void FillDataOldUpForm(District district)
        {
            
            txtDistrictCode.Text = district.DistrictCode;
            txtDistrictName.Text = district.Name;
            txtDistrictType.Text = district.Type;
            cbbCity.SelectedIndex = cbbCity.FindString(_myCountryBusiness.GetNameCity(district.CityCode));
        }


        private District MatchNewDataDistrict(District district)
        {
            
            district.DistrictCode = txtDistrictCode.Text;
            district.Name = txtDistrictName.Text;
            district.Type = txtDistrictType.Text;
            var selectedCity = cbbCity.SelectedItem as City;
            district.CityCode = selectedCity != null ? selectedCity.CityCode : string.Empty;

            if (string.IsNullOrEmpty(district.DistrictCode))
            {
                throw new Exception("District code cannot be empty.");
            }

            if (string.IsNullOrEmpty(district.Name))
            {
                throw new Exception("District name cannot be empty.");
            }

            if (string.IsNullOrEmpty(district.CityCode))
            {
                throw new Exception("City code cannot be empty.");
            }

            return district;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
                try
            {
                _district = new District();
                if (_adding)
                {
                    _myCountryBusiness.AddDistrict(MatchNewDataDistrict(_district));

                    DialogResult = DialogResult.OK;
                }
                else
                { 
                    _myCountryBusiness.EditDistrict(MatchNewDataDistrict(_dictrictEdit));

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void DistrictDetailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                var loadAgainData = new MainForm();
                loadAgainData.FillDataGrvDistrict();
                loadAgainData.FillNameCitiesToSearch();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DistrictDetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                cbbCity.DataSource = _myCountryBusiness.GetCities();
                cbbCity.DisplayMember = nameof(City.Name);
                if (!_adding)
                {
                    FillDataOldUpForm(_dictrictEdit);
                    txtDistrictCode.ReadOnly = true;
                    cbbCity.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
