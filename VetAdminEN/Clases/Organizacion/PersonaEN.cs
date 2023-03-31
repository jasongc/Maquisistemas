using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetAdminEN.Clases.Organizacion
{
    public class PersonaEN
    {
		public int iIdPersona { get; set; }
		public string sNombres { get; set; } = string.Empty;
		public string sApellidoPaterno { get; set; } = string.Empty;
		public string sApellidoMaterno { get; set; } = string.Empty;
		public short siTipoDocumento { get; set; }
		public string sNumeroDocumento { get; set; } = string.Empty;
		public string sEmail { get; set; } = string.Empty;
		public string sUbigeo { get; set; } = string.Empty;
		public DateTime dFechaNacimiento { get; set; }
		public string sDireccion { get; set; } = string.Empty;
		public string sCelular { get; set; } = string.Empty;
		public short siEstado { get; set; }
		public DateTime dtFechaCrea { get; set; }
		public int iIdUsuarioCrea { get; set; }
		public DateTime dtFechaActualiza { get; set; }
		public int iIdUsuarioActualiza { get; set; }
	}
}
