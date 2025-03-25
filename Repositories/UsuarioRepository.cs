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

        public UsuarioRepository(EventContext Context)
        {
            _context = Context;
        }
        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha);



                _context.Usuarios.Add(novoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha)!;

                if (confere)
                {
                    return usuarioBuscado;
                }
            }
            return null!;
        }
    }
}
