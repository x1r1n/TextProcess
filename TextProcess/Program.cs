using Microsoft.EntityFrameworkCore;
using PhraseForge;
using PhraseForge.Interfaces;
using TextProcess.Database;
using TextProcess.Services;
using TextProcess.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISentencesParser, SentencesParser>();
builder.Services.AddScoped<IFrequencyAnalysis, FrequencyAnalysis>();
builder.Services.AddScoped<ISentenceGenerator, SentenceGenerator>();
builder.Services.AddScoped<IPhraseGeneratorService, PhraseGeneratorService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();