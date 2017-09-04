using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCountry.Model;

namespace MyCountry.Repository
{
   public interface ICityRepository:IGeneralRepository<City>
   {
       City GetByCity(string code);
   }
}
