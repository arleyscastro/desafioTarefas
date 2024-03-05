using System.ComponentModel.DataAnnotations;

namespace tarefas.API.ViewModel
{
    public class TarefaCreateViewModel
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Prioridade { get; set; }

        [Required]
        public int ProjetoID { get; set; }
    }
}
