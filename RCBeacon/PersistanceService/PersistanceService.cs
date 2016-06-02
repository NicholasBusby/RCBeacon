using Akavache;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace PersistanceService
{
    public class PersistanceService: IPersistanceService
    {
        public PersistanceService(string applicationName)
        {
            BlobCache.ApplicationName = applicationName;
        }

        public async void Insert(string key, object value)
        {
            await BlobCache.UserAccount.InsertObject(key, value);
        }

        public async Task<T> GetObject<T>(string key)
        {
            return await BlobCache.UserAccount.GetObject<T>(key)
                .Catch(Observable.Return(default(T)));
        }
    }
}
