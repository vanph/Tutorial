using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCountryApplication.Modal;
using System.Windows.Forms;

namespace MyCountryApplication
{
    public class MyCountryBusiness
    {
        public string DistrictCode { get; private set; }

        public List<DistrictInformation> GetDistrictInfomation(string keyword ="", string cityCode = "")
        {
            var dbContext = new MyCountryEntities();
            var query = from d in dbContext.Districts
                        join c in dbContext.Cities
                        on d.CityCode equals c.CityCode
                        select new DistrictInformation { DistrictCode = d.DistrictCode, DistrictName = d.Name, CityName = c.Name, CityCode = c.CityCode };

            if (!string.IsNullOrEmpty(keyword)){
                query = query.Where(x => x.DistrictCode == keyword || x.DistrictName == keyword);
            }

            if (!string.IsNullOrEmpty(cityCode))
            {
                query = query.Where(x => x.CityCode== cityCode);
            }

            return query.ToList();
        }

        public List<City> GetCities()
        {
            var dbContext = new MyCountryEntities();
            return dbContext.Cities.ToList();
        }

        public void AddDistrict(District district)
        {            
            
            var dbContext = new MyCountryEntities();

            var isExisted = dbContext.Districts.Any(x => x.DistrictCode == district.DistrictCode);

            if(isExisted)
            {
                throw new Exception($"District code {district.DistrictCode} exists.");
            }

            dbContext.Districts.Add(district);

            dbContext.SaveChanges();            
        }

        
        public District GetDistrictByCode(string code)
        {
            var dbContext = new MyCountryEntities();        
            return dbContext.Districts.FirstOrDefault(x => x.DistrictCode == code);
        }

        public void EditDistrict(District district)
        { 
            var dbContext = new MyCountryEntities();
            var existingDistrict = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == district.DistrictCode);
            if(existingDistrict != null)
            {
                existingDistrict.Name = district.Name;
                existingDistrict.Type = district.Type;
                dbContext.SaveChanges();

                MessageBox.Show(@"Successfully removed the selected customer");
            }
            else
            {
                MessageBox.Show(@"Cannot found the selected customer");
            }
            
        }

        public City GetCityByCode(string code)
        {
            var dbContext = new MyCountryEntities();
            return dbContext.Cities.FirstOrDefault(x => x.CityCode == code);
        }
        public string GetNameCity(string code)
        {
            return GetCityByCode(code).Name;
        }
        
        public void DeleteDistrict(District district)
        {
            var dbContext = new MyCountryEntities();
            var existingDistrict = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == district.DistrictCode);
            if (existingDistrict != null)
            {
                dbContext.Districts.Remove(existingDistrict);
                dbContext.SaveChanges();
                MessageBox.Show(@"Successfully removed the selected customer");
            }
            else
            {
                MessageBox.Show(@"Cannot found the selected customer");
            }
        }
    }
}
