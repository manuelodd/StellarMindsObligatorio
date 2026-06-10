using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson; //opcional
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;//opcional
using StellarMinds.Enums;
using StellarMindsWebAPP.Auxiliar;
using StellarMindsWebAPP.Enums;
using StellarMindsWebAPP.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace StellarMindsWebAPP.Controllers
{
    public class UsuarioController : BaseController
    {

        private string baseUrl = "http://localhost:5077/api/Usuario";

        // GET: UsuarioController1
        [HttpGet]
        public IActionResult Index()
        {
            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(
                baseUrl, Enums.HttpVerbos.GET);

            if (respuesta.IsSuccessStatusCode)
            {
                string objetoFormatoTexto = HttpClientAuxiliar.ObtenerBody(respuesta);
                IEnumerable<UsuarioModel> usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioModel>>(objetoFormatoTexto);
                return View(usuarios);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new UsuarioModel());
        }

        [HttpPost]
        public ActionResult<UsuarioModel> Create(UsuarioModel model)
        {

            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(baseUrl, Enums.HttpVerbos.POST, model);

            if (respuesta.IsSuccessStatusCode)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            HttpResponseMessage respuesta =
                HttpClientAuxiliar.EnviarSolicitud(
                    $"{baseUrl}/login?username={username}&pass={password}",
                    HttpVerbos.POST);

            if (respuesta.IsSuccessStatusCode)
            {
                string json =
                    HttpClientAuxiliar.ObtenerBody(respuesta);

                UsuarioModel usuario =
                    JsonConvert.DeserializeObject<UsuarioModel>(json);

                HttpContext.Session.SetString("username", usuario.Username);
                HttpContext.Session.SetString("rol", usuario.Rol);
                HttpContext.Session.SetInt32("id", usuario.Id);

                return RedirectToAction("Index", "Usuario");
            }

            ViewBag.Error =
                HttpClientAuxiliar.ObtenerBody(respuesta);

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: UsuarioController1/Details/5
        public ActionResult Details(int id)
        {
            /*
            try
            {
                UsuarioDTO dto = detalleCU.Execute(id);
                return View(dto);
            }
            catch (EntityNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public ActionResult Create()
        {
            if (base.Rol() != "ADMINISTRADOR")
            {
                return RedirectToAction("Index", "Usuario");
            }
            */
            return View();
        }

    }
}
