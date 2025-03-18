using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _context;

        public TipoEventoRepository(EventContext context)
        {
            _context = context;
        }
    
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    tipoEventoBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TiposEventos.Find(id)!;
                return tipoEventoBuscado;

            }
            catch (Exception)
            {
                throw;
            }
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
                TipoEvento tipoEventoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    _context.TiposEventos.Remove(tipoEventoBuscado);
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
            try
            {
                List<TipoEvento> listaDeEventos = _context.TiposEventos.ToList();
                return listaDeEventos;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
