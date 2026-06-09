using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using StellarMindsWebApp.AuxiliarViewmodel;
using StellarMindsWebAPP.Auxiliar;
using StellarMindsWebAPP.Enums;
using StellarMindsWebAPP.Models;
using System.Buffers.Text;

namespace StellarMindsWebAPP.Controllers
{
    public class PrestamoController : BaseController
    {
        private string baseUrl = "http://localhost:5077/api/Usuario";

        public IActionResult Create()
        {
            PrestamoAltaViewmodel vm = new PrestamoAltaViewmodel();
            HttpResponseMessage rTel = HttpClientAuxiliar.EnviarSolicitud("https://localhost:5077/api/Telescopio",HttpVerbos.GET);

            if (rTel.IsSuccessStatusCode)
            {
                string texto = HttpClientAuxiliar.ObtenerBody(rTel);
                vm.Telescopios =JsonConvert.DeserializeObject<List<TelescopioModel>>(texto);
            }

            // repetir para monturas
            // repetir para camaras
            // repetir para oculares
            // repetir para usuarios

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PrestamoModel model)
        {
            string url = $"{baseUrl}?coordinadorId={idLogeado()}";

            HttpResponseMessage respuesta =HttpClientAuxiliar.EnviarSolicitud(url,HttpVerbos.POST,model);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View(model);
        }

        // GET: PrestamoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestamoController/Edit/5
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

        // GET: PrestamoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestamoController/Delete/5
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
