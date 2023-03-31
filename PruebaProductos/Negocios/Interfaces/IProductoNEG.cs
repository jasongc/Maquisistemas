using Entidades.Clases;
using Entidades.Utilitarios;
using Negocios.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Interfaces
{
    public interface IProductoNEG
    {
        public void Insert();
        public void Update();
        public RespuestaENT<List<ProductoENT>> Get();
        public RespuestaENT<ProductoENT> GetById();
    }
}
