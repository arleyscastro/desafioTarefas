using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;
using tarefas.Core.Domain.Resourse;

namespace tarefas.Core.Application.Service.Implementation
{
    public class TarefasService : ITarefasService
    {
        private readonly ITarefaRepository _repository;
        private readonly IHistoricoTarefaRepository _repositoryHistorico;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IMapper _mapper;
        public TarefasService(ITarefaRepository repository, 
                              IHistoricoTarefaRepository repositoryHistorico, 
                              IUsuarioRepository usuarioRepository, 
                              ITarefaRepository tarefaRepository, 
                              IComentarioRepository comentarioRepository,
                              IMapper mapper)
        {
            _repository = repository;
            _repositoryHistorico = repositoryHistorico;
            _usuarioRepository = usuarioRepository;
            _tarefaRepository = tarefaRepository;
            _comentarioRepository = comentarioRepository;
            _mapper = mapper;
        }
        public async Task<ActionResult> AddAsync(TarefaDTO tarefa)
        {
            await _repository.AddAsync(_mapper.Map<Tarefa>(tarefa));

            var value = new
            {
                Success = true,
                Message = "Tarefa adicionada com sucesso",
                Result = tarefa
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<int>> CountByProjetoAsync(int projetoId)
        {
            var tarefas = await _repository.GetAllByProjetoAsync(projetoId);

            var value = new
            {
                Success = true,
                Message = "Contagem das tarefas do projeto Ok",
                Result = tarefas.Count
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<List<TarefaDTO>>> GetAllByProjetoAsync(int projetoId)
        {
            var tarefas = await _repository.GetAllByProjetoAsync(projetoId);
            var tarefasDto = _mapper.Map<List<TarefaDTO>>(tarefas);

            var value = new
            {
                Success = true,
                Message = "Listagem de tarefas do projeto Ok",
                Result = tarefasDto
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<TarefaDTO>> GetByIdAsync(int id)
        {

            var tarefaDto = _mapper.Map<TarefaDTO>(await _repository.GetByIdAsync(id));

            var value = new
            {
                Success = true,
                Message = "Tarefa encontrada",
                Result = tarefaDto
            };

            return new OkObjectResult(value);
        }

        public async Task<ActionResult<List<TarefaDTO>>> GetByStatusAsync(string status)
        {
            var tarefas = await _repository.GetByStatusAsync(status);
            var tarefasDto = _mapper.Map<List<TarefaDTO>>(tarefas);

            var value = new
            {
                Success = true,
                Message = "Listagem de tarefas por status Ok",
                Result = tarefasDto
            };

            return new OkObjectResult(value);
        }

        public async Task<List<(Usuario usuario, double mediaTarefasConcluidas)>> ObterMediaTarefasConcluidasUltimos30DiasPorUsuario(int usuarioId)
        {
            var usuarioLogado = await _usuarioRepository.GetByIdAsync(usuarioId);

            if (usuarioLogado.Nome.Equals("Gerante"))
            {
                var tarefas = await _repository.ObterMediaTarefasConcluidasUltimos30DiasPorUsuario();
                return tarefas;
            }
            return null;

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

        public async Task<ActionResult> UpdateAsync(TarefaDTO tarefa, int usuarioId)
        {
            var tarefaEntity = _mapper.Map<Tarefa>(tarefa);

            var tarefaAntiga = await _repository.GetByIdAsync(tarefa.TarefaID);

            if(!tarefaAntiga.Prioridade.Equals(tarefa.Prioridade))
                return new BadRequestObjectResult("Não é permitido alterar a prioridade de uma tarefa depois que ela foi criada");

            await tarefaEntity.ValidaParaPersistencia();
            tarefaEntity = await ValidarLimiteDeTarefasPorProjeto(tarefaEntity);


            if (!tarefaEntity.ValidationResult.IsValid)
                return new BadRequestObjectResult(tarefaEntity.ValidationResult.Errors);

            await _repository.UpdateAsync(tarefaEntity);

            var usuarioLogado = await _usuarioRepository.GetByIdAsync(usuarioId);
            await _repositoryHistorico.AddAsync(new HistoricoTarefa { DataAlteracao = DateTime.Now, Detalhes = tarefa.Descricao, Tarefa = tarefaEntity, TarefaID = tarefaEntity.TarefaID, Usuario = usuarioLogado, UsuarioID = usuarioLogado.UsuarioID });

            var value = new
            {
                Success = true,
                Message = "Tarefa atualizada com sucesso",
                Result = tarefa
            };

            return new OkObjectResult(value);
        }

        public async Task IncluiComentarioNaTarefa(ComentarioDTO comentario, int usuarioId)
        {
            await _comentarioRepository.AddAsync(_mapper.Map<Comentario>(comentario));
            var tarefa = await _repository.GetByIdAsync(comentario.TarefaID);
            var usuarioLogado = await _usuarioRepository.GetByIdAsync(usuarioId);
            await _repositoryHistorico.AddAsync(new HistoricoTarefa { DataAlteracao = DateTime.Now, Detalhes = comentario.Texto , Tarefa = tarefa, TarefaID = tarefa.TarefaID, Usuario = usuarioLogado, UsuarioID = usuarioLogado.UsuarioID });
        }

        private async Task<Tarefa> ValidarLimiteDeTarefasPorProjeto(Tarefa tarefa)
        {
            var quantidadeTarefasProjeto = await _tarefaRepository.CountByProjetoAsync(tarefa.ProjetoID);
            if (quantidadeTarefasProjeto >= 20)
            {
                tarefa.ValidationResult.Errors.Add(new ValidationFailure("ProjetoID", Resource.MSG_Limite_Maximo_de_Tarefa));
            }
            return tarefa;
        }
    }
}
