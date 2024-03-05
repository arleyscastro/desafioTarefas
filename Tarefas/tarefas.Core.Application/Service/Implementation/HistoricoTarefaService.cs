using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;

namespace tarefas.Core.Application.Service.Implementation
{
    public class HistoricoTarefaService : IHistoricoTarefaService
    {
        private readonly IHistoricoTarefaRepository _repository;
        private readonly IMapper _mapper;
        public HistoricoTarefaService(IHistoricoTarefaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ActionResult> AddAsync(HistoricoTarefaDTO historico)
        {
            await _repository.AddAsync(_mapper.Map<HistoricoTarefa>(historico));

            var value = new
            {
                Success = true,
                Message = "Histórico adicionada com sucesso",
                Result = historico
            };

            return new OkObjectResult(value);
        }

        
        public async Task<ActionResult<HistoricoTarefaDTO>> GetByIdAsync(int id)
        {
            var histDto = _mapper.Map<HistoricoTarefaDTO>(await _repository.GetByIdAsync(id));

            var value = new
            {
                Success = true,
                Message = "Tarefa encontrada",
                Result = histDto
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<List<HistoricoTarefaDTO>>> GetByTarefaAsync(int tarefaId)
        {
            var hist = await _repository.GetByTarefaAsync(tarefaId);

            var histDto = _mapper.Map<List<HistoricoTarefaDTO>>(hist);

            var value = new
            {
                Success = true,
                Message = "Listagem de histórico Ok",
                Result = histDto
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);

            var value = new
            {
                Success = true,
                Message = "Tarefa removida com sucesso"
            };

            return new OkObjectResult(value);
        }
    }
}
