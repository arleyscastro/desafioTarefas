using System.ComponentModel.DataAnnotations;

namespace tarefas.API.ViewModel
{
    public class UsuarioCreateViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
