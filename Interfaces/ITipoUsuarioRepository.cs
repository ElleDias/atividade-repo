using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();
        void Cadastrar(TipoUsuario novoTipoUsuario);

        void Atualizar(Guid id, TipoUsuario tipoUsuario);

        void Deletar(Guid id);

        TipoUsuario BuscarPorId(Guid id);
    }
}
