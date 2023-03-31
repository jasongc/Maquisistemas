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
        public void Insert()
        {
            try
            {
                _productoACD.Insert();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update()
        {
            try
            {
                _productoACD.Update();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public RespuestaENT<List<ProductoENT>> Get()
        {
            try
            {
                _productoACD.Update();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return new RespuestaENT<List<ProductoENT>>();
        }
        public RespuestaENT<ProductoENT> GetById()
        {
            RespuestaENT<ProductoENT>
            try
            {
                _productoACD.GetById();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return new RespuestaENT<ProductoENT>();
        }
    }
}