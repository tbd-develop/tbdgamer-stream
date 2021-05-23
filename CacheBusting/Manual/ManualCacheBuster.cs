﻿namespace Blazor.Contentful_.Blog.Starter.CacheBusting.Manual
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blazor.Contentful_.Blog.Starter.CacheBusting.Api;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// This service will bust the cache of any registered <see cref="BustCache"/> services.
    /// </summary>
    public class ManualCacheBuster
        : CacheBuster
    {
        private readonly ILogger _logger;
        private readonly IEnumerable<BustCache> _bustCacheList;

        public ManualCacheBuster(
            ILogger<ManualCacheBuster> logger,
            IEnumerable<BustCache> bustCacheList
        )
        {
            _logger = logger;
            _bustCacheList = bustCacheList;
        }

        public async Task BustCache()
        {
            _logger.LogWarning(
                "Busting the cache of {ServiceCount} service(s).",
                _bustCacheList.Count()
            );
            foreach (var bustCacheItem in _bustCacheList)
            {
                await bustCacheItem.BustCache();
            }
        }
    }
}
