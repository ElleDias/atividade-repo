using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller 
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase // Adicionado ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        // 🔹 Listar todos os tipos de usuário
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuario> listaDeTiposUsuarios = _tipoUsuarioRepository.Listar(); // Corrigido TipoEvento → TipoUsuario
                return Ok(listaDeTiposUsuarios);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // 🔹 Buscar um tipo de usuário por ID
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado == null)
                    return NotFound("Tipo de usuário não encontrado.");

                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // 🔹 Cadastrar um novo tipo de usuário
        [Authorize]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario) // Corrigido TipoEvento → TipoUsuario
        {
            try
            {
                if (novoTipoUsuario == null)
                    return BadRequest("Dados inválidos.");

                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                return CreatedAtAction(nameof(GetById), new { id = novoTipoUsuario.TipoUsuarioID }, novoTipoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // 🔹 Atualizar um tipo de usuário existente
        [Authorize]
        [HttpPut("{id}")] // Corrigido "id" → "{id}"
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                var tipoUsuarioExistente = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioExistente == null)
                    return NotFound("Tipo de usuário não encontrado.");

                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // 🔹 Deletar um tipo de usuário
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var tipoUsuarioExistente = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioExistente == null)
                    return NotFound("Tipo de usuário não encontrado.");

                _tipoUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
