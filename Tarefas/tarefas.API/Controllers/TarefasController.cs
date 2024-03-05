using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Application.Service.Implementation;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : BaseController
    {
        private readonly ITarefasService _service;
        public TarefasController(ITarefasService service)
        {
            _service = service;
        }

        [HttpGet("{projetoId}")]
        public async Task<ActionResult<List<TarefaDTO>>> GetListaTodasTarefasDprojeto(int projetoId)
        {
            return await _service.GetAllByProjetoAsync(projetoId);
        }

        [HttpPost()]
        public async Task<ActionResult<TarefaDTO>> Criar(TarefaDTO tarefa)
        {
            return await _service.AddAsync(tarefa);
        }

        [HttpPut("{usuarioId}")]
        public async Task<ActionResult<TarefaDTO>> Atualizar(int usuarioId, TarefaDTO tarefa)
        {
            return await _service.UpdateAsync(tarefa, usuarioId);
        }

        [HttpDelete("{projetoId}")]
        public async Task<ActionResult<TarefaDTO>> Remover(int projetoId)
        {
            return await _service.RemoveAsync(projetoId);
        }

        [HttpPost("CriarComentarioNaTarefa/{usuarioId}")]
        public async Task<ActionResult> CriarComentarioNaTarefa(int usuarioId, ComentarioDTO comentario)
        {
            await _service.IncluiComentarioNaTarefa(comentario, usuarioId);
            var value = new
            {
                Success = true,
                Message = "Comentário incluido com sucesso"
            };

            return new OkObjectResult(value);
        }

        [HttpGet("GetRelatorioTarefas30Dias/{usuarioId}")]
        public async Task<List<(Usuario usuario, double mediaTarefasConcluidas)>> GetRelatorioTarefas30Dias(int usuarioId)
        {
            return await _service.ObterMediaTarefasConcluidasUltimos30DiasPorUsuario(usuarioId);
        }
    }
}
