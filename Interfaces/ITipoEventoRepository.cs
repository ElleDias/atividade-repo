using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface ITipoEventoRepository
    {
        List<TipoEvento> Listar();
        void Cadastrar(TipoEvento novoTipoEvento);

        void Atualizar(Guid id, TipoEvento tipoEvento);

        void Deletar(Guid id);

        TipoEvento BuscarPorId(Guid id);
    }
}
