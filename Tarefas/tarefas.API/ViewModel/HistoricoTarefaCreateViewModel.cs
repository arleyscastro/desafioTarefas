namespace tarefas.API.ViewModel
{
    public class HistoricoTarefaCreateViewModel
    {
        public int TarefaID { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Detalhes { get; set; }
        public int UsuarioID { get; set; }
    }
}
