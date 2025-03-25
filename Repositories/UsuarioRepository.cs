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
            _context = context;
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios
                    .Select(u => new Usuario
                    {
                        UsuarioID = u.UsuarioID,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            TipoUsuarioID = u.TipoUsuarioID,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado!;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios
                    .Select(u => new Usuario
                    {
                        UsuarioID = u.UsuarioID,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            TipoUsuarioID = u.TipoUsuario!.TipoUsuarioID,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.UsuarioID == id)!;

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

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.UsuarioID = Guid.NewGuid();

                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);


                _context.Usuarios.Add(usuario);


                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
