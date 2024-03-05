namespace tarefas.Core.Domain.DTO
{
    public class TarefaDTO
    {
        public int TarefaID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public int ProjetoID { get; set; }
    }
}
