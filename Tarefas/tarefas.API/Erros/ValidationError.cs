namespace tarefas.API.Errors
{
    public class ValidationError : Error
    {
        public ValidationError(int code, string message) : base(code, message) { }

        public static ValidationError InvalidRequest = new ValidationError(400, "Requisição inválida");
    }
}
