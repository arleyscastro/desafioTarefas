using FluentValidation;
using tarefas.Core.Domain.Entitys;
using tarefas.Core.Domain.Resourse;

namespace tarefas.Core.Domain.Validation
{
    public class TarefasValidation : AbstractValidator<Tarefa>
    {
        public TarefasValidation()
        {
            RuleFor(t => t.Prioridade)
            .NotEmpty().WithMessage(Resource.MSG_PrioridadeDaTarefa_Obrigatorio)
            .IsInEnum().WithMessage(Resource.MSG_Tipos_PrioridadeDaTarefa_Obrigatorio);

        }
        
    }
}
