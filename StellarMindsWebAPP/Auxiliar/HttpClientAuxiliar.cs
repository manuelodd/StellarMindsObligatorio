using StellarMindsWebAPP.Enums;

namespace StellarMindsWebAPP.Auxiliar
{
    public class HttpClientAuxiliar
    {
        public static HttpResponseMessage EnviarSolicitud(string url, HttpVerbos verbo, object obj = null)
        {
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> tarea = null;

            switch (verbo)
            {
                case HttpVerbos.GET:
                    tarea = cliente.GetAsync(url);
                    break;
                case HttpVerbos.POST:
                    tarea = cliente.PostAsJsonAsync(url, obj);
                    break;
                default:
                    throw new Exception("VERBO INVALIDO");
            }

            tarea.Wait();
            return tarea.Result;
        }

        public static string ObtenerBody(HttpResponseMessage respuesta)
        {
            HttpContent body = respuesta.Content;
            Task<string> tarea = body.ReadAsStringAsync();
            tarea.Wait();
            return tarea.Result;
        }
    }
}
