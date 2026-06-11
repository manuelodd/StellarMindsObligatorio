using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace StellarMindsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ObjetoCelesteController : ControllerBase
    {
        private IListarObjetosCelestes listarObjetosCelestesCU;

        public ObjetoCelesteController(
                                        IListarObjetosCelestes listarObjetosCelestesCu)
        {
            listarObjetosCelestesCU = listarObjetosCelestesCu;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(listarObjetosCelestesCU.Execute());
            }
            catch (DbException)
            {
                return StatusCode(500);
            }
        }
    }
}
