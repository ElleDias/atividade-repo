using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasEventoController : ControllerBase
    {
        private readonly IPresencasEventoRepository _presencasRepository;

        public PresencasEventoController(IPresencasEventoRepository presencasRepository)
        {
            _presencasRepository = presencasRepository;
        }

        // 🔹 Buscar presença por ID
        [HttpGet("{id}")]
        public ActionResult<Presenca> BuscarPorId(Guid id)
        {
            var presenca = _presencasRepository.BuscarPorId(id);

            if (presenca == null)
                return NotFound("Presença não encontrada.");

            return Ok(presenca);
        }

        // 🔹 Listar todas as presenças
        [HttpGet]
        public ActionResult<List<Presenca>> Listar()
        {
            return Ok(_presencasRepository.Listar());
        }


        // 🔹 Listar minhas presenças por usuário
        [HttpGet("minhas/{id}")]
        public ActionResult<List<Presenca>> ListarMinhasPresencas(Guid id)
        {
            return Ok(_presencasRepository.ListarMinhasPresencas(id));
        }

        // 🔹 Inscrever um usuário em um evento
        [HttpPost]
        public ActionResult Inscrever([FromBody] Presenca inscreverPresenca)
        {
            if (inscreverPresenca == null)
                return BadRequest("Dados inválidos.");

            _presencasRepository.Inscrever(inscreverPresenca);
            return CreatedAtAction(nameof(BuscarPorId), new { id = inscreverPresenca.PresencaID }, inscreverPresenca);
        }

        // 🔹 Atualizar uma presença
        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, [FromBody] Presenca presenca)
        {
            var presencaExistente = _presencasRepository.BuscarPorId(id);

            if (presencaExistente == null)
                return NotFound("Presença não encontrada.");

            _presencasRepository.Atualizar(id, presenca);
            return NoContent();
        }

        // 🔹 Deletar uma presença
        [HttpDelete("{id}")]
        public ActionResult Deletar(Guid id)
        {
            var presencaExistente = _presencasRepository.BuscarPorId(id);

            if (presencaExistente == null)
                return NotFound("Presença não encontrada.");

            _presencasRepository.Deletar(id);
            return NoContent();
        }
    }
}
