using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;

namespace StellarMindsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservacionController : Controller
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

        [HttpGet("ranking")]
        public ActionResult<ObservacionDTO> Ranking()
        {
            try
            {
                return Ok(rankObjetosCelestesCU.Execute());
            }
            catch (System.Data.Common.DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpPost]
        public ActionResult<ObservacionDTO> Post(ObservacionDTO dto)
        {
            try
            {
                altaObservacionCU.Execute(dto);
                return Created();
            }
            catch (InvalidObservacionException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Data.Common.DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }
    }
}
