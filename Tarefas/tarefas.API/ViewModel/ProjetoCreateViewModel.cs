using System.ComponentModel.DataAnnotations;

namespace tarefas.API.ViewModel
{
    public class ProjetoCreateViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public int UsuarioID { get; set; }
    }
}
