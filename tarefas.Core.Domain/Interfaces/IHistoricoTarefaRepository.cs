using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Domain.Interfaces
{
    public interface IHistoricoTarefaRepository
    {
        Task<List<HistoricoTarefa>> GetByTarefaAsync(int tarefaId);
        Task AddAsync(HistoricoTarefa historico);
        Task<HistoricoTarefa> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
