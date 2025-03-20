using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [Authorize]
    [HttpPost]
    public IActionResult Post(Usuario usuario)
    {
        try
        {
            _usuarioRepository.Cadastrar(usuario);

            return StatusCode(201, usuario);
        }

        catch (Exception error)
        {
            return BadRequest(error.Message);
        }

    }
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {

        try
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            if (usuarioBuscado != null)
            {
                return Ok(usuarioBuscado);

            }
            return null;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    }
}
