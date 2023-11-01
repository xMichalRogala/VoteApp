using VoteApp.Backend.CQRS.Events.Concrete;
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

        public static WebApplication AddCustomBackgroundTasks(this WebApplication application)
        {
            var eventQueueManager = application.Services.GetRequiredService<EventQueueManager>();

            eventQueueManager.StartWorkAsync();

            return application;
        }
    }
}
