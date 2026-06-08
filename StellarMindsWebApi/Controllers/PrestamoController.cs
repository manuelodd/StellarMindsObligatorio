using Dominio.Exceptions;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace StellarMindsWebApi.Controllers
{
    public class PrestamoController : Controller
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(listarPrestamosCU.Execute());
            }
            catch (DbException)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("entre-fechas")]
        public IActionResult GetEntreFechas(int socioId, int mes, int anio)
        {
            try
            {
                return Ok(listarPrestamosSocioEntreFechasCU.Execute(socioId, mes, anio));
            }
            catch (InvalidPrestamoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbException)
            {
                return StatusCode(500);
            }
        }
    }
}
