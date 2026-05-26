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



        public EquipoController(IAltaEquipo altae, 
                                IListarEquipos findAllCu, 
                                IBuscarEquipoPorID buscarEquipoIDCu,
                                IEditarTelescopio editarTelescopioCu,
                                IEditarMontura editarMonturaCu,
                                IEditarCamara editarCamaraCu,
                                IEditarOcular editarOcularCu,
                                IDeleteEquipo deleteEquipoCu
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

        public ActionResult Delete(int id)
        {
            deleteEquipoCU.Execute(id);
            return RedirectToAction(nameof(Index));
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
        public IActionResult EditMontura(MonturaDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            editarMonturaCU.Execute(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditCamara(CamaraDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            editarCamaraCU.Execute(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditOcular(OcularDTO dto)
        {
            //editarTelescopioCU.Execute(dto);
            editarOcularCU.Execute(dto);
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
