using System.Collections.Generic;
using MyCountry.DataAccess;
using MyCountryApplication.Common;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication
{
    public interface IDistrictBusiness
    {
        List<DistrictViewModel> GetDistrictInformations(out int totalCount, string keyword = "", string cityCode = "", int pageNumber = 1, int pageSize = Constants.PageSize);
        void AddDistrict(District districtParam);
        District GetDistrictByCode(string code);
        void EditDistrict(District districtParam);
        void DeleteDistrict(string districtCode);
    }
}