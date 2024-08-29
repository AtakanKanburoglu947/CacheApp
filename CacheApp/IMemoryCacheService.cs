using Microsoft.Extensions.Caching.Memory;

namespace CacheApp
{
    public interface IMemoryCacheService 
    {
        object Get(string key);
        void Set(string key, object value, MemoryCacheEntryOptions options);
        void Remove(string key);
        MemoryCacheEntryOptions GetEntryOptions(int sizeLimit, CacheItemPriority priority, int slidingExpiration, int absoluteExpiration);
    }
}
