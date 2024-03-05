using AutoMapper;
using tarefas.API.ViewModel;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.API.Mapper
{
    public class ProjetoMapper : Profile
    {
        public ProjetoMapper()
        {
            CreateMap<Projeto, ProjetoDTO>()
                .ForMember(dest => dest.UsuarioID, opt => opt.MapFrom(src => src.Usuario.UsuarioID)); // Mapeia Projeto para ProjetoDTO
            CreateMap<ProjetoDTO, Projeto>(); // Mapeia ProjetoDTO para Projeto

            CreateMap<ProjetoUpdateViewModel, ProjetoDTO>();
        }
    }
}
