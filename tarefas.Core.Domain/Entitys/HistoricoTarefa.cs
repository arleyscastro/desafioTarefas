namespace tarefas.Core.Domain.Entitys
{
    public class HistoricoTarefa
    {
        public int HistoricoID { get; set; }
        public int TarefaID { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Detalhes { get; set; }
        public int UsuarioID { get; set; }

        public Tarefa Tarefa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
