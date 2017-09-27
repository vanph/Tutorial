using System.Collections.Generic;
using MyCountry.DataAccess.Model;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication
{
    public interface ICityBusiness
    {
        List<CityInfomation> GetCityInfomations();
        List<City> GetCities();
        City GetCityByCode(string code);
    }
}