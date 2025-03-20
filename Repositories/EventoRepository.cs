using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

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
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                }

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
                Eventos eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    return eventoBuscado;
                }
                return null!;
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
                Eventos EventosBuscados = _context.Evento.Find(id)!;

                if (EventosBuscados != null)
                {
                    _context.Evento.Remove(EventosBuscados);
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
                List<Eventos> listaDeEventos = _context.Evento.ToList();
                return listaDeEventos;

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
                List<Eventos> eventoEncontrado = _context.Evento
                    .Where(e => e.EventosID == id) // Filtra pelo ID do evento
                    .ToList();

                return eventoEncontrado;
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
                List<Eventos> proximosEventos = _context.Evento
                    .Where(e => e.DataEvento >= DateTime.Now) // Filtra eventos futuros
                    .OrderBy(e => e.DataEvento) // Ordena do mais próximo para o mais distante
                    .ToList();

                return proximosEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
