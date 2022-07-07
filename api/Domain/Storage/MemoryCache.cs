using System.Threading;
using API.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace API.Domain.Storage
{
    public class MemoryCache: ICache
    {
        private int _entryAmount;
        private readonly IMemoryCache _cache;

        public MemoryCache(IMemoryCache cache)
        { 
            _entryAmount = 0;
            _cache = cache;
        }

        public bool TryGetValue<TItem>(object key, out TItem value)
        {
            return _cache.TryGetValue(key,out value);
        }

        public TItem Set<TItem>(object key, TItem value)
        {
            //Modifying a shared integer in a thread-safe manner
            Interlocked.Increment(ref _entryAmount);
            return _cache.Set(key, value);
        }

        public void Remove(object key)
        {
            //Modifying a shared integer in a thread-safe manner
            Interlocked.Decrement(ref _entryAmount);
            _cache.Remove(key);
        }

        public int Count()
        {
            return _entryAmount;
        }
    }
}
