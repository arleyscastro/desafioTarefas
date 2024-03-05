using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Application.Service.Interface
{
    public interface ITarefasService
    {
        Task<ActionResult<List<TarefaDTO>>> GetAllByProjetoAsync(int projetoId);
        Task<ActionResult<TarefaDTO>> GetByIdAsync(int id);
        Task<ActionResult> AddAsync(TarefaDTO tarefa);
        Task<ActionResult> UpdateAsync(TarefaDTO tarefa, int usuarioId);
        Task<ActionResult> RemoveAsync(int id);
        Task<ActionResult<int>> CountByProjetoAsync(int projetoId);
        Task<ActionResult<List<TarefaDTO>>> GetByStatusAsync(string status);
        Task<List<(Usuario usuario, double mediaTarefasConcluidas)>> ObterMediaTarefasConcluidasUltimos30DiasPorUsuario(int usuarioId);
        Task IncluiComentarioNaTarefa(ComentarioDTO comentario, int usuarioId);
    }
}
