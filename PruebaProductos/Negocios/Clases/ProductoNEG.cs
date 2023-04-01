using AccesoDatos.Interfaces;
using Entidades.Clases;
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
                if (ValidarCamposObligatorios(productoENT))
                    throw new Exception("Los campos de Nombre y Descripción del producto son obligatorios.");

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
                if (ValidarCamposObligatorios(productoENT))
                    throw new Exception("Los campos de Nombre y Descripción del producto son obligatorios.");

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

        private bool ValidarCamposObligatorios(ProductoENT productoENT)
        {
            return string.IsNullOrEmpty(productoENT.Name) || string.IsNullOrEmpty(productoENT.Description);
        }
    }
}