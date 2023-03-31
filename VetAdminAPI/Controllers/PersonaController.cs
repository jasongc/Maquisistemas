using Microsoft.AspNetCore.Mvc;
using VetAdminEN.Clases.Organizacion;
using VetAdminEN.Utilitarios;
using VetAdminNE.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VetAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        readonly IPersonaNE _personaNE;
        public PersonaController(IPersonaNE personaNE)
        {
            _personaNE = personaNE;
        }

        [HttpGet("Listar")]
        public async Task<RespuestaEN<List<PersonaEN>>> Listar()
        {
            return await _personaNE.Listar();
        }

        [HttpGet("Obtener")]
        public async Task<RespuestaEN<PersonaEN>> Obtener(int piIdPersona)
        {
            return await _personaNE.Obtener(piIdPersona);
        }

        [HttpPost("Crear")]
        public async Task<RespuestaEN<int>> Crear([FromBody] PersonaEN poPersonaEN, int iAccion)
        {
            return await _personaNE.Crear(poPersonaEN, iAccion);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
