using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IDatosCacheACD
    {
        public Dictionary<int, string>? GetCacheValues(Dictionary<int, string>? valoresCache, string nombreLlaveCache = "DefaultCacheKey");
    }
}
