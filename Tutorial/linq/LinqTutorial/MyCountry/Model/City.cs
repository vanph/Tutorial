namespace MyCountry.Model
{
    public  class City
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public City(string code, string name, string type)
        {
            Code = code;
            Name = name;
            Type = type;
        }
    }
}
