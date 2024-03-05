using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Application.Application.Interface
{
    public interface ITarefasApplication
    {
        Task<ActionResult<List<Tarefa>>> GetAllByProjetoAsync(int projetoId);
        Task<ActionResult<Tarefa>> GetByIdAsync(int id);
        Task<ActionResult> AddAsync(Tarefa tarefa);
        Task<ActionResult> UpdateAsync(Tarefa tarefa, int usuarioId);
        Task<ActionResult> RemoveAsync(int id);
        Task<ActionResult<int>> CountByProjetoAsync(int projetoId);
        Task<ActionResult<List<Tarefa>>> GetByStatusAsync(string status);
    }
}
