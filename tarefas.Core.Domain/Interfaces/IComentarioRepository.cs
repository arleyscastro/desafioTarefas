using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Domain.Interfaces
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> GetByTarefaAsync(int tarefaId);
        Task AddAsync(Comentario comentario);
    }
}
