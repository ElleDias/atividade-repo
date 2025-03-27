
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EventPlus_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        [HttpPost]
        public IActionResult Post(ComentarioEvento novoComentario)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(novoComentario);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para listar Feedbacks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar(id));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para deletar Feedbacks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Endpoint para buscar Feedbacks por Id dos usuarios
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <param name="EventoId"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorIdUsuario/{UsuarioId}")]
        public IActionResult GetById(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                ComentarioEvento novoComentario = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioId, EventoId);
                return Ok(novoComentario);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }
    }
}
