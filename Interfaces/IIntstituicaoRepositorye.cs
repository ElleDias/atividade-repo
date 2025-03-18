using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IIntstituicaoRepositorye
    {
        void Deletar(Guid id);

        Instituicao BuscarPorId(Guid id);

        void Atualizar(Guid id, Instituicao presenca);

        List<Instituicao> Listar();

        List<Instituicao> ListarMinhasInstituicoes(Guid id);

        void Inscrever(Instituicao inscreverInstituicao);

    }
}
