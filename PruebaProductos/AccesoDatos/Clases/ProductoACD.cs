using AccesoDatos.Interfaces;
using Entidades.Clases;

namespace AccesoDatos.Clases
{
    public class ProductoACD : IProductoACD
    {
        public bool Insert()
        {

            return true;
        }
        public bool Update()
        {

            return true;
        }
        public List<ProductoENT> Get()
        {

            return new List<ProductoENT>();
        }
        public ProductoENT GetById()
        {
            return new ProductoENT();
        }
    }
}