namespace tarefas.Core.Domain.Entitys
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<Projeto> Projetos { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
