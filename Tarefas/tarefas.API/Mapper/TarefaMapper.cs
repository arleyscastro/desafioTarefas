using AutoMapper;
using tarefas.API.ViewModel;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.API.Mapper
{
    public class TarefaMapper : Profile
    {
        public TarefaMapper()
        {
            CreateMap<Tarefa, TarefaDTO>()
                .ForMember(dest => dest.ProjetoID, opt => opt.MapFrom(src => src.Projeto.ProjetoID)); // Mapeia Tarefa para TarefaDTO
            CreateMap<TarefaDTO, Tarefa>(); // Mapeia TarefaDTO para Tarefa

            CreateMap<TarefaUpdateViewModel, TarefaDTO>();
        }
    }
}
