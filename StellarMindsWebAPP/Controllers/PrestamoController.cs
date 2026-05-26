using Dominio.Exceptions;
using DTOs.AuxiliarViewmodel;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace StellarMindsWebAPP.Controllers
{
    public class PrestamoController : BaseController
    {
        private IAltaPrestamo altaCU;
        private IListarPrestamos listarPrestamosCU;
        private IListarTelescopios findAllTelCU;
        private IListarMonturas findAllMonCU;
        private IListarCamaras findAllCamCU;
        private IListarOculares findAllOcuCU;

        public PrestamoController   (IAltaPrestamo altaCu,
                                    IListarPrestamos listarPrestamosCu,
                                    IListarTelescopios findAllTelCu,
                                    IListarMonturas findAllMonCu,
                                    IListarCamaras findAllCamCu,
                                    IListarOculares findAllOcuCu
                                    )
        {
            this.altaCU = altaCu;
            this.listarPrestamosCU = listarPrestamosCu;
            this.findAllTelCU = findAllTelCu;
            this.findAllMonCU = findAllMonCu;
            this.findAllCamCU = findAllCamCu;
            this.findAllOcuCU = findAllOcuCu;
        }
        public ActionResult Index()
        {
            List<PrestamoDTO> lista = listarPrestamosCU.Execute();
            return View(lista);
        }

        // GET: PrestamoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestamoController/Create
        public ActionResult Create()
        {
            PrestamoAltaViewmodel vm = new PrestamoAltaViewmodel();
            vm.Telescopios = findAllTelCU.Execute();
            vm.Monturas = findAllMonCU.Execute();
            vm.Camaras = findAllCamCU.Execute();
            vm.Oculares = findAllOcuCU.Execute();
            return View(vm);
        }

        // POST: PrestamoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrestamoDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidPrestamo ex)
            {
                //creo denuevo el vm para retener los datos
                PrestamoAltaViewmodel vm = new PrestamoAltaViewmodel();

                vm.Telescopios = findAllTelCU.Execute();
                vm.Monturas = findAllMonCU.Execute();
                vm.Camaras = findAllCamCU.Execute();
                vm.Oculares = findAllOcuCU.Execute();

                ViewBag.Error = ex.Message;

                return View(vm);
            }
        }

        // GET: PrestamoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestamoController/Edit/5
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

        // GET: PrestamoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestamoController/Delete/5
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
