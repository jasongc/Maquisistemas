using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VetAdminUTL;

namespace VetAdminEN.Utilitarios
{
    public class RespuestaEN
    {
        [JsonPropertyName("exito")]
        public bool bExito { get; set; }
        [JsonPropertyName("mensaje")]
        public string? vMensaje { get; set; }
        [JsonPropertyName("codigo_estado")]
        public HttpStatusCode siCodigoEstado { get; set; }

        public void Success(string stMensaje)
        {
            bExito = true;
            vMensaje = stMensaje;
            siCodigoEstado = HttpStatusCode.OK;
        }
        public void Error(Exception ex, HttpStatusCode httpStatusCode, EnLog enLog)
        {
            bExito = false;
            vMensaje = ex.Message;
            siCodigoEstado = httpStatusCode;
            Log log = new Log();
            log.Generar(enLog);
        }
    }
    public class RespuestaEN<T> : RespuestaEN, IRespuestaEN
    {
        [JsonPropertyName("resultado")]
        public T? oResultado { get; set; }
    }
    public interface IRespuestaEN
    {
        public bool bExito { get; set; }
        public string? vMensaje { get; set; }
        public HttpStatusCode siCodigoEstado { get; set; }
        abstract void Success(string stMensaje);
        abstract void Error(Exception ex, HttpStatusCode httpStatusCode, EnLog enLog);

    }
}
