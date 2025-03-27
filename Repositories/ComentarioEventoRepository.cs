using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.Extensions.Logging;

namespace EventPlus_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _context;

        public ComentarioEventoRepository(EventContext context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioID, Guid EventosID)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoID = c.ComentarioEventoID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventosID = c.EventosID,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }
                    }).FirstOrDefault(c => c.UsuarioID == UsuarioID && c.EventosID == EventosID)!;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                comentarioEvento.ComentarioEventoID = Guid.NewGuid();

                _context.ComentariosEventos.Add(comentarioEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Deletar(Guid idComentario)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentariosEventos.Find()!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentariosEventos.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoID = c.ComentarioEventoID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventosID = c.EventosID,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).Where(c => c.EventosID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}