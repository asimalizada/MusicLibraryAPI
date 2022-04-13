using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceHelper
                .ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache
                .Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache)
                .GetProperty("EntriesCollection",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition
                .GetValue(_memoryCache) as dynamic;

            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
            foreach (var cacheCollectionItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheCollectionItem.GetType()
                    .GetProperty("Value").GetValue(cacheCollectionItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern,
                RegexOptions.Singleline
                | RegexOptions.Compiled
                | RegexOptions.IgnoreCase);
            var keyToRemove = cacheCollectionValues
                .Where(c => regex.IsMatch(c.Key.ToString()))
                .Select(c => c.Key).ToList();

            foreach (var key in keyToRemove)
            {
                _memoryCache.Remove(key);
            }
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
    }
}
