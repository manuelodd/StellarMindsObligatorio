using Dominio.InterfacesRepositorio;
using DTOs;
using LogicaAccesoDatos.RepositorioMemoria;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebAPP.Controllers
{
    public class UsuarioController : Controller
    {


        private IAltaUsuario altaU;

        

        /*
        public UsuarioController(IRepositorioUsuario repo)
        {
            this.altaU = new AltaUsuarioCU(repo);
            this.repo = repo;
        }
        */
        public UsuarioController(IAltaUsuario altau)
        {
            this.altaU = altau;
            ;
        }




        // GET: UsuarioController1

        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController1/Create
        public ActionResult Create(UsuarioDTO unUsuario)
        {
            return View();
        }

        // POST: UsuarioController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsuarioController1/Edit/5
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
