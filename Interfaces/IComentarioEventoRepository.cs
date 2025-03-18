using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);

        void Deletar(Guid idComentario);

        List<ComentarioEvento> Listar(Guid idComentario);

        ComentarioEvento BuscarPorIdUsuario(Guid UsuarioID, Guid EventosID);
    }
}
