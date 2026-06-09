using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using Humanizer;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using StellarMinds.Entities;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson; //opcional
using Newtonsoft.Json;//opcional
using System.Threading.Tasks;
using StellarMindsWebAPP.Models;


namespace StellarMindsWebAPP.Controllers
{
    public class UsuarioController : BaseController
    {


        private HttpClient _client = new HttpClient();

        public UsuarioController()
        {
            _client.BaseAddress =
                new Uri("http://localhost:5077/api/Usuario");

            _client.DefaultRequestHeaders.Accept.Clear();

            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }



        // GET: UsuarioController1

        public IActionResult Index()
        {
            HttpResponseMessage respuesta = _client.GetAsync("").Result;

            if (respuesta.IsSuccessStatusCode)
            {
                string json = respuesta.Content.ReadAsStringAsync().Result;
                IEnumerable<UsuarioModel> usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioModel>>(json);
                return View(usuarios);
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                Usuario usuario = loginU.Execute(username, password);

                // guardado de sesion de P2
                HttpContext.Session.SetString("username", usuario.Username);
                HttpContext.Session.SetString("rol", usuario.Rol.ToString());
                HttpContext.Session.SetInt32("id", usuario.Id);

                return RedirectToAction("Index", "Usuario");
            }
            catch (InvalidUserException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
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


        [HttpPost]
        // GET: UsuarioController1/Create
        public ActionResult Create(UsuarioDTO dto)
        {
            if (base.rolLogeado() != "ADMINISTRADOR")
            {
                return RedirectToAction("Index", "Usuario");
            }


            try
            {

                altaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidUserException ex)
            {
                ViewBag.Error = ex.Message;
                return View(dto);
            }

        }

        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: UsuarioController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            /*
 * try
{
modificarCU.Execute(dto);
return RedirectToAction(nameof(Index));
}
catch(InvalidUser ex)
{
ViewBag.Error = ex.Message;
return View(dto);
}
catch(EntityNotFoundException ex)
{
ViewBag.Error = ex.Message;
return View(dto);
}
 */
            return View();
        }

        // GET: UsuarioController1/Delete/5
        public ActionResult Delete(int id)
        {
            /*
             * try
{
    eliminarCU.Execute(id);
    return RedirectToAction(nameof(Index));
}
catch(EntityNotFoundException ex)
{
    ViewBag.Error = ex.Message;
    return View();
}
             */

            return View();
        }

        // POST: UsuarioController1/Delete/5
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
