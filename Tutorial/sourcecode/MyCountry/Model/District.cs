namespace MyCountry.Model
{
   public class District
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CityCode { get; set; }

        public District(string code, string name, string type, string cityCode)
        {
            Code = code;
            Name = name;
            Type = type;
            CityCode = cityCode;
        }
    }
}
