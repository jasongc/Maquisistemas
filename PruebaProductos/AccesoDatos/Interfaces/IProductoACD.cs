using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IProductoACD
    {
        public int InsertOrUpdate(ProductoENT productoENT);
        public List<ProductoENT> Get(int? ProductId = null);
        public ProductoENT GetById(int ProductId);
    }
}
