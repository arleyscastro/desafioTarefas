using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Application.Application.Interface
{
    public interface IHistoricoTarefaApplication
    {
        Task<ActionResult<HistoricoTarefa>> GetByIdAsync(int id);
        Task<ActionResult> AddAsync(HistoricoTarefa historico);
        Task<ActionResult> UpdateAsync(HistoricoTarefa historico);
        Task<ActionResult> RemoveAsync(int id);
        Task<ActionResult<List<HistoricoTarefa>>> GetAllByProjetoAsync(int projetoId);
    }
}
