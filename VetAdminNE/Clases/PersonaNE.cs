using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VetAdminAD.Interfaces;
using VetAdminEN.Clases.Organizacion;
using VetAdminEN.Utilitarios;
using VetAdminNE.Interfaces;
using VetAdminUTL;

namespace VetAdminNE.Clases
{
    public class PersonaNE : IPersonaNE
    {
        protected readonly IPersonaAD _personaAD;
        protected readonly string _rutaBaseLog;
        public PersonaNE(IPersonaAD personaAD, IConfiguration configuration)
        {
            _personaAD = personaAD;
            _rutaBaseLog = configuration.GetSection("Carpetas:RutaLog").Value.ToString();
        }
        
        public async Task<RespuestaEN<int>> Crear(PersonaEN poPersonaEN, int iAccion)
        {
            RespuestaEN<int> respuestaEN = new RespuestaEN<int>();
            try
            {
                respuestaEN.oResultado = await _personaAD.Crear(poPersonaEN, iAccion);
                respuestaEN.Success("Se registraron los datos correctamente.");
                return respuestaEN;
            }
            catch (Exception ex)
            {

                EnLog enLog = new EnLog("jjgutierrez", "Enkuentra.Clases", "EnkuentraNE.Clases.PublicacionNE", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "ERROR", ex, _rutaBaseLog);
                respuestaEN.Error(ex, HttpStatusCode.InternalServerError, enLog);
                throw;
            }
        }
        public async Task<RespuestaEN<List<PersonaEN>>> Listar()
        {
            RespuestaEN<List<PersonaEN>> respuestaEN = new RespuestaEN<List<PersonaEN>>();
            try
            {
                respuestaEN.oResultado = await _personaAD.Listar();
                respuestaEN.Success("Se obtuvieron los datos correctamente.");
                return respuestaEN;
            }
            catch (Exception ex)
            {
                EnLog enLog = new EnLog("jjgutierrez", "Enkuentra.Clases", "EnkuentraNE.Clases.PublicacionNE", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "ERROR", ex, _rutaBaseLog);
                respuestaEN.Error(ex, HttpStatusCode.InternalServerError, enLog);
                throw;
            }
        }
        public async Task<RespuestaEN<PersonaEN>> Obtener(int piIdPersona)
        {
            RespuestaEN<PersonaEN> respuestaEN = new RespuestaEN<PersonaEN>();
            try
            {
                respuestaEN.oResultado = await _personaAD.Obtener(piIdPersona);
                respuestaEN.Success("Se obtuvieron los datos correctamente.");
                return respuestaEN;
            }
            catch (Exception ex)
            {
                EnLog enLog = new EnLog("jjgutierrez", "Enkuentra.Clases", "EnkuentraNE.Clases.PublicacionNE", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "ERROR", ex, _rutaBaseLog);
                respuestaEN.Error(ex, HttpStatusCode.InternalServerError, enLog);
                throw;
            }
        }
    }
}
