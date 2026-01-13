using SistemaAgendamentos.Api.Service;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ServicoService>();
builder.Services.AddScoped<AgendamentoService>();

var app = builder.Build();

// Pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();
app.MapGet("/", () => "API rodando 🚀");

app.Run();

