
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Newtonsoft.Json;
using StellarMindsWebApp.AuxiliarViewmodel;
using StellarMindsWebAPP.Auxiliar;
using StellarMindsWebAPP.Enums;
using StellarMindsWebAPP.Models;

namespace StellarMindsWebAPP.Controllers
{
    public class EquipoController : Controller
    {

        private string baseUrl = "http://localhost:5077/api/Equipo";

        // GET: EquipoController/Create
        public IActionResult Index()
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl, HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string texto = HttpClientAuxiliar.ObtenerBody(respuesta);
                IEnumerable<EquipoModel> equipos = JsonConvert.DeserializeObject<IEnumerable<EquipoModel>>(texto);

                return View(equipos);
            }

            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            PrestamoAltaViewmodel vm = new PrestamoAltaViewmodel();

            //armo viewmodel consultando a todos los endpoints de get equiposespecificos
            HttpResponseMessage respuestaTel = HttpClientAuxiliar.EnviarSolicitud(baseUrl+"/telescopios", HttpVerbos.GET);
            if (respuestaTel.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuestaTel);
                vm.Telescopios =JsonConvert.DeserializeObject<List<TelescopioModel>>(json);
            }

            HttpResponseMessage respuestaMon = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/monturas", HttpVerbos.GET);
            if (respuestaMon.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuestaMon);
                vm.Monturas =JsonConvert.DeserializeObject<List<MonturaModel>>(json);
            }

            HttpResponseMessage respuestaCam =HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/camaras", HttpVerbos.GET);
            if (respuestaCam.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuestaCam);
                vm.Camaras = JsonConvert.DeserializeObject<List<CamaraModel>>(json);
            }

            HttpResponseMessage respuestaOcu = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/oculares", HttpVerbos.GET);
            if (respuestaOcu.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuestaOcu);
                vm.Oculares = JsonConvert.DeserializeObject<List<OcularModel>>(json);
            }

            //si me da tiempo cambiar endpoint para que solo liste socios mamita querida
            HttpResponseMessage respuestaUsu = HttpClientAuxiliar.EnviarSolicitud("http://localhost:5077/api/Usuario", HttpVerbos.GET);
            if (respuestaUsu.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuestaUsu);
                vm.Usuarios = JsonConvert.DeserializeObject<List<UsuarioModel>>(json);
            }

            return View(vm);
        }


        public IActionResult Details(int id)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud($"{baseUrl}/{id}", HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                EquipoModel equipo = JsonConvert.DeserializeObject<EquipoModel>(json);
                return View(equipo);
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            /*
            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = cliente.DeleteAsync($"{baseUrl}/{id}").Result;
            */
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud($"{baseUrl}/{id}", HttpVerbos.DELETE);

            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = respuesta.Content.ReadAsStringAsync().Result;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult<TelescopioModel> CreateTelescopio(TelescopioModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/telescopios", HttpVerbos.POST,model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Create");
        }

        [HttpPost]
        public ActionResult<MonturaModel> CreateMontura(MonturaModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/monturas", HttpVerbos.POST, model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            } 
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Create");
        }

        [HttpPost]
        public ActionResult<CamaraModel> CreateCamara(CamaraModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/camaras", HttpVerbos.POST, model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Create");
        }

        [HttpPost]
        public ActionResult<OcularModel> CreateOcular(OcularModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/oculares", HttpVerbos.POST, model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Create");
        }

        [HttpPost]
        public ActionResult<TelescopioModel> EditTelescopio(TelescopioModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/telescopios", HttpVerbos.PUT, model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult<MonturaModel> EditMontura(MonturaModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/monturas", HttpVerbos.PUT, model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult<CamaraModel> EditCamara(CamaraModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/camaras", HttpVerbos.PUT,model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult<OcularModel> EditOcular(OcularModel model)
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/oculares", HttpVerbos.PUT, model);
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = HttpClientAuxiliar.ObtenerBody(respuesta);
            return View("Edit", model);
        }

        public IActionResult ListSocioTele()
        {
            SociosPorTelescopioViewmodel vm = new SociosPorTelescopioViewmodel();

            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/telescopios", HttpVerbos.GET);
            if (respuesta.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuesta);
                vm.Telescopios = JsonConvert.DeserializeObject<List<TelescopioModel>>(json);
            }

            vm.Socios = new List<UsuarioModel>();
            return View(vm);
        }


        [HttpPost]
        public IActionResult ListSocioTele(int telescopioId)
        {
            SociosPorTelescopioViewmodel vm = new SociosPorTelescopioViewmodel();

            HttpResponseMessage respuestaTel = HttpClientAuxiliar.EnviarSolicitud(baseUrl + "/telescopios", HttpVerbos.GET);

            if (respuestaTel.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuestaTel);
                vm.Telescopios = JsonConvert.DeserializeObject<List<TelescopioModel>>(json);
            }

            HttpResponseMessage respuestaSocios = HttpClientAuxiliar.EnviarSolicitud($"{baseUrl}/{telescopioId}",HttpVerbos.GET);

            if (respuestaSocios.IsSuccessStatusCode)
            {
                string json = HttpClientAuxiliar.ObtenerBody(respuestaSocios); 
                vm.Socios = JsonConvert.DeserializeObject<List<UsuarioModel>>(json);
            }
            return View(vm);
        }
    }
}
