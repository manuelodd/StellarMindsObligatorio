using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using StellarMinds.Entities;

namespace StellarMindsWebAPP.Controllers
{
    public class UsuarioController : Controller
    {

        private ILoginUsuario loginU;
        private IAltaUsuario altaCU;
        private IListarUsuarios findAllCU;

        /*
        public UsuarioController(IRepositorioUsuario repo)
        {
            this.altaU = new AltaUsuarioCU(repo);
            this.repo = repo;
        }
        */
        public UsuarioController(ILoginUsuario loginu, IAltaUsuario altau, IListarUsuarios findAllCu)
        {
            this.loginU = loginu;
            this.altaCU = altau;
            this.findAllCU = findAllCu;
            
        }




        // GET: UsuarioController1

        public ActionResult Index()
        {
            return View(findAllCU.Execute());
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

                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
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
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        // GET: UsuarioController1/Create
        public ActionResult Create(UsuarioDTO dto)
        {
            try
            {

                altaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController1/Delete/5
        public ActionResult Delete(int id)
        {
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
