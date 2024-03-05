using Microsoft.EntityFrameworkCore;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;

namespace tarefa.Infra.Data.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly TarefasSqlContext _context;

        public ComentarioRepository(TarefasSqlContext context)
        {
            _context = context;
        }

        public async Task<List<Comentario>> GetByTarefaAsync(int tarefaId)
        {
            return await _context.Comentarios
                .Where(c => c.TarefaID == tarefaId)
                .ToListAsync();
        }

        public async Task AddAsync(Comentario comentario)
        {
            await _context.Comentarios.AddAsync(comentario);
            await _context.SaveChangesAsync();
        }
    }
}
