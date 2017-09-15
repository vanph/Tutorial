namespace MyCountryApplication.Common
{
    public static class StringMessages
    {
        public static string AddDistrictTitle = "Add new district";
        public static string EditDistrictTitle = "Edit District";
        public static string DeleteDistrictConfirmMessage = "Do you really want to delete the selected district?";
        public static string AddedDistrictSuccess = "Successfully added district.";
        public static string Information = "Information";
        public static string EditDistrictSuccess = "Successfully updated the district.";
        public static string DeleteDistrictSuccess = "Successfully deleted the district.";
        public static string ExportSuccess = "Successfully exported.";
        public static string LoginTitle = "Login";
        public static string DistrictTitle= "District";
        public static string AboutTitle = "About";
        public static string LoginSuccess = "Successfully Login.";
        public static string LoginWrongPassword = "Wrong Password.";
        public static string LoginWrongUserID= "Wrong UserID";
        public static string CitiesFormTilte = " City";
        public static string ValidatePageNumber(int min, double max) {
            return "The number of pages entered must be less than "+ max+ " and greater than "+ min;
        }

    }
}
