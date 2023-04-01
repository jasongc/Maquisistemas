using AccesoDatos.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class DatosCacheACD : IDatosCacheACD
    {
        protected readonly IMemoryCache _cache;

        public DatosCacheACD(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Dictionary<int, string>? GetCacheValues(Dictionary<int, string>? valoresCache, string nombreLlaveCache = "DefaultCacheKey")
        {
            Dictionary<int, string>? cacheEntry = _cache.GetOrCreate(nombreLlaveCache, entry =>
            {
                // Aquí se le indica que solo durará 5 minutos o lo que se configure
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

                return valoresCache;
            });

            return cacheEntry;
        }
    }
}
