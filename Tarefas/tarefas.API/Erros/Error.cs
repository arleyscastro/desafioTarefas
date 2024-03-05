namespace tarefas.API.Errors
{
    public abstract class Error
    {
        protected Error(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; private set; }
        public string Message { get; private set; }
    }
}