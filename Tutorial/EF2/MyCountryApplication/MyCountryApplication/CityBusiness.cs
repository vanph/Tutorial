using System;
using System.Collections.Generic;
using System.Linq;
using MyCountry.DataAccess;
using MyCountry.DataAccess.Model;
using MyCountry.DataAccess.Persistence;
using MyCountryApplication.Common;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication
{
    public class CityBusiness : ICityBusiness
    {
        public List<CityInfomation> GetCityInfomations()
        {
            //Todo: use lazy loading
            using (var dbContext = new MyCountryEntities())
            {
                var cityInfomations = dbContext.Districts.GroupBy(d => new {d.CityCode, d.City.Name}).Select(
                    c => new CityInfomation()
                    {
                        CityCode = c.Key.CityCode,
                        CityName = c.Key.CityCode,
                        DistrictNames = c.Select(x => x.Name).ToList()

                    }).ToList();

                return cityInfomations;
            }

           
        }
        
        public List<City> GetCities()
        {
            using (var dbContext = new MyCountryEntities())
            {
                var cities = dbContext.Cities.ToList();

                return cities;

            }
        }

        public City GetCityByCode(string code)
        {
            using (var dbContext = new MyCountryEntities())
            {
                return dbContext.Cities.FirstOrDefault(x => x.CityCode == code);
            }
        }
    }
}