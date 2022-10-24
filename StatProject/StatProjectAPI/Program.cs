using StatProjectLib.Commands.Simple;
using StatProjectLib.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMyFactory<ISimpleCommand>>(x =>
{
    var simpleCommandFactory = new MySimpleCommandFactory();
    simpleCommandFactory.Register("avg", () => new AverageCommand());
    simpleCommandFactory.Register<VarianceCommand>("var");
    simpleCommandFactory.Register<StandardDeviationCommand>("std");
    return simpleCommandFactory;
});

builder.Services.AddSingleton<IFactory<ISimpleCommand>, SimpleCommandFactory>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
