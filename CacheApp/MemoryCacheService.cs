using Microsoft.Extensions.Caching.Memory;

namespace CacheApp
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public object Get(string key)
        {
            return _memoryCache.Get<object>(key);
        }


        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void Set(string key, object value, MemoryCacheEntryOptions options)
        {
            _memoryCache.Set(key, value,options);
        }
        public MemoryCacheEntryOptions GetEntryOptions(int sizeLimit, CacheItemPriority priority,int slidingExpiration, int absoluteExpiration)
        {
            MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions().SetSize(sizeLimit).SetPriority(priority);
            cacheOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(slidingExpiration);
            cacheOptions.SlidingExpiration = TimeSpan.FromSeconds(absoluteExpiration);
            return cacheOptions;
        }

      
    }
}
