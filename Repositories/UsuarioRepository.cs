using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Utils;
using System;
using System.Linq;

namespace EventPlus_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Usuario? BuscarPorEmailESenha(string email, string senha)
        {
            var usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuarioBuscado != null && Criptografia.CompararHash(senha, usuarioBuscado.Senha))
            {
                return usuarioBuscado;
            }

            return null;
        }

        public Usuario? BuscarPorId(Guid id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            if (novoUsuario == null)
            {
                throw new ArgumentNullException(nameof(novoUsuario));
            }

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
        }
    }
}