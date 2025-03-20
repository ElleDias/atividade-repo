using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        //cadastrar
        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201, tipoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        //deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuario> listaDosUsuarios = _tipoUsuarioRepository.Listar();
                return Ok(listaDosUsuarios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        // Buscar por Id
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        // Atualizar 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuario tiposUsuarios)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tiposUsuarios);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
