
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StellarMindsWebApp.AuxiliarViewmodel;
using StellarMindsWebAPP.Auxiliar;
using StellarMindsWebAPP.Enums;
using StellarMindsWebAPP.Models;

namespace StellarMindsWebAPP.Controllers
{

    public class AuditoriaPrestamoController : BaseController
    {
        private string baseUrl = "http://localhost:5077/api/AuditoriaPrestamo";

        public IActionResult Index()
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl, HttpVerbos.GET, null, tokenSesion());

            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta); 
                List<AuditoriaPrestamoModel> lista = JsonConvert.DeserializeObject<List<AuditoriaPrestamoModel>>(json);
                return View(lista);
            }
            return View(new List<AuditoriaPrestamoModel>());
        }

        public IActionResult FilterByCoordinador()
        {
            ListarAuditoriasPorCoordinadorViewmodel vm = new ListarAuditoriasPorCoordinadorViewmodel();

            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/coordinadores", HttpVerbos.GET, null, tokenSesion());
            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                vm.Coordinadores = JsonConvert.DeserializeObject<List<UsuarioModel>>(json);
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult FilterByCoordinador(int coordinadorId)
        {
            ListarAuditoriasPorCoordinadorViewmodel vm = new ListarAuditoriasPorCoordinadorViewmodel();

            HttpResponseMessage respuestaCoords = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/coordinadores",HttpVerbos.GET, null, tokenSesion());
            if (respuestaCoords.IsSuccessStatusCode)
            {
                string jsonCoords = HttpClientAuxiliar.ObtenerBody(respuestaCoords);
                vm.Coordinadores = JsonConvert.DeserializeObject<List<UsuarioModel>>(jsonCoords);
            }

            HttpResponseMessage respuestaAudis = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/coordinador/" + coordinadorId, HttpVerbos.GET, null, tokenSesion());
            if (respuestaAudis.IsSuccessStatusCode)
            {
                string jsonAudis = HttpClientAuxiliar.ObtenerBody(respuestaAudis);
                vm.Auditorias = JsonConvert.DeserializeObject<List<AuditoriaPrestamoModel>>(jsonAudis);
            }
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/" + id, HttpVerbos.GET);
            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                AuditoriaPrestamoModel auditoria = JsonConvert.DeserializeObject<AuditoriaPrestamoModel>(json);
                return View(auditoria);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
