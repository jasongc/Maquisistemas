using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VetAdminUTL
{
    public class EnLog
    {
        public EnLog(string sUsuario, string sEsquema, string sNameSpace, string sElemento, string? sMetodo, string sTipo, Exception ex, string vRutaLog)
        {
            Usuario = sUsuario;
            Esquema = sEsquema;
            NameSpace = sNameSpace;
            Elemento = sElemento;
            Metodo = sMetodo ?? String.Empty;
            Tipo = sTipo;
            Error = ex == null || string.IsNullOrEmpty(ex.StackTrace) ? string.Empty : ex.StackTrace;
            Mensaje = ex == null || string.IsNullOrEmpty(ex.Message) ? string.Empty : ex.Message;
            RutaLog = vRutaLog;
        }
        public string Usuario { get; set; }
        public string Esquema { get; set; }
        public string NameSpace { get; set; }
        public string Elemento { get; set; }
        public string Metodo { get; set; }
        public string Tipo { get; set; } = "ERROR";
        public string Error { get; set; }
        public string Mensaje { get; set; }
        [JsonIgnore]
        public string RutaLog { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;

    }
}
