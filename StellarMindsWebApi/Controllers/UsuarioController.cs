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
        [HttpGet]
        public ActionResult<UsuarioDTO> Get()
        {

                IEnumerable<UsuarioDTO> listado = findAllCU.Execute();
                return Ok(listado);
           
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
