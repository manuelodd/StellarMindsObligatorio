using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace StellarMindsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuditoriaPrestamoController : Controller
    {
        private IListarAuditoriasPrestamo listAllAudisCU;
        private IListarCoordinadores listAllCoordinadoresCU;
        private IListarAuditoriasByCoordinador listAllAudisByCoordinadorCU;
        private IFindAuditoriaById findAuditoriaByIdCU;
        private IListarCoordinadores findAllCoordinadoresCU;

        public AuditoriaPrestamoController(IListarAuditoriasPrestamo listAllAudisCu,
                                            IListarCoordinadores listAllCoordinadoresCu,
                                            IListarAuditoriasByCoordinador listAllAudisByCoordinadorCu,
                                            IFindAuditoriaById findAuditoriaByIdCu,
                                            IListarCoordinadores findAllCoordinadoresCu)
        {
            this.listAllAudisCU = listAllAudisCu;
            this.listAllCoordinadoresCU = listAllCoordinadoresCu;
            this.listAllAudisByCoordinadorCU = listAllAudisByCoordinadorCu;
            this.findAuditoriaByIdCU = findAuditoriaByIdCu;
            this.findAllCoordinadoresCU = findAllCoordinadoresCu;
        }


        [HttpGet]
        public ActionResult<AuditoriaPrestamoDTO> GetAll()
        {
            try
            {
                return Ok(listAllAudisCU.Execute());
            }
            catch (System.Data.Common.DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpGet("coordinador/{id}")]
        public ActionResult<AuditoriaPrestamoDTO> GetByCoordinador(int id)
        {
            try
            {
                return Ok(listAllAudisByCoordinadorCU.Execute(id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Data.Common.DbException)
            {
                return StatusCode(500, "Error de base de datos.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AuditoriaPrestamoDTO> GetById(int id)
        {
            try
            {
                return Ok(findAuditoriaByIdCU.Execute(id));
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

        [HttpGet("coordinadores")]
        public ActionResult<UsuarioDTO> GetCoordinadores()
        {
            try
            {
                IEnumerable<UsuarioDTO> listado = findAllCoordinadoresCU.Execute(); // aca rompe
                return Ok(listado);
            }
            catch (DbException)
            {
                return StatusCode(500, "Internal server error.");
            }
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
