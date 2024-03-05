using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Domain.DTO;

namespace tarefas.Core.Application.Application.Interface
{
    public interface IProjetosApplication
    {
        Task<ActionResult<List<ProjetoDTO>>> ListarTodos();
    }
}
