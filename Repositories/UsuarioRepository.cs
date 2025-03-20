using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Utils;

namespace EventPlus_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
        {
            _context = context;
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

        public void Cadastrar(Usuario novoUsuario)                          
        {                                                   
            try
            {
                _context.Usuarios.Add(novoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
