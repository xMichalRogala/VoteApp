using VoteApp.Backend.Configuration.Extensions;
using VoteApp.Backend.CQRS.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddCustomServices();
builder.AddApplicationDbContext();
builder.Services.AddCustomCqrs(commandOpt =>
{
    commandOpt.AllowCommandExecuteByMoreThanOneCommandHandler = false;
}, eventOpt =>
{
    eventOpt.ParallelDegree = 2;
    eventOpt.Delay = 5000;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.AddCustomMiddlewares();
app.MapControllers();

app.Run();
