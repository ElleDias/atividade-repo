using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return Created("", usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Buscar Por E-mail e Senha
        [HttpPost("BuscarPorEmailESenha")]
        public IActionResult BuscarPorEmailESenha([FromBody] Usuario usuario)
        {
            try
            {
                // Aqui vamos buscar o usuário com base no e-mail e senha.
                var usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado ou credenciais inválidas.");
                }

                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //---------------------------------------------------------------------------------
        // Buscar Por Id
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
