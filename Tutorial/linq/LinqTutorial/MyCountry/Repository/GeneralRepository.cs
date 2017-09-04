using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCountry.Repository
{
    public abstract class BaseRepository<T> : IGeneralRepository<T> where T:class
    {
        protected IEnumerable<T> Data { get; set; }
        
        public BaseRepository()
        {
            InitData();
        }

        protected abstract void InitData();

        public IEnumerable<T> GetAll()
        {
            return Data;
        }

        public IEnumerable<T> GetPagedData(Func<T, bool> predicate = null, int pageSize = 10, int pageNumer = 1)
        {
            if(predicate == null)
            {
                return Data.Skip((pageNumer -1) * pageSize).Take(pageSize);
            }
            else
            {
                return Data.Where(predicate).Skip((pageNumer - 1) * pageSize).Take(pageSize);
            }
        }
    }
}
