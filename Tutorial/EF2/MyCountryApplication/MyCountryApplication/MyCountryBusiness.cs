using System;
using System.Collections.Generic;
using System.Linq;
using MyCountryApplication.ViewModel;
using System.Data.Entity;
using MyCountry.DataAccess;
using MyCountry.DataAccess.Model;
using MyCountry.DataAccess.Persistence;
using MyCountryApplication.Common;

namespace MyCountryApplication
{
    public class MyCountryBusiness
    {
        public List<DistrictViewModel> GetDistrictInformations(out int totalCount, string keyword = "", string cityCode = "", int pageNumber = 1, int pageSize = Constants.PageSize)
        {
            var dbContext = new MyCountryEntities();

            //Version 1: query with join
            //var query = from d in dbContext.Districts
            //            join c in dbContext.Cities
            //            on d.CityCode equals c.CityCode
            //            select new DistrictViewModel { DistrictCode = d.DistrictCode, DistrictName = d.Name, CityName = c.Name, CityCode = c.CityCode };

            //Version 2: 
            var query = dbContext.Districts.Select(x => new DistrictViewModel
            {
                DistrictCode = x.DistrictCode,
                DistrictName = x.Name,
                CityName = x.City.Name,
                CityCode = x.City.CityCode
            });


            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.DistrictCode.Contains(keyword) || x.DistrictName.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(cityCode))
            {
                query = query.Where(x => x.CityCode == cityCode);
            }

            totalCount = query.Count();

            if (pageNumber != 0)
            {
                query = query.OrderBy(x => x.DistrictCode).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }


            return query.ToList();
        }



        public List<City> GetCities()
        {
            var dbContext = new MyCountryEntities();
            var cities= dbContext.Cities.ToList();
            
            return cities;
        }

        public void AddDistrict(District district)
        {
            var dbContext = new MyCountryEntities();

            var isExisted = dbContext.Districts.Any(x => x.DistrictCode == district.DistrictCode);

            if (isExisted)
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
            if (existingDistrict != null)
            {
                existingDistrict.Name = district.Name;
                existingDistrict.Type = district.Type;
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Cannot found district");
            }

        }

        public City GetCityByCode(string code)
        {
            var dbContext = new MyCountryEntities();
            return dbContext.Cities.FirstOrDefault(x => x.CityCode == code);
        }

        //public void DeleteDistrict(District district)
        //{
        //    var dbContext = new MyCountryEntities();
        //    var existingDistrict = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == district.DistrictCode);
        //    if (existingDistrict != null)
        //    {
        //        dbContext.Districts.Remove(existingDistrict);
        //        dbContext.SaveChanges();
        //    }
        //    else
        //    {
        //        throw new Exception("Cannot found dictrict");
        //    }
        //}

        public void DeleteDistrict(string districtCode)
        {
            var dbContext = new MyCountryEntities();
            var existingDistrict = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == districtCode);
            if (existingDistrict != null)
            {
                dbContext.Districts.Remove(existingDistrict);
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Cannot found dictrict");
            }
        }
    }
}
