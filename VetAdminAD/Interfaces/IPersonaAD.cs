using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetAdminEN.Clases.Organizacion;

namespace VetAdminAD.Interfaces
{
    public interface IPersonaAD
    {
        public Task<int> Crear(PersonaEN poPersonaEN, int iAccion);
        public Task<PersonaEN> Obtener(int piIdPersona);
        public Task<List<PersonaEN>> Listar(int piIdPersona = 0);
    }
}
