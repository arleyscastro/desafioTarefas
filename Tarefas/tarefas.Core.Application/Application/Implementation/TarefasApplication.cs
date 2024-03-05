using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Application.Application.Interface;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Application.Application.Implementation
{
    public class TarefasApplication : ITarefasApplication
    {
        private readonly ITarefasService _service;
        private readonly IMapper _mapper;

        public TarefasApplication(ITarefasService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<ActionResult> AddAsync(Tarefa tarefa)
        {
            var projetos = await _service.AddAsync(_mapper.Map<TarefaDTO>(tarefa));

            return projetos;
        }

        public async Task<ActionResult<int>> CountByProjetoAsync(int projetoId)
        {
            var projetos = await _service.CountByProjetoAsync(projetoId);

            return projetos;
        }

        public async Task<ActionResult<List<Tarefa>>> GetAllByProjetoAsync(int projetoId)
        {
            var projetos = await _service.GetAllByProjetoAsync(projetoId);

            var value = new
            {
                Success = true,
                Message = "Listagem de tarefas do projeto Ok",
                Result = _mapper.Map<List<Tarefa>>(projetos.Result)
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<Tarefa>> GetByIdAsync(int id)
        {
            var projetos = await _service.GetByIdAsync(id);

            var value = new
            {
                Success = true,
                Message = "Listagem de tarefas do projeto Ok",
                Result = _mapper.Map<Tarefa>(projetos.Result)
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<List<Tarefa>>> GetByStatusAsync(string status)
        {
            var projetos = await _service.GetByStatusAsync(status);

            var value = new
            {
                Success = true,
                Message = "Listagem de tarefas do projeto Ok",
                Result = _mapper.Map<Tarefa>(projetos.Result)
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult> RemoveAsync(int id)
        {
            var projetos = await _service.RemoveAsync(id);

            return projetos;
        }

        public async Task<ActionResult> UpdateAsync(Tarefa tarefa, int usuarioId)
        {
            var projetos = await _service.UpdateAsync(_mapper.Map<TarefaDTO>(tarefa), usuarioId);

            return projetos;
        }
    }
}
