using System.Net;
using System.Text.Json.Serialization;

namespace Entidades.Utilitarios
{
    public class RespuestaENT
    {
        private static RespuestaENT instance = null;

        [JsonPropertyName("exito")]
        public bool bExito { get; set; }
        [JsonPropertyName("mensaje")]
        public string? vMensaje { get; set; }
        [JsonPropertyName("codigo_estado")]
        public HttpStatusCode siCodigoEstado { get; set; }

        public void Success(string stMensaje, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            bExito = true;
            vMensaje = stMensaje;
            siCodigoEstado = httpStatusCode;
        }
        public void Error(Exception ex, HttpStatusCode httpStatusCode)
        {
            bExito = false;
            vMensaje = ex.Message;
            siCodigoEstado = httpStatusCode;
            //Log log = new Log();
            //log.Generar(enLog);
        }

        public static RespuestaENT Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RespuestaENT();
                }
                return instance;
            }
        }
    }
    public class RespuestaENT<T> : RespuestaENT, IRespuestaENT
    {
        [JsonPropertyName("resultado")]
        public T? oResultado { get; set; }
    }
    public interface IRespuestaENT
    {
        public bool bExito { get; set; }
        public string? vMensaje { get; set; }
        public HttpStatusCode siCodigoEstado { get; set; }
        abstract void Success(string stMensaje, HttpStatusCode httpStatusCode);
        abstract void Error(Exception ex, HttpStatusCode httpStatusCode);

    }
}