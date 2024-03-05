using Microsoft.EntityFrameworkCore;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;

namespace tarefa.Infra.Data.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly TarefasSqlContext _context;

        public ProjetoRepository(TarefasSqlContext context)
        {
            _context = context;
        }

        public async Task<Projeto> GetByIdAsync(int id)
        {
            return await _context.Projetos.FindAsync(id);
        }

        public async Task<List<Projeto>> GetAllAsync()
        {
            return await _context.Projetos.ToListAsync();
        }

        public async Task AddAsync(Projeto projeto)
        {
            await _context.Projetos.AddAsync(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Projeto projeto)
        {
            _context.Projetos.Update(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Projeto>> GetAllByUsuarioAsync(int usuarioId)
        {
            return await _context.Projetos
               .Where(p => p.UsuarioID == usuarioId)
               .ToListAsync();
        }
    }
}
