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
        public int Insert(ProductoENT productoENT);
        public void Update(ProductoENT productoENT);

        public List<ProductoENT> Get();
        public ProductoENT GetById(int ProductId);
    }
}
