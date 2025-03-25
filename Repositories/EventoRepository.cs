using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        
            private readonly EventContext _context;


            public EventoRepository(EventContext context)
            {
                _context = context;
            }
        public void Atualizar(Guid id, Eventos evento)
        {
            try
            {
                Eventos eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.TipoEventoID = evento.TipoEventoID;
                }

                _context.Evento.Update(eventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Eventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.Evento
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEvento = new TipoEvento
                        {
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        Instituicao = new Instituicao
                        {
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.EventosID == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Eventos Novoevento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (Novoevento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                Novoevento.EventosID = Guid.NewGuid();

                _context.Evento.Add(Novoevento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Eventos eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> Listar()
        {
            try
            {
                return _context.Evento
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoID = e.TipoEventoID,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoID = e.InstituicaoID,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoID,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            try
            {
                return _context.Evento
                    .Include(e => e.Presenca)
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoID = e.TipoEventoID,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoID = e.InstituicaoID,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoID,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        },
                        Presenca = new Presenca
                        {
                            UsuarioID = e.Presenca!.UsuarioID,
                            Situacao = e.Presenca!.Situacao
                        }
                    })
                    .Where(e => e.Presenca!.Situacao == true && e.Presenca.UsuarioID == id)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Eventos> ListarProximosEventos(Guid id)
        {
            try
            {
                return _context.Evento
                    .Select(e => new Eventos
                    {
                        EventosID = e.EventosID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEventoID = e.TipoEventoID,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoID = e.TipoEventoID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoID = e.InstituicaoID,
                        Instituicao = new Instituicao
                        {
                            InstituicaoID = e.InstituicaoID,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
