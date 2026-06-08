using Dominio.Exceptions;
using DTOs.AuxiliarViewmodel;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.CasosDeUso.CUEquipo;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace StellarMindsWebAPP.Controllers
{
    public class EquipoController : Controller
    {
        private IAltaEquipo altaCU;
        private IListarEquipos findAllCU;
        /*
        private IListarTelescopios findAllTelCU;
        private IListarMonturas findAllMonCU;
        private IListarCamaras findAllCamCU;
        private IListarOculares findAllOcuCU;
        */
        private IBuscarEquipoPorID buscarEquipoIDCU;
        private IEditarTelescopio editarTelescopioCU;
        private IEditarMontura editarMonturaCU;
        private IEditarCamara editarCamaraCU;
        private IEditarOcular editarOcularCU;
        private IDeleteEquipo deleteEquipoCU;
        private IListarTelescopiosToList listarTelescopiosToListCU;
        private IListarSociosByTelescopio listarSociosByTelescopioCU; 



        public EquipoController(IAltaEquipo altae, 
                                IListarEquipos findAllCu, 
                                IBuscarEquipoPorID buscarEquipoIDCu,
                                IEditarTelescopio editarTelescopioCu,
                                IEditarMontura editarMonturaCu,
                                IEditarCamara editarCamaraCu,
                                IEditarOcular editarOcularCu,
                                IDeleteEquipo deleteEquipoCu,
                                IListarTelescopiosToList listarTelescopiosToListCu,
                                IListarSociosByTelescopio listarSociosByTelescopioCu
                                /*
                                IListarTelescopios findAllTelCu,
                                IListarMonturas findAllMonCu,
                                IListarCamaras findAllCamCu,
                                IListarOculares findAllOcuCu*/)
        {
            this.altaCU = altae;
            this.findAllCU = findAllCu;
            /*
            this.findAllTelCU = findAllTelCu;
            this.findAllMonCU = findAllMonCu;
            this.findAllCamCU = findAllCamCu;
            this.findAllOcuCU = findAllOcuCu;
            */
            this.buscarEquipoIDCU = buscarEquipoIDCu;
            this.editarTelescopioCU = editarTelescopioCu;
            this.editarMonturaCU = editarMonturaCu;
            this.editarCamaraCU = editarCamaraCu;
            this.editarOcularCU = editarOcularCu;
            this.deleteEquipoCU = deleteEquipoCu;
            this.listarTelescopiosToListCU = listarTelescopiosToListCu;
            this.listarSociosByTelescopioCU = listarSociosByTelescopioCu;
            
        }

        // GET: EquipoController
        public IActionResult Index()
        {
            IEnumerable<EquipoDTO> listado = findAllCU.Execute();
            return View(listado);
        }

        public IActionResult ListSocioTele()
        {
            SociosPorTelescopioViewmodel vm = new SociosPorTelescopioViewmodel();

            vm.Telescopios = listarTelescopiosToListCU.Execute();
            vm.Socios = new List<UsuarioDTO>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult ListSocioTele(int telescopioId)
        {
            SociosPorTelescopioViewmodel vm = new SociosPorTelescopioViewmodel();

            vm.Telescopios = listarTelescopiosToListCU.Execute();
            vm.Socios = listarSociosByTelescopioCU.Execute(telescopioId);
            return View(vm);
        }

        // GET: EquipoController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                deleteEquipoCU.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                EquipoDTO equipo = buscarEquipoIDCU.Execute(id);
                return View(equipo);
            }
            catch (EntityNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                EquipoDTO equipo = buscarEquipoIDCU.Execute(id);
                return View(equipo);
            }
            catch (EntityNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - -  CREATES - - - - - - - - - - - - - - - - - -  - - - - - -  - - - - -  - - -
        [HttpPost]
        public ActionResult CreateTelescopio(TelescopioDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpPost]
        public ActionResult CreateMontura(MonturaDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        public ActionResult CreateCamara(CamaraDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        public ActionResult CreateOcular(OcularDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - -  EDITS - - - - - - - - - - - - - - - - - -  - - - - - -  - - - - -  - - -
        [HttpPost]
        public IActionResult EditTelescopio(TelescopioDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            try
            {
                editarTelescopioCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult EditMontura(MonturaDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            try
            {
                editarMonturaCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public IActionResult EditCamara(CamaraDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            try
            {
                editarCamaraCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public IActionResult EditOcular(OcularDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            try
            {
                editarOcularCU.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidEquipoException ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }



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

        

        // POST: EquipoController/Delete/5
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
