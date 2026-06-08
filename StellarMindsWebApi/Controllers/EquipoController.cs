using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Entities;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StellarMindsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private IAltaEquipo altaCU;
        private IListarEquipos findAllCU;
        private IBuscarEquipoPorID buscarEquipoIDCU;
        private IEditarTelescopio editarTelescopioCU;
        private IEditarMontura editarMonturaCU;
        private IEditarCamara editarCamaraCU;
        private IEditarOcular editarOcularCU;
        private IDeleteEquipo deleteEquipoCU;

        public EquipoController(
                                IAltaEquipo altae,
                                IListarEquipos findAllCu,
                                IBuscarEquipoPorID buscarEquipoIDCu,
                                IEditarTelescopio editarTelescopioCu,
                                IEditarMontura editarMonturaCu,
                                IEditarCamara editarCamaraCu,
                                IEditarOcular editarOcularCu,
                                IDeleteEquipo deleteEquipoCu)
        {
            this.altaCU = altae;
            this.findAllCU = findAllCu;
            this.buscarEquipoIDCU = buscarEquipoIDCu;
            this.editarTelescopioCU = editarTelescopioCu;
            this.editarMonturaCU = editarMonturaCu;
            this.editarCamaraCU = editarCamaraCu;
            this.editarOcularCU = editarOcularCu;
            this.deleteEquipoCU = deleteEquipoCu;
        }


        // GET: EquipoController
        [HttpGet("{id}")]
        public IActionResult Disponible(int id)
        {
            EquipoDTO equipo = buscarEquipoIDCU.Execute(id);
            bool disponible = equipo.CantDisp > 0;
            return Ok(disponible);
        }

        // GET: api/<EquipoController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(findAllCU.Execute());
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(buscarEquipoIDCU.Execute(id));
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteEquipoCU.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        // ALTAS

        [HttpPost("telescopios")]
        public ActionResult<TelescopioDTO> CreateTelescopio(TelescopioDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return Ok();
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpPost("monturas")]
        public ActionResult<MonturaDTO> CreateMontura(MonturaDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return Ok();
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpPost("camaras")]
        public ActionResult<CamaraDTO> CreateCamara(CamaraDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return Ok();
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpPost("oculares")]
        public ActionResult<OcularDTO> CreateOcular(OcularDTO dto)
        {
            try
            {
                altaCU.Execute(dto);
                return Ok();
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        // EDITS

        [HttpPut("telescopios")]
        public ActionResult<TelescopioDTO> EditTelescopio(TelescopioDTO dto)
        {
            try
            {
                editarTelescopioCU.Execute(dto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpPut("monturas")]
        public ActionResult<MonturaDTO> EditMontura(MonturaDTO dto)
        {
            try
            {
                editarMonturaCU.Execute(dto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpPut("camaras")]
        public ActionResult<CamaraDTO> EditCamara(CamaraDTO dto)
        {
            try
            {
                editarCamaraCU.Execute(dto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpPut("oculares")]
        public ActionResult<OcularDTO> EditOcular(OcularDTO dto)
        {
            try
            {
                editarOcularCU.Execute(dto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidEquipoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }



        /*
        // GET api/<EquipoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<EquipoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EquipoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EquipoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
