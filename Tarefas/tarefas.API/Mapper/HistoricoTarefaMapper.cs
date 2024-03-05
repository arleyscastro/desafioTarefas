using AutoMapper;
using tarefas.API.ViewModel;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.API.Mapper
{
    public class HistoricoTarefaMapper : Profile
    {
        public HistoricoTarefaMapper()
        {
            CreateMap<HistoricoTarefa, HistoricoTarefaDTO>(); // Mapeia HistoricoTarefa para HistoricoTarefaDTO
            CreateMap<HistoricoTarefaDTO, HistoricoTarefa>(); // Mapeia HistoricoTarefaDTO para HistoricoTarefa

            CreateMap<HistoricoTarefaUpdateViewModel, HistoricoTarefaDTO>();
        }
    }
}
