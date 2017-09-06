using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCountryApplication.Modal;

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
            return null;
        }
    }

    
}
