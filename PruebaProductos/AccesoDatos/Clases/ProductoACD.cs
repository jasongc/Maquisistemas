using AccesoDatos.Interfaces;
using Entidades.Clases;
using Entidades.Conexion;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Clases
{
    public class ProductoACD : IProductoACD
    {
        protected readonly PruebaProductoContext _context;
        public ProductoACD(PruebaProductoContext context)
        {
            _context = context;
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