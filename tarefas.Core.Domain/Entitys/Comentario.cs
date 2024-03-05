namespace tarefas.Core.Domain.Entitys
{
    public class Comentario
    {
        public int ComentarioID { get; set; }
        public int TarefaID { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioID { get; set; }

        public Tarefa Tarefa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
