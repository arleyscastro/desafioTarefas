namespace tarefas.Core.Domain.Resourse
{
    public static class Resource
    {
        #region propriedades

        public const string Nome = "nome";
        public const string Ativo = "ativo";

        #endregion propriedades

        #region Mensagens

        public const string MSG_PrioridadeDaTarefa_Obrigatorio = "A prioridade da tarefa é obrigatória.";
        public const string MSG_Limite_Maximo_de_Tarefa = "Limite máximo de tarefas para o projeto alcançado.";
        public const string MSG_Tipos_PrioridadeDaTarefa_Obrigatorio = "A prioridade da tarefa deve ser uma das seguintes: baixa, média, alta.";
        public const string MSG_Campo_Obrigatorio = @"O campo {0} é obrigatório!";
        public const string MSG_Lengh_Campo = @"O campo {0} deve conter entre {1} e {2} caracteres.";
        public const string MSG_Max_Lengh_Campo = @"O campo {0} deve conter no máximo {1} caracteres.";
        public const string MSG_Campo_Invalido = @"O campo {0} é inválido!";
        public const string MSG_Periodo_Preparacao_Invalido = "O período de preparação é inválido!";
        public const string MSG_Campo_Maior_Zero = @"O campo {0} deve ser maior que zero!";

        #endregion Mensagens
    }
}
