using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public  class User
    {
       
        public string UserName { get; set; }
        

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; }


        public void ShowInfo()
        {
            if (DateOfBirth.HasValue)
            {
                Console.WriteLine($"User Name: {UserName} - Date of Birth: {DateOfBirth} - Created Date: {CreatedDate}");
            }
            else
            {
                Console.WriteLine($"User Name: {UserName} - Created Date: {CreatedDate}");
            }
            
        }
    }
}
