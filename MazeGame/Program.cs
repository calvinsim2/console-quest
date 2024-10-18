using MazeGameApplication.Interfaces;
using MazeGameApplication.Services;
using MazeGameDomain.Interfaces;
using MazeGameDomain.Interfaces.DecisionTrees;
using MazeGameDomain.Services;
using MazeGameDomain.Services.DecisionTrees;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMazeGameApplicationService, MazeGameApplicationService>();
builder.Services.AddScoped<IMazeGameService, MazeGameService>();

/// <summary>
/// Maps DI
/// </summary>
builder.Services.AddScoped<IIceCavern, IceCavern>();
builder.Services.AddScoped<IFireCavern, FireCavern>();
builder.Services.AddScoped<IThickForest, ThickForest>();
builder.Services.AddScoped<ISkyCastle, SkyCastle>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
