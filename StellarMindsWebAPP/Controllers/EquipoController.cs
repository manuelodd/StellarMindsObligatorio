using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebAPP.Controllers
{
    public class EquipoController : Controller
    {
        private IAltaEquipo altaCU;
        private IListarEquipos findAllCU;
        private IBuscarEquipoPorID buscarEquipoIDCU;
        private IEditarTelescopio editarTelescopioCU;

        public EquipoController(IAltaEquipo altae, 
                                IListarEquipos findAllCu, 
                                IBuscarEquipoPorID buscarEquipoIDCu,
                                IEditarTelescopio editarTelescopioCu)
        {
            this.altaCU = altae;
            this.findAllCU = findAllCu;
            this.buscarEquipoIDCU = buscarEquipoIDCu;
            this.editarTelescopioCU = editarTelescopioCu;
        }

        // GET: EquipoController
        public ActionResult Index()
        {
            IEnumerable<EquipoDTO> listado = findAllCU.Execute();
            return View(listado);
        }

        // GET: EquipoController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            EquipoDTO equipo = buscarEquipoIDCU.Execute(id);
            return View(equipo);
        }

        public ActionResult Edit(int id)
        {
            EquipoDTO dto = buscarEquipoIDCU.Execute(id);
            return View(dto);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - -  CREATES - - - - - - - - - - - - - - - - - -  - - - - - -  - - - - -  - - -
        [HttpPost]
        public ActionResult CreateTelescopio(TelescopioDTO dto)
        {
            altaCU.Execute(TelescopioDTOMapper.FromDTO(dto));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult CreateMontura(MonturaDTO dto)
        {
            altaCU.Execute(MonturaDTOMapper.FromDTO(dto));
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public ActionResult CreateCamara(CamaraDTO dto)
        {
            altaCU.Execute(CamaraDTOMapper.FromDTO(dto));

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public ActionResult CreateOcular(OcularDTO dto)
        {
            altaCU.Execute(OcularDTOMapper.FromDTO(dto));
            return RedirectToAction(nameof(Index));

        }

        // - - - - - - - - - - - - - - - - - - - - - - - - -  EDITS - - - - - - - - - - - - - - - - - -  - - - - - -  - - - - -  - - -
        [HttpPost]
        public IActionResult EditTelescopio(TelescopioDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            editarTelescopioCU.Execute(dto);
            return RedirectToAction(nameof(Index));
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

        // GET: EquipoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
