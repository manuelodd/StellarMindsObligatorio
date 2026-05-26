using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Entities;

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

        public EquipoController(IAltaEquipo altae,
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
        public bool Disponible(int id)
        {
            EquipoDTO equipo = buscarEquipoIDCU.Execute(id);
            return !equipo.EnPrestamo;
        }

        // GET: api/<EquipoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EquipoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

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
