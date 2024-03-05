using Microsoft.AspNetCore.Mvc;
using System.Net;
using tarefas.API.Errors;

namespace tarefas.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult BadRequest(ErrorResponse response)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, response);
        }

        protected IActionResult BadRequest(string message, object details = null)
        {
            return BadRequest(new ErrorResponse(message, details));
        }

        protected IActionResult BadRequest(Error error, object details = null)
        {
            return BadRequest(new ErrorResponse(error, details));
        }

        protected IActionResult Conflict(ErrorResponse response)
        {
            return StatusCode((int)HttpStatusCode.Conflict, response);
        }

        protected IActionResult Created()
        {
            return StatusCode((int)HttpStatusCode.Created);
        }

        protected IActionResult Created<T>(T content)
        {
            return StatusCode((int)HttpStatusCode.Created, content);
        }

        protected IActionResult Forbidden(string reason)
        {
            return StatusCode((int)HttpStatusCode.Forbidden, new ErrorResponse("Permissão insuficiente", reason));
        }

        protected IActionResult NotFound(ErrorResponse response)
        {
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }

        protected IActionResult NotFound(string message, object details = null)
        {
            return NotFound(new ErrorResponse(message, details));
        }

        protected IActionResult NotFound(Error error, object details = null)
        {
            return NotFound(new ErrorResponse(error, details));
        }

        protected IActionResult StatusCodeWithContent<T>(HttpStatusCode statusCode, T content)
        {
            return new ObjectResult(content)
            {
                StatusCode = (int)statusCode
            };
        }

        protected async Task<IActionResult> With<T>(T value, Func<T, Task<IActionResult>> process)
        {
            return await process?.Invoke(value);
        }
    }
}
