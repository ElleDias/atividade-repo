using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IPresencaEventoRepository
    {
        List<Presenca> Listar();
        Presenca BuscarPorId(Guid id);
        void Atualizar(Guid id, Presenca presenca);
        void Inscrever(Presenca Inscricao);
        List<Presenca> ListarMinhas(Guid id);
        void Deletar(Guid id);
    }
}
