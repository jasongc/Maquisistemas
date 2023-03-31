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
        public bool Insert();
        public bool Update();
        public List<ProductoENT> Get();
        public ProductoENT GetById();
    }
}
