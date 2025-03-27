using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPlus_.Repositories
{
    public class PresencasEventoRepository : IPresencaEventoRepository
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
                // Buscar a presença no banco de dados
                var presencaBuscada = _context.Presencas.Find(id);
                if (presencaBuscada == null)
                {
                    // Caso a presença não seja encontrada, lançar uma exceção específica
                    throw new KeyNotFoundException($"Presença com ID {id} não encontrada.");
                }

                // Atualizar a situação da presença
                presencaBuscada.Situacao = presenca.Situacao;

                // Salvar as alterações no banco de dados
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                // Logar o erro (aqui é onde você pode usar uma biblioteca de logging, como o Serilog ou NLog)
                throw new ApplicationException("Erro ao atualizar a presença no banco de dados.", dbEx);
            }
            catch (Exception ex)
            {
                // Logar a exceção genérica
                throw new ApplicationException("Erro desconhecido ao atualizar a presença.", ex);
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                // Buscar a presença no banco de dados
                var presencaBuscada = _context.Presencas.Find(id);
                if (presencaBuscada == null)
                {
                    throw new KeyNotFoundException($"Presença com ID {id} não encontrada.");
                }

                return presencaBuscada;
            }
            catch (Exception ex)
            {
                // Logar erro
                throw new ApplicationException("Erro ao buscar presença por ID.", ex);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                // Buscar a presença no banco de dados
                var presencaBuscada = _context.Presencas.Find(id);
                if (presencaBuscada == null)
                {
                    throw new KeyNotFoundException($"Presença com ID {id} não encontrada.");
                }

                // Remover a presença
                _context.Presencas.Remove(presencaBuscada);

                // Salvar as alterações no banco de dados
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                // Logar erro ao tentar remover
                throw new ApplicationException("Erro ao remover a presença do banco de dados.", dbEx);
            }
            catch (Exception ex)
            {
                // Logar erro genérico
                throw new ApplicationException("Erro desconhecido ao remover a presença.", ex);
            }
        }

        public void Inscrever(Presenca Inscricao)
        {
            try
            {
                // Adicionar a inscrição no banco de dados
                _context.Presencas.Add(Inscricao);

                // Salvar as alterações no banco de dados
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                // Logar erro ao tentar adicionar a inscrição
                throw new ApplicationException("Erro ao inscrever a presença no banco de dados.", dbEx);
            }
            catch (Exception ex)
            {
                // Logar erro genérico
                throw new ApplicationException("Erro desconhecido ao inscrever a presença.", ex);
            }
        }


        public List<Presenca> Listar()
        {
            try
            {
                // Tentar apenas contar as presenças para ver se o erro está na consulta
                var listaPresenca = _context.Presencas.ToList();
                Console.WriteLine($"Total de presenças: {listaPresenca.Count}");  // Exibe a quantidade no console
                return listaPresenca;
            }
            catch (Exception ex)
            {
                // Logar erro detalhado
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw new ApplicationException("Erro ao listar as presenças.", ex);
            }
        }

        public List<Presenca> ListarMinhas(Guid id)
        {
            try
            {
                // Listar presenças do usuário com o ID fornecido
                var listaPresenca = _context.Presencas.Where(p => p.UsuarioID == id).ToList();
                return listaPresenca;
            }
            catch (Exception ex)
            {
                // Logar erro
                throw new ApplicationException("Erro ao listar as presenças do usuário.", ex);
            }
        }
    }
    }

