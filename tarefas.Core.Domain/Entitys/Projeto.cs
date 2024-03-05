namespace tarefas.Core.Domain.Entitys
{
    public class Projeto 
    {
        public int ProjetoID { get; set; }
        public string Nome { get; set; }
        public int UsuarioID { get; set; }

        public Usuario Usuario { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
