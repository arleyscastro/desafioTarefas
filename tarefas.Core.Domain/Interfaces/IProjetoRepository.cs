using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Domain.Interfaces
{
    public interface IProjetoRepository
    {
        Task<Projeto> GetByIdAsync(int id);
        Task<List<Projeto>> GetAllAsync();
        Task<List<Projeto>> GetAllByUsuarioAsync(int usuarioId);
        Task AddAsync(Projeto projeto);
        Task UpdateAsync(Projeto projeto);
        Task RemoveAsync(int id);
    }
}
