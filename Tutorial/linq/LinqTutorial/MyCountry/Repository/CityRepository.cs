using System;
using System.Collections.Generic;
using System.Linq;
using MyCountry.Model;

namespace MyCountry.Repository
{
    public class CityRepository: BaseRepository<City>, ICityRepository
    {
        public City GetByCity(string code)
        {
            return Data.FirstOrDefault(x => x.Code == code);
        }
                
        protected override void InitData()
        {
            Data = new List<City>
           {
                new City("01", "Thành phố Hà Nội", "Thành phố Trung ương"),
                new City("02", "Tỉnh Hà Giang", "Tỉnh"),
                new City("04", "Tỉnh Cao Bằng", "Tỉnh"),
                new City("06", "Tỉnh Bắc Kạn", "Tỉnh"),
                new City("08", "Tỉnh Tuyên Quang", "Tỉnh"),
                new City("10", "Tỉnh Lào Cai", "Tỉnh"),
                new City("11", "Tỉnh Điện Biên", "Tỉnh"),
                new City("12", "Tỉnh Lai Châu", "Tỉnh"),
                new City("14", "Tỉnh Sơn La", "Tỉnh"),
                new City("15", "Tỉnh Yên Bái", "Tỉnh"),
                new City("17", "Tỉnh Hoà Bình", "Tỉnh"),
                new City("19", "Tỉnh Thái Nguyên", "Tỉnh"),
                new City("20", "Tỉnh Lạng Sơn", "Tỉnh"),
                new City("22", "Tỉnh Quảng Ninh", "Tỉnh"),
                new City("24", "Tỉnh Bắc Giang", "Tỉnh"),
                new City("25", "Tỉnh Phú Thọ", "Tỉnh"),
                new City("26", "Tỉnh Vĩnh Phúc", "Tỉnh"),
                new City("27", "Tỉnh Bắc Ninh", "Tỉnh"),
                new City("30", "Tỉnh Hải Dương", "Tỉnh"),
                new City("31", "Thành phố Hải Phòng", "Thành phố Trung ương"),
                new City("33", "Tỉnh Hưng Yên", "Tỉnh"),
                new City("34", "Tỉnh Thái Bình", "Tỉnh"),
                new City("35", "Tỉnh Hà Nam", "Tỉnh"),
                new City("36", "Tỉnh Nam Định", "Tỉnh"),
                new City("37", "Tỉnh Ninh Bình", "Tỉnh"),
                new City("38", "Tỉnh Thanh Hóa", "Tỉnh"),
                new City("40", "Tỉnh Nghệ An", "Tỉnh"),
                new City("42", "Tỉnh Hà Tĩnh", "Tỉnh"),
                new City("44", "Tỉnh Quảng Bình", "Tỉnh"),
                new City("45", "Tỉnh Quảng Trị", "Tỉnh"),
                new City("46", "Tỉnh Thừa Thiên Huế", "Tỉnh"),
                new City("48", "Thành phố Đà Nẵng", "Thành phố Trung ương"),
                new City("49", "Tỉnh Quảng Nam", "Tỉnh"),
                new City("51", "Tỉnh Quảng Ngãi", "Tỉnh"),
                new City("52", "Tỉnh Bình Định", "Tỉnh"),
                new City("54", "Tỉnh Phú Yên", "Tỉnh"),
                new City("56", "Tỉnh Khánh Hòa", "Tỉnh"),
                new City("58", "Tỉnh Ninh Thuận", "Tỉnh"),
                new City("60", "Tỉnh Bình Thuận", "Tỉnh"),
                new City("62", "Tỉnh Kon Tum", "Tỉnh"),
                new City("64", "Tỉnh Gia Lai", "Tỉnh"),
                new City("66", "Tỉnh Đắk Lắk", "Tỉnh"),
                new City("67", "Tỉnh Đắk Nông", "Tỉnh"),
                new City("68", "Tỉnh Lâm Đồng", "Tỉnh"),
                new City("70", "Tỉnh Bình Phước", "Tỉnh"),
                new City("72", "Tỉnh Tây Ninh", "Tỉnh"),
                new City("74", "Tỉnh Bình Dương", "Tỉnh"),
                new City("75", "Tỉnh Đồng Nai", "Tỉnh"),
                new City("77", "Tỉnh Bà Rịa - Vũng Tàu", "Tỉnh"),
                new City("79", "Thành phố Hồ Chí Minh", "Thành phố Trung ương"),
                new City("80", "Tỉnh Long An", "Tỉnh"),
                new City("82", "Tỉnh Tiền Giang", "Tỉnh"),
                new City("83", "Tỉnh Bến Tre", "Tỉnh"),
                new City("84", "Tỉnh Trà Vinh", "Tỉnh"),
                new City("86", "Tỉnh Vĩnh Long", "Tỉnh"),
                new City("87", "Tỉnh Đồng Tháp", "Tỉnh"),
                new City("89", "Tỉnh An Giang", "Tỉnh"),
                new City("91", "Tỉnh Kiên Giang", "Tỉnh"),
                new City("92", "Thành phố Cần Thơ", "Thành phố Trung ương"),
                new City("93", "Tỉnh Hậu Giang", "Tỉnh"),
                new City("94", "Tỉnh Sóc Trăng", "Tỉnh"),
                new City("95", "Tỉnh Bạc Liêu", "Tỉnh"),
                new City("96", "Tỉnh Cà Mau", "Tỉnh")
           };

        }
    }
}
