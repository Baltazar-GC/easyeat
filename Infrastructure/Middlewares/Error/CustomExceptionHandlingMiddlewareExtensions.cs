using easyeat.Business.Exceptions;

namespace easyeat.Infrastructure.Middlewares.Error
{
    public static class CustomExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware<CustomExceptionHandlingMiddleware>();
    }

    public class CustomExceptionHandlingMiddleware
    {
        private const string formUrlEncodedContentType = "application/x-www-form-urlencoded";
        private const string formDataContentType = "multipart/form-data";
        private const string jsonContentType = "application/json";

        private readonly RequestDelegate next;

        public CustomExceptionHandlingMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                if(IsBusinessException(context, ex))
                {
                    context.Response.ContentType = jsonContentType;
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync(ex.Message);

                    return;
                }

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }

        private static bool IsBusinessException(HttpContext context, Exception error) 
        {
            if(error == null)
                return false;

            if (context?.Request?.Path == null)
                return false;

            if(error is EasyeatBusinessException)
            {
                return true;
            }

            return error.GetType().IsSubclassOf(typeof(EasyeatBusinessException));
        }
    }
}
