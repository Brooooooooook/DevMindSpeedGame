using DevMindSpeedGame.Data;
using DevMindSpeedGame.Repository;
using DevMindSpeedGame.Repository.IRepository;
using DevMindSpeedGame.Services;
using DevMindSpeedGame.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IMathRepository, MathRepository>();
builder.Services.AddScoped<IGameStartService, GameStartService>();
builder.Services.AddScoped<ISubmitAnswerService, SubmitAnswerService>();
builder.Services.AddScoped<IGameEndService, GameEndService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
