using Dominio.Exceptions;
using DTOs.AuxiliarViewmodel;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StellarMinds.Entities;

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
        private IReturnPrestamo returnCU;
        private IListarUsuarios listarUsuariosCU;
        private IListarPrestamosSocio listarPrestamosSocioCU;
        private IListarPrestamosSocioEntreFechas listarPrestamosSocioEntreFechasCU;
        private IFindPrestamoById findPrestamoByIdCU;

        private IFindUsuById findUsuByID;


        public PrestamoController(IAltaPrestamo altaCu,
                                    IListarPrestamos listarPrestamosCu,
                                    IListarTelescopios findAllTelCu,
                                    IListarMonturas findAllMonCu,
                                    IListarCamaras findAllCamCu,
                                    IListarOculares findAllOcuCu,
                                    IReturnPrestamo returnCu,
                                    IListarUsuarios listarUsuariosCu,
                                    IListarPrestamosSocio listarPrestamosSocioCu,
                                    IFindUsuById findUsuById,
                                    IListarPrestamosSocioEntreFechas listarPrestamosSocioEntreFechasCu,
                                    IFindPrestamoById findPrestamoByIdCu
            
                                    )
        {
            this.altaCU = altaCu;
            this.listarPrestamosCU = listarPrestamosCu;
            this.findAllTelCU = findAllTelCu;
            this.findAllMonCU = findAllMonCu;
            this.findAllCamCU = findAllCamCu;
            this.findAllOcuCU = findAllOcuCu;
            this.returnCU = returnCu;
            this.listarUsuariosCU = listarUsuariosCu;
            this.listarPrestamosSocioCU = listarPrestamosSocioCu;
            this.findUsuByID = findUsuById;
            this.listarPrestamosSocioEntreFechasCU = listarPrestamosSocioEntreFechasCu;
            this.findPrestamoByIdCU = findPrestamoByIdCu;
        }
        public ActionResult Index()
        {
            List<PrestamoDTO> lista = listarPrestamosCU.Execute();
            return View(lista);
        }

        public ActionResult ListDate()
        {
            return View(new List<PrestamoDTO>());
        }

        [HttpPost]
        public ActionResult ListDate(int mes, int anio)
        {
            List<PrestamoDTO> lista = listarPrestamosSocioEntreFechasCU.Execute(idLogeado(), mes, anio);
            return View(lista);
        }

        // GET: PrestamoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(findPrestamoByIdCU.Execute(id));
            }
            catch (EntityNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: PrestamoController/Create
        public ActionResult Create()
        {
            PrestamoAltaViewmodel vm = new PrestamoAltaViewmodel();
            vm.Telescopios = findAllTelCU.Execute();
            vm.Monturas = findAllMonCU.Execute();
            vm.Camaras = findAllCamCU.Execute();
            vm.Oculares = findAllOcuCU.Execute();
            vm.Usuarios = listarUsuariosCU.Execute();
            return View(vm);
        }

        // POST: PrestamoController/Create
        [HttpPost]
        public ActionResult Create(PrestamoDTO dto)
        {
            try
            {
                altaCU.Execute(dto, idLogeado());
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidPrestamoException ex)
            {
                //creo denuevo el vm para retener los datos
                PrestamoAltaViewmodel vm = new PrestamoAltaViewmodel();

                vm.Telescopios = findAllTelCU.Execute();
                vm.Monturas = findAllMonCU.Execute();
                vm.Camaras = findAllCamCU.Execute();
                vm.Oculares = findAllOcuCU.Execute();
                vm.Usuarios = listarUsuariosCU.Execute();

                ViewBag.Error = ex.Message;

                return View(vm);
            }
        }

        /*
        public ActionResult Return(int id)
        {
            returnCU.Execute(id);
            return RedirectToAction(nameof(Index));
        }
        */
        public IActionResult Return()
        {
            PrestamoDevolucionViewmodel vm = new PrestamoDevolucionViewmodel();

            vm.Socios = listarUsuariosCU.Execute();
            vm.Prestamos = new List<PrestamoDTO>();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Return(int socioid)
        {
            PrestamoDevolucionViewmodel vm = new PrestamoDevolucionViewmodel();
            vm.Socios = listarUsuariosCU.Execute();
            vm.Prestamos = listarPrestamosSocioCU.Execute(socioid);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Return4Real(int prestamoid)
        {
            try
            {
                returnCU.Execute(prestamoid, idLogeado());
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidPrestamoException ex)
            {
                ViewBag.Error = ex.Message;

                PrestamoDevolucionViewmodel vm = new PrestamoDevolucionViewmodel();
                vm.Socios = listarUsuariosCU.Execute();
                vm.Prestamos = new List<PrestamoDTO>();

                return View("Return", vm);
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
