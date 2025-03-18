using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);

        void Deletar(Guid id);

        List<ComentarioEvento> Listar(Guid id);

        ComentarioEvento BuscarPorIdUsuario(Guid UsuarioID, Guid EventosID);
    }
}
