using DTOs.AuxiliarViewmodel;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebAPP.Controllers
{
    public class ObservacionController : BaseController
    {

        private IListarPrestamosSocio listarPrestamosSocioCU;
        private IListarObjetosCelestes listarObjetosCelestesCU;
        private IAltaObservacion altaObservacionCU;
        private IRankObjetosCelestes rankObjetosCelestesCU;

        public ObservacionController(IListarPrestamosSocio listPresSocioCu,
                                     IListarObjetosCelestes listarObjetosCelestesCu,
                                     IRankObjetosCelestes rankObjetosCelestesCu,
                                     IAltaObservacion altaObservacionCu)
        {
            this.listarPrestamosSocioCU = listPresSocioCu;
            this.listarObjetosCelestesCU = listarObjetosCelestesCu;
            this.altaObservacionCU = altaObservacionCu;
            this.rankObjetosCelestesCU = rankObjetosCelestesCu;
        }


        // GET: ObservacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ObservacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult RankingObjetosCelestes()
        {
            List<RankObjetosCelestesDTO> listado = rankObjetosCelestesCU.Execute();
            return View(listado);
        }

        // GET: ObservacionController/Create
        public ActionResult Create()
        {
            ObservacionAltaViewmodel vm = new ObservacionAltaViewmodel();
            vm.Prestamos = listarPrestamosSocioCU.Execute(idLogeado());
            vm.ObjetosCelestes = listarObjetosCelestesCU.Execute();
            return View(vm);
        }

        // POST: ObservacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ObservacionDTO dto)
        {
            altaObservacionCU.Execute(dto);
            return RedirectToAction("Index", "Usuario");
        }

        // GET: ObservacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ObservacionController/Edit/5
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

        // GET: ObservacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ObservacionController/Delete/5
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
