namespace tarefas.Core.Domain.DTO
{
    public class ComentarioDTO
    {
        public int ComentarioID { get; set; }
        public int TarefaID { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioID { get; set; }
    }
}
