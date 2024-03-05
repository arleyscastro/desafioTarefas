using Microsoft.EntityFrameworkCore;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;

namespace tarefa.Infra.Data.Repository
{
    public class HistoricoTarefaRepository : IHistoricoTarefaRepository
    {
        private readonly TarefasSqlContext _context;

        public HistoricoTarefaRepository(TarefasSqlContext context)
        {
            _context = context;
        }

        public async Task<List<HistoricoTarefa>> GetByTarefaAsync(int tarefaId)
        {
            return await _context.HistoricoTarefas
                .Where(h => h.TarefaID == tarefaId)
                .ToListAsync();
        }

        public async Task AddAsync(HistoricoTarefa historico)
        {
            await _context.HistoricoTarefas.AddAsync(historico);
            await _context.SaveChangesAsync();
        }

        public async Task<HistoricoTarefa> GetByIdAsync(int id)
        {
            return await _context.HistoricoTarefas.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var histo = await _context.HistoricoTarefas.FindAsync(id);
            if (histo != null)
            {
                _context.HistoricoTarefas.Remove(histo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
