using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventosRepository;

        public EventoController(IEventoRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        // 🔹 Listar todos os eventos
        [HttpGet]
        public ActionResult<List<Eventos>> Listar()
        {
            return Ok(_eventosRepository.Listar());
        }

        // 🔹 Buscar evento por ID
        [HttpGet("{id}")]
        public ActionResult<Eventos> BuscarPorId(Guid id)
        {
            var evento = _eventosRepository.BuscarPorId(id);

            if (evento == null)
                return NotFound("Evento não encontrado.");

            return Ok(evento);
        }

        // 🔹 Cadastrar um novo evento
        [HttpPost]
        public ActionResult Cadastrar([FromBody] Eventos evento)
        {
            if (evento == null)
                return BadRequest("Dados inválidos.");

            _eventosRepository.Cadastrar(evento);

            // Certifique-se de que o ID foi gerado corretamente
            if (evento.EventosID == Guid.Empty)
                return BadRequest("Falha ao cadastrar o evento.");

            return CreatedAtAction(nameof(BuscarPorId), new { id = evento.EventosID }, evento);
        }

        // 🔹 Atualizar um evento existente
        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, [FromBody] Eventos evento)
        {
            var eventoExistente = _eventosRepository.BuscarPorId(id);

            if (eventoExistente == null)
                return NotFound("Evento não encontrado.");

            _eventosRepository.Atualizar(id, evento);
            return NoContent();
        }

        // 🔹 Deletar um evento
        [HttpDelete("{id}")]
        public ActionResult Deletar(Guid id)
        {
            var eventoExistente = _eventosRepository.BuscarPorId(id);

            if (eventoExistente == null)
                return NotFound("Evento não encontrado.");

            _eventosRepository.Deletar(id);
            return NoContent();
        }

        // 🔹 Listar eventos por ID (parece redundante com BuscarPorId, então pode ser alterado)
        [HttpGet("listarPorId/{id}")]
        public ActionResult<List<Eventos>> ListarPorId(Guid id)
        {
            return Ok(_eventosRepository.ListarPorId(id));
        }

        // 🔹 Listar próximos eventos
        [HttpGet("proximos/{id}")]
        public ActionResult<List<Eventos>> ListarProximosEventos(Guid id)
        {
            return Ok(_eventosRepository.ListarProximosEventos(id));
        }
    }
}

