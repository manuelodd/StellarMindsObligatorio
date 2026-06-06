using Dominio.InterfacesRepositorio;
using DTOs.AuxiliarViewmodel;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebAPP.Controllers
{
    public class AuditoriaPrestamoController : BaseController
    {
        private IListarAuditoriasPrestamo listAllAudisCU;
        private IListarCoordinadores listAllCoordinadoresCU;
        private IListarAuditoriasByCoordinador listAllAudisByCoordinadorCU;
        private IFindAuditoriaById findAuditoriaByIdCU;


        public AuditoriaPrestamoController  (IListarAuditoriasPrestamo listAllAudisCu, 
                                            IListarCoordinadores listAllCoordinadoresCu,
                                            IListarAuditoriasByCoordinador listAllAudisByCoordinadorCu,
                                            IFindAuditoriaById findAuditoriaByIdCu)
        {
            this.listAllAudisCU = listAllAudisCu;
            this.listAllCoordinadoresCU = listAllCoordinadoresCu;
            this.listAllAudisByCoordinadorCU = listAllAudisByCoordinadorCu;
            this.findAuditoriaByIdCU = findAuditoriaByIdCu;
        }


        // GET: AuditoriaController
        public ActionResult Index()
        {
            List<AuditoriaPrestamoDTO> lista = listAllAudisCU.Execute();
            return View(lista);
        }

        public IActionResult FilterByCoordinador()
        {
            ListarAuditoriasPorCoordinadorViewmodel vm = new ListarAuditoriasPorCoordinadorViewmodel();
            vm.Coordinadores = listAllCoordinadoresCU.Execute();
            return View(vm);
        }

        [HttpPost]
        public IActionResult FilterByCoordinador(int coordinadorId)
        {
            ListarAuditoriasPorCoordinadorViewmodel vm = new ListarAuditoriasPorCoordinadorViewmodel();
            vm.Coordinadores = listAllCoordinadoresCU.Execute();
            vm.Auditorias = listAllAudisByCoordinadorCU.Execute(coordinadorId);
            return View(vm);
        }

        // GET: AuditoriaController/Details/5
        public ActionResult Details(int id)
        {
            AuditoriaPrestamoDTO audi = findAuditoriaByIdCU.Execute(id);
            return View(audi);
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
