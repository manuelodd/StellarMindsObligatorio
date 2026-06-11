using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StellarMindsWebAPP.Auxiliar;
using StellarMindsWebAPP.Models;
using System.Buffers.Text;

namespace StellarMindsWebAPP.Controllers
{
    public class ObjetoCelesteController : BaseController
    {
        private string baseUrl = "http://localhost:5077/api/ObjetoCeleste";

        [HttpGet]
        public IActionResult Index()
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl, Enums.HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string objetoFormatoTexto = HttpClientAuxiliar.ObtenerBody(respuesta);
                IEnumerable<ObjetoCelesteModel> objetos = JsonConvert.DeserializeObject<IEnumerable<ObjetoCelesteModel>>(objetoFormatoTexto);
                return View(objetos);
            }
            return View();
        }
    }
}
