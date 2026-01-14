using SistemaAgendamentos.Api.Service;
using Microsoft.EntityFrameworkCore;
using SistemaAgendamentos.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ServicoService>();
builder.Services.AddScoped<AgendamentoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();
app.MapGet("/", () => "API rodando 🚀");

app.Run();

