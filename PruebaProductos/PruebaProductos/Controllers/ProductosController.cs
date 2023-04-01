using Entidades;
using Entidades.Clases;
using Entidades.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        protected readonly IProductoNEG _productoNEG;
        public ProductosController(IProductoNEG productoNEG)
        {
            _productoNEG = productoNEG;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public ActionResult<RespuestaENT<List<ProductoENT>>> Get()
        {
            RespuestaENT<List<ProductoENT>> respuestaENT = new RespuestaENT<List<ProductoENT>>();
            try
            {
                respuestaENT.Resultado = _productoNEG.Get();
                respuestaENT.Success("Se listó correctamente");
                return Ok(respuestaENT);
            }
            catch (Exception ex)
            {
                respuestaENT.Error(ex);
                return BadRequest(respuestaENT);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("GetById/{id}")]
        public ActionResult<RespuestaENT<ProductoENT>> GetById(int id)
        {
            RespuestaENT<ProductoENT> respuestaENT = new RespuestaENT<ProductoENT>();
            try
            {
                respuestaENT.Resultado = _productoNEG.GetById(id);
                respuestaENT.Success("Se obtuvo correctamente el producto");
                return Ok(respuestaENT);
            }
            catch (Exception ex)
            {
                respuestaENT.Error(ex);
                return BadRequest(respuestaENT);
            }
            
        }

        // POST api/<ProductosController>
        [HttpPost]
        public ActionResult<RespuestaENT> Insert([FromBody] ProductoENT productoENT)
        {
            RespuestaENT<int> respuestaENT = new RespuestaENT<int>();
            try
            {
                respuestaENT.Resultado = _productoNEG.Insert(productoENT);
                respuestaENT.Success("Se registró correctamente el producto");
                return CreatedAtAction(nameof(Insert), respuestaENT);
            }
            catch (Exception ex)
            {
                respuestaENT.Error(ex);
                return BadRequest(respuestaENT);
            }

        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public ActionResult<RespuestaENT> Update(int id, [FromBody] ProductoENT productoENT)
        {
            RespuestaENT respuestaENT = new RespuestaENT();
            try
            {
                productoENT.InternalProductId = id;
                _productoNEG.Insert(productoENT);
                respuestaENT.Success("Se actualizó correctamente el producto.");
                return Ok(respuestaENT);
            }
            catch (Exception ex)
            {
                respuestaENT.Error(ex);
                return BadRequest(respuestaENT);
            }
        }

    }
}
