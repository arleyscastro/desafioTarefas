using Newtonsoft.Json;
using System.Web.Http.ModelBinding;

namespace tarefas.API.Errors
{
    public class ErrorResponse
    {
        public ErrorResponse(Error error, object details = null)
        {
            Code = error.Code;
            Message = error.Message;
            Details = details;
        }

        public ErrorResponse(string message, object details = null)
        {
            Message = message;
            Details = details;
        }

        public ErrorResponse(string message) => Message = message;

        public ErrorResponse(string message, ModelStateDictionary modelState)
            : this(message, FormatModelState(modelState))
        {
        }

        public ErrorResponse(Error error, ModelStateDictionary modelState)
            : this(error, FormatModelState(modelState))
        {
        }

        private static object FormatModelState(ModelStateDictionary modelState)
        {
            return modelState.Where(item => item.Value.Errors.Count > 0)
                             .ToDictionary(item => item.Key, item => item.Value.Errors.Select(GetErrorMessage));
        }

        private static string GetErrorMessage(ModelError error)
        {
            return !string.IsNullOrEmpty(error.ErrorMessage)
                ? error.ErrorMessage
                : error.Exception != null ? error.Exception.Message : "";
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Details { get; private set; }
    }
}