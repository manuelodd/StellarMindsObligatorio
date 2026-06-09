
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StellarMindsWebApp.AuxiliarViewmodel;
using StellarMindsWebAPP.Auxiliar;
using StellarMindsWebAPP.Enums;
using StellarMindsWebAPP.Models;

namespace StellarMindsWebAPP.Controllers
{
    public class ObservacionController : BaseController
    {

        private string baseUrl = "http://localhost:5077/api/Observacion";

        public IActionResult RankingObjetosCelestes()
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud($"{baseUrl}/ranking", HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                List<RankObjetosCelestesModel> listado = JsonConvert.DeserializeObject<List<RankObjetosCelestesModel>>(json);
                return View(listado);
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View(new List<RankObjetosCelestesModel>());
        }

        public IActionResult Create()
        {
            ObservacionAltaViewmodel vm = new ObservacionAltaViewmodel();

            int socioId = idLogeado();

            HttpResponseMessage prestamos = HttpClientAuxiliar.EnviarSolicitud($"http://localhost:5077/api/Prestamo/socio/{socioId}", HttpVerbos.GET);
            if (prestamos.IsSuccessStatusCode)
            {
                vm.Prestamos = JsonConvert.DeserializeObject<List<PrestamoModel>>(HttpClientAuxiliar.ObtenerBody(prestamos));
            }

            HttpResponseMessage objetos = HttpClientAuxiliar.EnviarSolicitud("http://localhost:5077/api/ObjetoCeleste", HttpVerbos.GET);
            if (objetos.IsSuccessStatusCode)
            {
                vm.ObjetosCelestes = JsonConvert.DeserializeObject<List<ObjetoCelesteModel>>(HttpClientAuxiliar.ObtenerBody(objetos));
            }

            return View(vm);
        }

        // GET: ObservacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: ObservacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ObservacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ObservacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ObservacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
