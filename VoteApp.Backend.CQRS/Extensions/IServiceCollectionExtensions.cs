using Microsoft.Extensions.DependencyInjection;
using VoteApp.Backend.Commons.Assemblies;
using VoteApp.Backend.CQRS.BackgroundServices;
using VoteApp.Backend.CQRS.Commands.Abstract;
using VoteApp.Backend.CQRS.Commands.Concrete;
using VoteApp.Backend.CQRS.Commands.Models;
using VoteApp.Backend.CQRS.Events.Abstract;
using VoteApp.Backend.CQRS.Events.Concrete;
using VoteApp.Backend.CQRS.Events.Models;
using VoteApp.Backend.CQRS.Queries.Abstract;
using VoteApp.Backend.CQRS.Queries.Concrete;

namespace VoteApp.Backend.CQRS.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private static IServiceCollection AddHandlersToServices(this IServiceCollection services, Type handlerType)
        {
            var assemblies = LoadAllAssemblies.Get(); //todo create cache assemblies contaieer as singleton

            foreach (var assembly in assemblies)
            {
                var commandHandlers = assembly.GetTypes().Where(t => t.GetInterfaces().Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == handlerType));

                foreach (var handler in commandHandlers)
                {
                    services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerType), handler);
                }
            }

            return services;
        }

        private static IServiceCollection AddCommands(this IServiceCollection services, Action<CommandOptions> opt)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddHandlersToServices(typeof(ICommandHandler<>));
            services.AddOptions<CommandOptions>().Configure(opt);

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.AddHandlersToServices(typeof(IQueryHandler<,>));

            return services;
        }

        private static IServiceCollection AddEvents(this IServiceCollection services, Action<EventOptions> opt)
        {
            services.AddSingleton<IEventDispatcher, EventDispatcher>();
            services.AddHandlersToServices(typeof(IEventHandler<>));
            services.AddSingleton<EventQueueManager>();
            services.AddOptions<EventOptions>().Configure(opt);
            services.AddHostedService<EventQueueManagerHostedService>();

            return services;
        }

        public static IServiceCollection AddCustomCqrs(
            this IServiceCollection services, 
            Action<CommandOptions> commandOptions, 
            Action<EventOptions> eventOptions)
        {
            services.AddCommands(commandOptions);
            services.AddQueries();
            services.AddEvents(eventOptions);

            return services;
        }
    }
}
