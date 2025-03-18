using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly Eventos_Context _context;

        public TipoEventoRepository(Eventos_Context context)
        {
            _context = context;
        }
    
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;

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
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;
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
                _context.TipoEvento.Add(novoTipoEvento);

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
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    _context.TipoEvento.Remove(tipoEventoBuscado);
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
                List<TipoEvento> listaDeEventos = _context.TipoEvento.ToList();
                return listaDeEventos;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
