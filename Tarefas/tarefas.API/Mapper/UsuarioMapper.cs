using AutoMapper;
using tarefas.API.ViewModel;
using tarefas.Core.Domain.DTO;
using tarefas.Core.Domain.Entitys;

namespace tarefas.API.Mapper
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

            CreateMap<UsuarioUpdateViewModel, UsuarioDTO>().ReverseMap(); 
        }
    }
}
