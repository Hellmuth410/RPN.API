using Microsoft.Extensions.Caching.Memory;

namespace RPN.API.Tools
{
    public static class CacheManager
    {
        public static IDictionary<int, Stack<decimal>> AllCachedStacks(IMemoryCache cache)
        {
            if (!cache.TryGetValue("STACKS", out IDictionary<int, Stack<decimal>> allStacks))
            {
                allStacks = new Dictionary<int, Stack<decimal>>();
            }
            return allStacks;
        }
        public static void UpdateCachedStacks(IMemoryCache cache, IDictionary<int, Stack<decimal>> allStacks)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(15));

            // Sauvegardez les données dans le cache.
            cache.Set("STACKS", allStacks, cacheEntryOptions);
        }
    }
}
