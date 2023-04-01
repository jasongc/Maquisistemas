using AccesoDatos.Interfaces;
using Entidades.Clases;
using Entidades.Utilitarios;
using Negocios.Interfaces;

namespace Negocios.Clases
{
    public class ProductoNEG : IProductoNEG
    {
        protected readonly IProductoACD _productoACD;
        public ProductoNEG(IProductoACD productoACD)
        {
            _productoACD = productoACD;
        }
        public int Insert(ProductoENT productoENT)
        {
            try
            {
                return _productoACD.InsertOrUpdate(productoENT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(ProductoENT productoENT)
        {
            try
            {
                _productoACD.InsertOrUpdate(productoENT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductoENT> Get()
        {
            try
            {
                return _productoACD.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductoENT GetById(int ProductId)
        {
            try
            {
                return _productoACD.GetById(ProductId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}