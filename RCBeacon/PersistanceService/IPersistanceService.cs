using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceService
{
    public interface IPersistanceService
    {
        void Insert(string key, object value);
        Task<T> GetObject<T>(string key);
    }
}
