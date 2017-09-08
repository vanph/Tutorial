using System;
using System.Windows.Forms;
using MyCountryApplication.Modal;

namespace MyCountryApplication
{
    public partial class DistrictDetailForm : Form
    {
        private readonly MyCountryBusiness _myCountryBusiness;
        
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
            _adding = false;
            _dictrictEdit = district;

        }
        private void FillDataOldUpForm(District district)
        {
            txtDistrictCode.Text = district.DistrictCode;
            txtDistrictName.Text = district.Name;
            txtDistrictType.Text = district.Type;

            var city = _myCountryBusiness.GetCityByCode(district.CityCode);
            var cityName = city != null ? city.Name : string.Empty;

            cbbCity.SelectedIndex = cbbCity.FindString(cityName);
        }


        private District GetBindingDistrict()
        {
            var district = new District()
            {
                DistrictCode = txtDistrictCode.Text,
                Name = txtDistrictName.Text,
                Type = txtDistrictType.Text
            };
            var selectedCity = cbbCity.SelectedItem as City;
            district.CityCode = selectedCity != null ? selectedCity.CityCode : string.Empty;

            return district;
        }

        private bool IsValidDistrict(District district, out string errorMessage)
        {
            errorMessage = string.Empty;
            
            if (string.IsNullOrEmpty(district.DistrictCode))
            {
                errorMessage = "District code cannot be empty.";
                return false;
            }

            if (string.IsNullOrEmpty(district.Name))
            {
                errorMessage = "District name cannot be empty.";
                return false;
            }

            if (string.IsNullOrEmpty(district.CityCode))
            {
                errorMessage = "City code cannot be empty.";
                return false;
            }

            if (string.IsNullOrEmpty(district.Type))
            {
                errorMessage = "District type cannot be empty.";
                return false;
            }

            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var district = GetBindingDistrict();                
                string errorMessage = string.Empty;

                if(!IsValidDistrict(district, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return;
                }
                
                if (_adding)
                {
                    _myCountryBusiness.AddDistrict(district);
                }
                else
                {
                    _myCountryBusiness.EditDistrict(district);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DistrictDetailForm_Load(object sender, EventArgs e)
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

       
    }
}
