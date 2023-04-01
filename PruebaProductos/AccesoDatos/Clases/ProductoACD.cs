using AccesoDatos.Interfaces;
using ApisTerceros;
using Entidades.Clases;
using Entidades.Conexion;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Clases
{
    public class ProductoACD : IProductoACD 
    {
        protected readonly PruebaProductoContext _context;
        protected readonly IDatosCacheACD _datosCacheACD;
        protected readonly IMockApiAT _mockApiAT;
        public ProductoACD(PruebaProductoContext context, IDatosCacheACD datosCacheACD, IMockApiAT mockApiAT)
        {
            _context = context;
            _datosCacheACD = datosCacheACD;
            _mockApiAT = mockApiAT;
        }
        public int InsertOrUpdate(ProductoENT productoENT)
        {
            int ProductId;
            using (SqlConnection cnn = _context.Connection())
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("CrearProducto", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pProductId", productoENT.ProductId);
                        cmd.Parameters.AddWithValue("@pName", productoENT.Name);
                        cmd.Parameters.AddWithValue("@pStatus", productoENT.Status);
                        cmd.Parameters.AddWithValue("@pStock", productoENT.Stock);
                        cmd.Parameters.AddWithValue("@pDescription", productoENT.Description);
                        cmd.Parameters.AddWithValue("@pPrice", productoENT.Price);


                        object? resultado = cmd.ExecuteScalar();

                        ProductId = int.Parse(resultado.ToString());

                        cmd.Dispose();
                    }

                    cnn.Close();
                    cnn.Dispose();
                }
                catch (Exception ex)
                {

                    cnn.Close();
                    cnn.Dispose();
                    throw ex;
                }
            }
            return ProductId;
        }
        public List<ProductoENT> Get(int? ProductId = null)
        {
            Dictionary<int, string>? EstadosCache = _datosCacheACD.GetCacheValues(null, "EstadoCacheKey");

            List<ProductoENT> productoENTs = new List<ProductoENT>();
            ProductoENT productoENT;
            using (SqlConnection cnn = _context.Connection())
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("ObtenerProducto", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pProductId", ProductId);

                        SqlDataReader drd = cmd.ExecuteReader();
                        while (drd.Read())
                        {
                            productoENT = new ProductoENT();
                            productoENT.InternalProductId = _context.reader<int>(drd, "ProductId");
                            productoENT.Name = _context.reader<string>(drd, "Name");
                            productoENT.Status = _context.reader<short>(drd, "Status");
                            productoENT.Stock = _context.reader<decimal>(drd, "Stock");
                            productoENT.Description = _context.reader<string>(drd, "Description");
                            productoENT.Price = _context.reader<decimal>(drd, "Price");
                            productoENT.InternalCreateDate = _context.reader<DateTime>(drd, "CreateDate");
                            productoENT.InternalUpdateDate = _context.reader<DateTime>(drd, "UpdateDate");
                            productoENT.InternalStatusName = EstadosCache == null ? "-" : EstadosCache[productoENT.Status];

                            if(ProductId != null)//SE CONDICIONA QUE SEA POR ID POR TEMA DE RENDIMIENTO
                                productoENT.InternalDiscount = _mockApiAT.ObtenerDescuento(productoENT.ProductId);

                            productoENTs.Add(productoENT);
                        }
                        cmd.Dispose();
                    }

                    cnn.Close();
                    cnn.Dispose();

                }
                catch (Exception ex)
                {

                    cnn.Close();
                    cnn.Dispose();
                    throw ex;
                }
            }
            if (ProductId != null && productoENTs.Count() == 0)
                throw new Exception("El ProductId ingresado es incorrecto.");

            return productoENTs;
        }
        public ProductoENT GetById(int ProductId)
        {
            return Get(ProductId).FirstOrDefault();
        }
    }
}