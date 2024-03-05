using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.DTO;

namespace tarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : BaseController
    {
        private readonly IProjetosService _projetosService;
        public ProjetosController(IProjetosService projetosService)
        {
            _projetosService = projetosService;
        }

        [HttpGet("getListaTodos")]
        public async Task<ActionResult<List<ProjetoDTO>>> GetListaTodos()
        {
            return await _projetosService.ListarTodos();
        }

        [HttpPost()]
        public async Task<ActionResult<ProjetoDTO>> Criar(ProjetoDTO projeto)
        {
            return await _projetosService.AddAsync(projeto);
        }

        [HttpDelete("{projetoId}")]
        public async Task<ActionResult<ProjetoDTO>> Remover(int projetoId)
        {
            return await _projetosService.RemoveAsync(projetoId);
        }
    }
}
