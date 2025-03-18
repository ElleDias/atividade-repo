using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IEventoRepository
    {
        List<Eventos> Listar();

        void Cadastrar(Eventos evento);

        void Atualizar(Guid id, Eventos evento);

        void Deletar(Guid id);

        List<Eventos> ListarPorId(Guid id);

        Eventos BuscarPorId(Guid id);

        List<Eventos> ListarProximosEventos(Guid id);
    }
}
