using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Reflection;
using VoteApp.Backend.Configuration.Extensions;
using VoteApp.Backend.Core.Queries.QueryHandlers;

var builder = WebApplication.CreateBuilder(args);
Assembly coreAssembly = typeof(CandidatesQueryHandler).Assembly;
const string CORS_POLICY = "CorsPolicy";
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(coreAssembly));
builder.AddCustomServices();
builder.AddApplicationDbContext();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: CORS_POLICY,
        builder =>
        {
            builder
            .WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials(); ;
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();
app.UseCors(CORS_POLICY);
app.UseAuthorization();
app.AddCustomMiddlewares();
app.MapControllers();

app.Run();
