using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Domain.DTO;

namespace tarefas.Core.Application.Service.Interface
{
    public interface IHistoricoTarefaService
    {
        Task<ActionResult> AddAsync(HistoricoTarefaDTO historico);
        Task<ActionResult> RemoveAsync(int id);
        Task<ActionResult<List<HistoricoTarefaDTO>>> GetByTarefaAsync(int tarefaId);
    }
}
