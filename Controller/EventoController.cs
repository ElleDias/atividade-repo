using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para cadastras Eventos
        /// </summary>
        /// <param name="novoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Eventos evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Deletar Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Eventos evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return StatusCode (204, evento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para Listar Proximos Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarProximosEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Eventos> listarEvento = _eventoRepository.ListarProximosEventos(id);
                return Ok(listarEvento);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        /// <summary>
        /// Endpoint para Listar Eventos por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                List<Eventos> listarEvento = _eventoRepository.ListarPorId(id);
                return Ok(listarEvento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
