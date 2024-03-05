using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;

namespace tarefas.Core.Application.Service.Implementation
{
    public class ProjetosService : IProjetosService
    {
        private readonly IProjetoRepository _repository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public ProjetosService(IProjetoRepository repository, ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _tarefaRepository = tarefaRepository;
        }

        public async Task<ActionResult> AddAsync(ProjetoDTO projeto)
        {
            await _repository.AddAsync(_mapper.Map<Projeto>(projeto));

            var value = new
            {
                Success = true,
                Message = "Projeto adicionado com sucesso",
                Result = projeto
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<List<ProjetoDTO>>> ListarTodos()
        {
            var projetos = await _repository.GetAllAsync();
            var projetosDto = _mapper.Map<List<ProjetoDTO>>(projetos);
            var value = new
            {
                Success = true,
                Message = "Listagem Ok",
                Result = projetosDto
            };
            var result = new OkObjectResult(value);
            return await Task.FromResult<ActionResult<List<ProjetoDTO>>>(result);
        }

        public async Task<ActionResult> RemoveAsync(int id)
        {

            var tarefas = await _tarefaRepository.GetByStatusAsync("concluída");

            if (tarefas.Count>0)
                return new BadRequestObjectResult("Existe(m) tarefa(s) pendente(s), remova a(s) tarefa(s0 pendente(s) ou conclua todas elas");

            await _repository.RemoveAsync(id);

            var value = new
            {
                Success = true,
                Message = "Projeto removido com sucesso"
            };

            return new OkObjectResult(value);
        }
    }
}
