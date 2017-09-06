using System;
using System.Windows.Forms;
using MyCountryApplication.Modal;

namespace MyCountryApplication
{
    public partial class DistrictDetailForm : Form
    {        
        private readonly MyCountryBusiness _myCountryBusiness;
        private District _district;
        private City _city;
        private Boolean _adding { get; set; }
        public DistrictDetailForm()
        {
            InitializeComponent();            
            _district = new District();
            _city = new City();
            _adding = true;
            _myCountryBusiness = new MyCountryBusiness();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_adding)
                {
                    
                    _district.DistrictCode = txtDistrictCode.Text;
                    _district.Name = txtDistrictName.Text;
                    _district.Type = txtDistrictType.Text;
                    var selectedCity = cbbCity.SelectedItem as City;
                    _district.CityCode = selectedCity != null ? selectedCity.CityCode : string.Empty;   
                    
                    _myCountryBusiness.AddDistrict(_district);

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
            var loadAgainData = new MainForm();

            loadAgainData.FillDataGrvDistrict();
            loadAgainData.FillNameCitiesToSearch();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DistrictDetailForm_Load(object sender, EventArgs e)
        {
            //_myCountryBusiness.GetCities();
            cbbCity.DataSource = _myCountryBusiness.GetCities();
            cbbCity.DisplayMember = nameof(City.Name);
        }

       
    }
}
