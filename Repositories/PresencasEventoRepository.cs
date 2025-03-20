using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                Presenca presencaBuscado = _context.Presencas.Find(id)!;

                if (presencaBuscado != null)
                {
                    presencaBuscado.Situacao = presenca.Situacao;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                Presenca presencaBuscado = _context.Presencas.Find(id)!;

                if (presencaBuscado != null)
                {
                    return presencaBuscado;
                }
                return null!;
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
                Presenca presencaBuscado = _context.Presencas.Find(id)!;

                if (presencaBuscado != null)
                {
                    _context.Presencas.Remove(presencaBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(Presenca inscreverPresenca)
        {
          
        }

        public List<Presenca> Listar()
        {

            try
            {
                List<Presenca> listaDePresenca = _context.Presencas.ToList();
                return listaDePresenca;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presenca> ListarMinhasPresencas(Guid id)
        {
            try
            {
                List<Presenca> minhasPresencas = _context.Presencas
                    .Where(p => p.UsuarioID == id) // Filtra as presenças pelo ID do usuário
                    .ToList();

                return minhasPresencas;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
