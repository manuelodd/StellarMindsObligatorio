using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson; //opcional
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;//opcional
using NuGet.Protocol.Plugins;
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
                baseUrl, Enums.HttpVerbos.GET, null, tokenSesion());


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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password, string username)
        {
            LoginModel usuario = new LoginModel();
            usuario.Password = password;
            usuario.Username = username;
            

            HttpResponseMessage respuesta = HttpClientAuxiliar.EnviarSolicitud(
                baseUrl + "/login", HttpVerbos.POST, usuario);
            if (respuesta.IsSuccessStatusCode)
            {
                string jsonResponse = HttpClientAuxiliar.ObtenerBody(respuesta);
                //LoginModel login = JsonConvert.DeserializeObject<LoginModel>(jsonResponse);
                LoginModelRespuesta respuestaLogin =
                            JsonConvert.DeserializeObject<LoginModelRespuesta>(jsonResponse);

                HttpContext.Session.SetInt32("id", respuestaLogin.Usuario.Id);
                HttpContext.Session.SetString("username", respuestaLogin.Usuario.Username);
                HttpContext.Session.SetString("rol", respuestaLogin.Usuario.Rol);
                HttpContext.Session.SetString("token", respuestaLogin.Token);
                return RedirectToAction("Index");
            }
            string error = HttpClientAuxiliar.ObtenerBody(respuesta);
            ViewBag.Error = error;

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
