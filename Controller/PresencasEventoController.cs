using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EventPlus_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencasEventoRepository _presencaRepository;

        public PresencaController(IPresencasEventoRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        [HttpPost("inscrever")]
        public ActionResult InscreverPresenca([FromBody] Presenca presenca)
        {
            if (presenca == null)
                return BadRequest("A presença é obrigatória.");

            _presencaRepository.Inscrever(presenca);
            return Ok("Presença inscrita com sucesso.");
        }

        [HttpGet("{id}")]
        public ActionResult<Presenca> BuscarPorId(Guid id)
        {
            var presenca = _presencaRepository.BuscarPorId(id);
            if (presenca == null)
                return NotFound("Presença não encontrada.");

            return Ok(presenca);
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarPresenca(Guid id, [FromBody] Presenca presenca)
        {
            var existingPresenca = _presencaRepository.BuscarPorId(id);
            if (existingPresenca == null)
                return NotFound("Presença não encontrada.");

            _presencaRepository.Atualizar(id, presenca);
            return Ok("Presença atualizada com sucesso.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarPresenca(Guid id)
        {
            var presenca = _presencaRepository.BuscarPorId(id);
            if (presenca == null)
                return NotFound("Presença não encontrada.");

            _presencaRepository.Deletar(id);
            return Ok("Presença deletada com sucesso.");
        }

        [HttpGet("listar")]
        public ActionResult<List<Presenca>> ListarPresencas()
        {
            var presencas = _presencaRepository.Listar();
            return Ok(presencas);
        }

        [HttpGet("listar-minhas/{usuarioId}")]
        public ActionResult<List<Presenca>> ListarMinhasPresencas(Guid usuarioId)
        {
            var presencas = _presencaRepository.ListarMinhasPresencas(usuarioId);
            return Ok(presencas);
        }
    }
}
