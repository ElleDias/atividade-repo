using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoeventoBuscado = _context.TiposEventos.Find(id)!;

            if (tipoeventoBuscado != null)
            {
                tipoeventoBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
            }
            _context.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            TipoEvento tiposEventosBuscado = _context.TiposEventos.Find(id)!;
            return tiposEventosBuscado;
        }

        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            try
            {
                _context.TiposEventos.Add(novoTipoEvento);

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
                TipoEvento eventoBuscado = _context.TiposEventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.TiposEventos.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoEvento> Listar()
        {
            List<TipoEvento> ListaEvento = _context.TiposEventos.ToList();
            return ListaEvento;
        }
        private readonly EventContext _context;

        public TipoEventoRepository(EventContext context)
        {
            _context = context;
        }
       


    }
}
