using AutoMapper;
using tarefas.API.ViewModel;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.API.Mapper
{
    public class ComentarioMapper : Profile
    {
        public ComentarioMapper()
        {
            CreateMap<Comentario, ComentarioDTO>(); // Mapeia Comentario para ComentarioDTO
            CreateMap<ComentarioDTO, Comentario>(); // Mapeia ComentarioDTO para Comentario

            CreateMap<ComentarioUpdateViewModel, ComentarioDTO>();
        }
    }
}
