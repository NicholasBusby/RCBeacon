using Akavache;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace PersistanceService
{
    public class AkavachePersistanceService: IPersistanceService
    {

        public async Task<Unit> InsertToMemory(string key, object value)
        {
            return await BlobCache.UserAccount.InsertObject(key, value);
        }

        public async Task<T> GetObject<T>(string key)
        {
            var savedObject = await BlobCache.UserAccount.GetObject<T>(key)
                .Catch(Observable.Return(default(T)));
            return savedObject;
        }

        public async Task<Unit> RemoveFromMemory(string key)
        {
            return await BlobCache.UserAccount.Invalidate(key);
        }
    }
}
