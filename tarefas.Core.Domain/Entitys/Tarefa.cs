using tarefas.Core.Domain.Validation;

namespace tarefas.Core.Domain.Entitys
{
    public class Tarefa : BaseEntity
    {
        
        public int TarefaID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public int ProjetoID { get; set; }

        public Projeto Projeto { get; set; }
        public List<HistoricoTarefa> Historico { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public async Task ValidaParaPersistencia()
        {
            ValidationResult = await new TarefasValidation().ValidateAsync(this);
        }
    }
}
