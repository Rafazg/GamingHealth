using GamingHealth.Application.UseCases.GetPlayerById;
using GamingHealth.Application.UseCases.ListPlayers;
using GamingHealth.Infrastructure.Data;
using GamingHealth.Infrastructure.Repositories;
using GamingHealth.Domain.Interfaces;
using GamingHealth.Domain.Entities;
using GamingHealth.Application.UseCases.UpdatePlayerIncome;

var builder = WebApplication.CreateBuilder(args);

// Conexão Oracle
var connectionString = builder.Configuration.GetConnectionString("OracleConnection")!;
builder.Services.AddSingleton(new OracleDbContext(connectionString));

// Repositórios
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// Use Cases
builder.Services.AddScoped<ListPlayersUseCase>();
builder.Services.AddScoped<GetPlayerByIdUseCase>();
builder.Services.AddScoped<UpdatePlayerIncomeUseCase>();

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
