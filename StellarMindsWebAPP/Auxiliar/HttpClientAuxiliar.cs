using Newtonsoft.Json;
using StellarMindsWebAPP.Enums;
using System.Text;

namespace StellarMindsWebAPP.Auxiliar
{
    public class HttpClientAuxiliar
    {
        public static HttpResponseMessage EnviarSolicitud(string url, HttpVerbos verbo, object obj = null)
        {
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> tarea = null;

            if (obj != null) 
            {
                string stringJson = JsonConvert.SerializeObject(obj);
                StringContent body = new StringContent(stringJson, Encoding.UTF8, "application/json");
            }

            switch (verbo)
            {
                case HttpVerbos.GET:
                    tarea = cliente.GetAsync(url);
                    break;
                case HttpVerbos.POST:
                    tarea = cliente.PostAsJsonAsync(url, obj);
                    break;
                case HttpVerbos.PUT:
                    tarea = cliente.PutAsJsonAsync(url, obj);
                    break;
                case HttpVerbos.DELETE:
                    tarea = cliente.DeleteAsync(url);
                    break;
                default:
                    throw new Exception("VERBO INVALIDO");
            }

            tarea.Wait(); // aca
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
