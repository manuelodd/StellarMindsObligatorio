using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson; //opcional
using Newtonsoft.Json;//opcional
using System.Threading.Tasks;
using StellarMindsWebAPP.Models;
using StellarMinds.Enums;
using System.Text;
using StellarMindsWebAPP.Auxiliar;


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
