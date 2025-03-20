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

        // 🔹 Atualizar um tipo de usuário
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TiposUsuarios.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // 🔹 Buscar tipo de usuário por ID
        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TiposUsuarios.Find(id)!;
                return tipoUsuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // 🔹 Cadastrar um novo tipo de usuário
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

        // 🔹 Deletar um tipo de usuário
        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TiposUsuarios.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context.TiposUsuarios.Remove(tipoUsuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // 🔹 Listar todos os tipos de usuários
        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> listaDeUsuarios = _context.TiposUsuarios.ToList();
                return listaDeUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
