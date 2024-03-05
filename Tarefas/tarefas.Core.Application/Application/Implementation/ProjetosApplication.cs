using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Application.Application.Interface;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.DTO;

namespace tarefas.Core.Application.Application.Implementation
{
    public class ProjetosApplication : IProjetosApplication
    {
        private readonly IProjetosService _projetoService;

        public ProjetosApplication(IProjetosService projetoService)
        {
            _projetoService = projetoService;
        }

        public async Task<ActionResult<List<ProjetoDTO>>> ListarTodos()
        {
            var projetos = await _projetoService.ListarTodos();
            
            return projetos;
        }
    }
}
