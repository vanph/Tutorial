using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCountry.Repository
{
    public interface IGeneralRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetPagedData(Func<T, bool> predicate = null, int pageSize =10, int pageNumer =1);

    }
}
