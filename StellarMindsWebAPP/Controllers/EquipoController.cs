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


        public EquipoController(IAltaEquipo altae, IListarEquipos findAllCu, IBuscarEquipoPorID buscarEquipoIDCu)
        {
          
            this.altaCU = altae;
            this.findAllCU = findAllCu;
            this.buscarEquipoIDCU = buscarEquipoIDCu;
            
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

        // POST: EquipoController/Create
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

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipoController/Edit/5
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
