using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StellarMindsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ILoginUsuario loginU;
        private IAltaUsuario altaCU;
        private IListarUsuarios findAllCU;

        public UsuarioController    (ILoginUsuario loginu, 
                                    IAltaUsuario altau, 
                                    IListarUsuarios findAllCu)
        {
            this.loginU = loginu;
            this.altaCU = altau;
            this.findAllCU = findAllCu;
        }
        // GET: api/<UsuarioController>
        /*
        [HttpGet]
        public ActionResult<UsuarioDTO> Get()
        {
            try
            {
                IEnumerable<UsuarioDTO> listado = findAllCU.Execute();
                return Ok(listado);
            }
            catch(Exception ex)
            {
                StatusCode(500, "Internal server error.");
            }

        }
        */

        [HttpGet]
        public ActionResult<UsuarioDTO> Get()
        {
            try
            {
                IEnumerable<UsuarioDTO> listado = findAllCU.Execute();
                return Ok(listado);
            }
            //primer catch, si explota la db (por x motivo), mala cadena de conexion
            catch (System.Data.Common.DbException)
            {
                return StatusCode(500, "Internal server error.");
            }
                //segundo catch, si la logica de negocio lanza excepcion (badrequest = 400)
                catch(InvalidUserException ex)
                {
                    return BadRequest(ex.Message);
                }
        }





        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
