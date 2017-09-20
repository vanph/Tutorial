using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountry.DataAccess.Persistence;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.View
{
    public partial class CitiesForm : Form
    {
        public CitiesForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CitiesForm_Load(object sender, EventArgs e)
        {
            var dbContext = new MyCountryEntities();

            
            var query = from d in dbContext.Districts
                join c in dbContext.Cities on d.CityCode equals c.CityCode
                select new {CityCode = c.CityCode, CityName = c.Name, DistrictName = d.Name};
            //Todo: use lazy loading
            //var cityInfomations = (from q in query
            //                          group q by new { q.CityCode, q.CityName }
            //                          into g
            //                          select new CityInfomation
            //                          {
            //                              CityCode = g.Key.CityCode,
            //                              CityName = g.Key.CityName,
            //                              DistrictNames = g.Select(x => x.DistrictName).ToList()
            //                          }).ToList();

            var cityInfomations = query.GroupBy(q => new { q.CityCode, q.CityName }).Select(g => new CityInfomation
            {
                CityCode = g.Key.CityCode,
                CityName = g.Key.CityName,
                DistrictNames = g.Select(x => x.DistrictName).ToList()
            }).ToList();

            dataGridView1.DataSource = cityInfomations;
        }




    }
    }
