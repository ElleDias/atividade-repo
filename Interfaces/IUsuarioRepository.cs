using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);

    }
}
