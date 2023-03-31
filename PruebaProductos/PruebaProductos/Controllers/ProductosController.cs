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
        public RespuestaENT<List<ProductoENT>> Get()
        {

            return new RespuestaENT<List<ProductoENT>>();
        }

        // GET api/<ProductosController>/5
        [HttpGet("GetById/{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Insert([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        //// DELETE api/<ProductosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
