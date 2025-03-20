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
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tipoEventoRepository = tipoEventoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> listadetipoevento = _tipoEventoRepository.Listar();
                return Ok(listadetipoevento);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
     

        [Authorize]
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipoEvento);

                // Retornar o status de criação com o ID do novo tipo de evento
                return CreatedAtAction(nameof(Get), new { id = novoTipoEvento.TipoEventoID }, novoTipoEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {

            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);
                return Ok(tipoEventoBuscado);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
       
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }

        }
        
        [Authorize]
        [HttpPut("id")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}
