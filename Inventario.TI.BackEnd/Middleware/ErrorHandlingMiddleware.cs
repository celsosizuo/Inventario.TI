using Inventario.TI.Core.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Inventario.TI.BackEnd.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Não capturar exceptions de tipos genéricos", Justification = "Serialização de todas as Exceções para enviar para o client")]
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (ex is BusinessException)
            {
                code = HttpStatusCode.BadRequest;
            }

            var result = JsonConvert.SerializeObject(new { status = (int)code, message = ex.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            Console.WriteLine("* Ocorreu um erro na requisição para '{0}'\r\n{1}",
                context.Request.Path,
                ex is AggregateException ? string.Join("\r\n>>", ((AggregateException)ex).InnerExceptions.Select(e => e.Message)) : ex.Message);

            return context.Response.WriteAsync(result);
        }
    }
}
