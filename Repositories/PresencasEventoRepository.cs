using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPlus_.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext _context;

        public PresencasEventoRepository(EventContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                var presencaBuscada = _context.Presencas.Find(id);
                if (presencaBuscada != null)
                {
                    presencaBuscada.Situacao = presenca.Situacao;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar presença: " + ex.Message);
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                return _context.Presencas.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar presença: " + ex.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var presencaBuscada = _context.Presencas.Find(id);
                if (presencaBuscada != null)
                {
                    _context.Presencas.Remove(presencaBuscada);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar presença: " + ex.Message);
            }
        }

        public void Inscrever(Presenca presenca)
        {
            try
            {
                if (presenca != null)
                {
                    _context.Presencas.Add(presenca);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inscrever presença: " + ex.Message);
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                return _context.Presencas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar presenças: " + ex.Message);
            }
        }

        public List<Presenca> ListarMinhasPresencas(Guid id)
        {
            try
            {
                return _context.Presencas
                    .Where(p => p.UsuarioID == id)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar minhas presenças: " + ex.Message);
            }
        }
    }
}
