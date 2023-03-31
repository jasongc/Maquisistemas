using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetAdminEN.Clases.Organizacion;
using VetAdminEN.Utilitarios;

namespace VetAdminNE.Interfaces
{
    public interface IPersonaNE
    {
        public Task<RespuestaEN<int>> Crear(PersonaEN poPersonaEN, int iAccion);
        public Task<RespuestaEN<List<PersonaEN>>> Listar();
        public Task<RespuestaEN<PersonaEN>> Obtener(int piIdPersona);
    }
}
