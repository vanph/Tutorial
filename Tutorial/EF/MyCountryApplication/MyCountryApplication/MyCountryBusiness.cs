﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCountryApplication.Model;

namespace MyCountryApplication
{
    public class MyCountryBusiness
    {
        public List<DistrictInformation> GetDistrictInformations(string keyword ="", string cityCode ="")
        {            
            var dbContext = new MyCountryEntities();
            
            var query = from d in dbContext.Districts
                        join c in dbContext.Cities on d.CityCode equals c.CityCode
                        select new DistrictInformation { DistrictCode = d.DistrictCode, DistrictName = d.Name, CityName = c.Name, CityCode = c.CityCode };

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.DistrictCode.Contains(keyword) || x.DistrictName.Contains(keyword));   
            }
            if (!string.IsNullOrEmpty(cityCode))
            {
                query = query.Where(x => x.CityCode == cityCode);
            }

            return query.ToList();
        }

        public List<City> GetCities()
        {
            var dbContext = new MyCountryEntities();

            return dbContext.Cities.ToList();
        }
    }
}
