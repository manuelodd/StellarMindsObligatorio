using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebAPP.Controllers
{
    public class AuditoriaController : BaseController
    {
        private IListarAuditoriasPrestamo listAllAudisCU;

        public AuditoriaController(IListarAuditoriasPrestamo listAllAudisCu)
        {
            this.listAllAudisCU = listAllAudisCU;
        }


        // GET: AuditoriaController
        public ActionResult Index()
        {

            return View(listAllAudisCU);
        }

        // GET: AuditoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuditoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuditoriaController/Create
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

        // GET: AuditoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuditoriaController/Edit/5
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

        // GET: AuditoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuditoriaController/Delete/5
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
