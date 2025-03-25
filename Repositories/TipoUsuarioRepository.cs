using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _context;
        public TipoUsuarioRepository(EventContext context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = _context.TiposUsuarios.Find(id)!;

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
            }
            _context.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            TipoUsuario tiposUsuariosBuscado = _context.TiposUsuarios.Find(id)!;
            return tiposUsuariosBuscado;
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _context.TiposUsuarios.Add(novoTipoUsuario);

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
                TipoUsuario usuarioBuscado = _context.TiposUsuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    _context.TiposUsuarios.Remove(usuarioBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> ListaUsuario = _context.TiposUsuarios.ToList();
            return ListaUsuario;
        }

    }
}
