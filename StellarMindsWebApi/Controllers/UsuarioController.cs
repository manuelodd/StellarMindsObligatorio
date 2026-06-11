using Dominio.Exceptions;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StellarMinds.Entities;
using System.Data.Common;

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
        private IListarSocios findAllSociosCU;

        public UsuarioController(ILoginUsuario loginu,
                                    IAltaUsuario altau,
                                    IListarUsuarios findAllCu,
                                    IListarSocios findAllSociosCu)
        {
            this.loginU = loginu;
            this.altaCU = altau;
            this.findAllCU = findAllCu;
            this.findAllSociosCU = findAllSociosCu; 
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
            catch (DbException)
            {
                return StatusCode(500, "Internal server error.");
            }
            //segundo catch, si la logica de negocio lanza excepcion (badrequest = 400)
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.Message);
            }
            //un "safety net" en caso de que se lance una exception generica de algun lado
            catch (Exception ex)
            {
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("socios")]
        public ActionResult<UsuarioDTO> GetSocios()
        {
            try
            {
                IEnumerable<UsuarioDTO> listado = findAllSociosCU.Execute(); // aca rompe
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

        /*
            [HttpPost("login")]
            public ActionResult<UsuarioDTO> Login(string username, string pass)
            {
                try
                {
                    UsuarioDTO usuario = loginU.Execute(username, pass);

                    return Ok(usuario);
                }
                catch (InvalidUserException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (DbException)
                {
                    return StatusCode(500, "Error de base de datos.");
         
                }
                catch(Exception ex) 
                {
                    return BadRequest(ex.Message);
                }
            }
        */
        
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<LoginDTO> Login([FromBody] LoginDTO login)
        {
            try
            {
                UsuarioDTO usr = loginU.Execute(login.Username, login.Password);
                /*
                if (usr == null || usr.Password != login.Password)
                    return Unauthorized("Credenciales inválidas. Reintente");
                */

                var token = JWTHandler.JWTHandler.GenerarToken(usr);
                return Ok(new
                {
                    Token = token,
                    Usuario = usr
                });
            }
            catch (InvalidUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Message = "Se produjo un error. Intente nuevamente."
                });
            }
        }


        [HttpPost]
            public ActionResult<UsuarioDTO> Post(UsuarioDTO dto)
            {
                try
                {
                    altaCU.Execute(dto);
                    return Created();
                }
                catch (InvalidUserException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (DbException)
                {
                    return StatusCode(500, "Error de base de datos.");
                }
            }

            /*
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
            */
        }
    }
