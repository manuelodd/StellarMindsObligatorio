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
        private string baseUrl = "http://localhost:5077/api/Prestamo";
        private string equipoUrl = "http://localhost:5077/api/Equipo";
        private string usuarioUrl = "http://localhost:5077/api/Usuario";

        public IActionResult Index()
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl, HttpVerbos.GET);
            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                List<PrestamoModel> lista = JsonConvert.DeserializeObject<List<PrestamoModel>>(json);
                return View(lista);
            }

            return View(new List<PrestamoModel>());
        }

        [HttpPost]
        public IActionResult ListDate(int mes, int anio)
        {
            int socioId = HttpContext.Session.GetInt32("id").Value;

            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud($"" +
                $"{baseUrl}/entre-fechas?socioId={socioId}&mes={mes}&anio={anio}",HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                List<PrestamoModel> lista =JsonConvert.DeserializeObject<List<PrestamoModel>>(json);
                return View(lista);
            }

            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View(new List<PrestamoModel>());
        }

        public IActionResult Details(int id)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud($"{baseUrl}/{id}", HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                PrestamoModel prestamo = JsonConvert.DeserializeObject<PrestamoModel>(json);
                return View(prestamo);
            }

            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View();
        }


        public IActionResult Create()
        {
            PrestamoAltaViewmodel vm = new PrestamoAltaViewmodel();

            // cargando el viewmodel
            HttpResponseMessage tel = HttpClientAuxiliar.EnviarSolicitud(equipoUrl+"/telescopios", HttpVerbos.GET);
            if (tel.IsSuccessStatusCode)
            {
                vm.Telescopios = JsonConvert.DeserializeObject<List<TelescopioModel>>(HttpClientAuxiliar.ObtenerBody(tel));
            }

            HttpResponseMessage mon = HttpClientAuxiliar.EnviarSolicitud(equipoUrl + "/telescopios", HttpVerbos.GET);
            if (mon.IsSuccessStatusCode)
            {
                vm.Monturas = JsonConvert.DeserializeObject<List<MonturaModel>>(HttpClientAuxiliar.ObtenerBody(mon));
            }

            HttpResponseMessage cam = HttpClientAuxiliar.EnviarSolicitud(equipoUrl + "/telescopios",HttpVerbos.GET);
            if (cam.IsSuccessStatusCode)
            {
                vm.Camaras = JsonConvert.DeserializeObject<List<CamaraModel>>(HttpClientAuxiliar.ObtenerBody(cam));
            }

            HttpResponseMessage ocu = HttpClientAuxiliar.EnviarSolicitud(equipoUrl + "/telescopios", HttpVerbos.GET);
            if (ocu.IsSuccessStatusCode)
            {
                vm.Oculares = JsonConvert.DeserializeObject<List<OcularModel>>(HttpClientAuxiliar.ObtenerBody(ocu));
            }

            HttpResponseMessage usu = HttpClientAuxiliar.EnviarSolicitud(equipoUrl + "/telescopios", HttpVerbos.GET);
            if (usu.IsSuccessStatusCode)
            {
                vm.Usuarios = JsonConvert.DeserializeObject<List<UsuarioModel>>(HttpClientAuxiliar.ObtenerBody(usu));
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PrestamoModel model)
        {
            string url = $"{baseUrl}?coordinadorId={idLogeado()}";

            HttpResponseMessage respuesta =HttpClientAuxiliar.EnviarSolicitud(url, HttpVerbos.POST,model);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View(model);
        }

        public IActionResult Return()
        {
            PrestamoDevolucionViewmodel vm = new PrestamoDevolucionViewmodel();

            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(usuarioUrl, HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                vm.Socios = JsonConvert.DeserializeObject<List<UsuarioModel>>(HttpClientAuxiliar.ObtenerBody(respuesta));
            }

            vm.Prestamos = new List<PrestamoModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Return(int socioid)
        {
            PrestamoDevolucionViewmodel vm = new PrestamoDevolucionViewmodel();

            HttpResponseMessage usuarios = HttpClientAuxiliar.EnviarSolicitud(usuarioUrl, HttpVerbos.GET);
            if (usuarios.IsSuccessStatusCode)
            {
                vm.Socios = JsonConvert.DeserializeObject<List<UsuarioModel>>(HttpClientAuxiliar.ObtenerBody(usuarios));
            }

            HttpResponseMessage prestamos = HttpClientAuxiliar.EnviarSolicitud($"{baseUrl}/socio/{socioid}",HttpVerbos.GET);
            if (prestamos.IsSuccessStatusCode)
            {
                vm.Prestamos = JsonConvert.DeserializeObject<List<PrestamoModel>>(HttpClientAuxiliar.ObtenerBody(prestamos));
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Return4Real(int prestamoid)
        {
            int coordinadorId = idLogeado();

            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(
                    $"{baseUrl}/devolver/{prestamoid}?coordinadorId={coordinadorId}",
                    HttpVerbos.PUT);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return RedirectToAction(nameof(Return));
        }

        /*
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
        */
    }
}
