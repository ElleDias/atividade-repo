using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentariosEventosRepository)
        {
            _comentarioEventoRepository = comentariosEventosRepository;
        }

        [Authorize]
        [HttpPost]

        public IActionResult Post(ComentarioEvento novoComentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(novoComentarioEvento);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid idComentario)
        {
            try
            {
                _comentarioEventoRepository.Deletar(idComentario);
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ComentarioEvento> listaDeComentarios = _comentarioEventoRepository.Listar();
                return Ok(listaDeComentarios);

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorIdUsuario/{id}")]
        public IActionResult GetById(Guid UsuarioId, Guid EventosId)
        {
            try
            {
                ComentarioEvento comentarioBuscado = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioId, EventosId);
                return Ok(comentarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}

