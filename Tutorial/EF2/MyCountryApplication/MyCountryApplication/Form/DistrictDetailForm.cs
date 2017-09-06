using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountryApplication.Modal;
using MyCountryApplication;

namespace MyCountryApplication
{
    

    public partial class DistrictDetailForm : Form
    {
        private MyCountryEntities _dbContext;
        private District _district;
        private City _city;
        private Boolean _adding { get;  set; }
        public DistrictDetailForm()
        {
            InitializeComponent();
            lblNoticeDistrictCode.Visible = false;
            _dbContext = new MyCountryEntities();
            _district = new District();
            _city = new City();

            _adding = true;
        }

        //public DistrictDetailForm(District district, City city)
        //{
        //    InitializeComponent();
        //    lblNoticeDistrictCode.Visible = false;

        //    _district = district;
        //    _city = city;

           

        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            if (_adding)
            {
                bool flag = true;
                

                foreach (var dictrictList in _dbContext.Districts)
                {
                    if (dictrictList.DistrictCode == txtDistrictCode.Text)
                    {
                        flag = false;
                        lblNoticeDistrictCode.Visible = true;
                    }
                }

                if(flag == true)
                {
                    _district.DistrictCode = txtDistrictCode.Text;
                    _district.Name = txtDistrictName.Text;
                    _district.Type = txtDistrictType.Text;
                    _district.CityCode = txtCityCode.Text;

                    _dbContext.Districts.Add(_district);

                    _city.CityCode = txtCityCode.Text;
                    _city.Name = txtCityName.Text;
                    _city.Type = txtCityType.Text;

                    _dbContext.SaveChanges();

                }
                DialogResult = DialogResult.OK;
                                
            }
            else
            //{
                 
            //    _district.DistrictCode = txtDistrictCode.Text;
            //    _district.Name = txtDistrictName.Text;
            //    _district.Type = txtDistrictType.Text;
            //    _district.CityCode = txtCityCode.Text;

            //    _dbContext.Districts.Add(_district);

            //    _city.CityCode = txtCityCode.Text;
            //    _city.Name = txtCityName.Text;
            //    _city.Type = txtCityType.Text;


            //    _dbContext.Cities.Add(_city);
            //    _dbContext.SaveChanges();
            //}
            
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

        
    }
}
