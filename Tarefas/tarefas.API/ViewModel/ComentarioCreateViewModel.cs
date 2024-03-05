using System.ComponentModel.DataAnnotations;

namespace tarefas.API.ViewModel
{
    public class ComentarioCreateViewModel
    {
        [Required]
        public int TarefaID { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        [Required]
        public int UsuarioID { get; set; }
    }
}
