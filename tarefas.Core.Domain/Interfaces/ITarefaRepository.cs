using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa> GetByIdAsync(int id);
        Task<List<Tarefa>> GetAllByProjetoAsync(int projetoId);
        Task AddAsync(Tarefa tarefa);
        Task UpdateAsync(Tarefa tarefa);
        Task RemoveAsync(int id);
        Task<int> CountByProjetoAsync(int projetoId);
        Task<List<Tarefa>> GetByStatusAsync(string status);
        Task<List<(Usuario usuario, double mediaTarefasConcluidas)>> ObterMediaTarefasConcluidasUltimos30DiasPorUsuario();
    }
}
