using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VoteApp.Backend.Core.Data;
using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Concrete;

namespace VoteApp.Backend.Configuration.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddCustomServices(this WebApplicationBuilder builder)
        {
            builder.Services.TryAddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.TryAddScoped(typeof(IReadGenericRepository<>), typeof(ReadGenericRepository<>));
            builder.Services.TryAddScoped<IUnitOfWork, UnitOfWork>();

            return builder;
        }

        public static WebApplicationBuilder AddApplicationDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<VoteAppDbContext>((sp, options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext"));

                if (builder.Environment.IsDevelopment())
                    EnableEfDebugOptions(options);
            });

            return builder;
        }

        private static void EnableEfDebugOptions(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
