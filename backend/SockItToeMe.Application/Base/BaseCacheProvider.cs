using Microsoft.Extensions.Caching.Memory;
using SockItToeMe.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SockItToeMe.Application.Base
{
    public abstract class BaseCacheProvider<E> where E : IDescriptionModel
    {
        public abstract string cache_key { get; }
        protected readonly IMemoryCache Cache = null;

        public BaseCacheProvider(IMemoryCache memoryCache)
        {
            this.Cache = memoryCache;
        }

        protected bool TryGetFromCache(int id, out E model)
        {
            if (this.Cache.TryGetValue($"{cache_key}_{id}", out model))
            {
                return true;
            }
            return false;
        }

        protected void AddToCache(E model)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                                                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            this.Cache.Set($"{cache_key}_{model.Id}", model, cacheEntryOptions);
        }
    }
}
