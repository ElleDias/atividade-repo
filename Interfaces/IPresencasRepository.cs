using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IPresencasRepository
    {
        void Deletar(Guid id);

        Presenca BuscarPorId(Guid id);

        void Atualizar(Guid id, Presenca presenca);

        List<Presenca> Listar();

        List<Presenca> ListarMinhasPresencas(Guid id);

        void Inscrever(Presenca inscreverPresenca);

    }
}
