using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _context;

        public ComentarioEventoRepository(EventContext context)
        {
            _context = context;
        }

        public ComentarioEvento  BuscarPorIdUsuario(Guid UsuarioID, Guid EventosID)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentariosEventos
                    .FirstOrDefault(c => c.UsuarioID == UsuarioID && c.EventosID == EventosID)!;

                return comentarioEventoBuscado;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o comentário do usuário no evento.", ex);
            }
        }

        public void Cadastrar(ComentarioEvento novoComentarioEvento)
        {
            try
            {
                _context.ComentariosEventos.Add(novoComentarioEvento);

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
                List<ComentarioEvento> listaDeComentarioEvento = _context.ComentariosEventos.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                List<ComentarioEvento> listaDeComentarioEvento = _context.ComentariosEventos.ToList();
                return listaDeComentarioEvento;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
