using VoteApp.Backend.Middlewares;

namespace VoteApp.Backend.Configuration.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication AddCustomMiddlewares(this WebApplication application)
        {
            application.UseMiddleware<OperationCanceledMiddleware>();

            return application;
        }
    }
}
