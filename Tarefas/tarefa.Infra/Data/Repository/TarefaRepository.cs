using Microsoft.EntityFrameworkCore;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Interfaces;

namespace tarefa.Infra.Data.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefasSqlContext _context;

        public TarefaRepository(TarefasSqlContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<List<Tarefa>> GetAllByProjetoAsync(int projetoId)
        {
            return await _context.Tarefas
                .Where(t => t.ProjetoID == projetoId)
                .ToListAsync();
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountByProjetoAsync(int projetoId)
        {
            return await _context.Tarefas.CountAsync(t => t.ProjetoID == projetoId);
        }

        public async Task<List<Tarefa>> GetByStatusAsync(string status)
        {
            return await _context.Tarefas
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public async Task<List<(Usuario usuario, double mediaTarefasConcluidas)>> ObterMediaTarefasConcluidasUltimos30DiasPorUsuario()
        {
            var dataLimite = DateTime.Now.AddDays(-30);

            // Consulta para calcular o número médio de tarefas concluídas por usuário nos últimos 30 dias
            var resultados = await (from t in _context.Tarefas
                                    join p in _context.Projetos on t.ProjetoID equals p.ProjetoID
                                    join u in _context.Usuarios on p.UsuarioID equals u.UsuarioID
                                    where t.Status == "Concluída" && t.DataVencimento >= dataLimite
                                    group t by new { p.UsuarioID, u } into g
                                    select new
                                    {
                                        Usuario = g.Key.u,
                                        MediaTarefasConcluidas = g.Count() / 30.0 
                                    }).ToListAsync();

            var listaResultados = resultados.Select(r => (r.Usuario, r.MediaTarefasConcluidas)).ToList();

            return listaResultados;
        }
    }
}
