namespace tarefas.Core.Domain.DTO
{
    public class HistoricoTarefaDTO
    {
        public int HistoricoID { get; set; }
        public int TarefaID { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Detalhes { get; set; }
        public int UsuarioID { get; set; }
    }
}
