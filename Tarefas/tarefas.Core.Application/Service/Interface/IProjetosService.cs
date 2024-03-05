using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Domain.DTO;

namespace tarefas.Core.Application.Service.Interface
{
    public interface IProjetosService
    {
        Task<ActionResult<List<ProjetoDTO>>> ListarTodos();
        Task<ActionResult> AddAsync(ProjetoDTO projeto);
        Task<ActionResult> RemoveAsync(int id);
    }
}
