using Microsoft.EntityFrameworkCore;
using TextAnalysis;
using TextAnalysis.Interfaces;
using TextProcess.Database;
using TextProcess.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISentencesParser, SentencesParser>();
builder.Services.AddScoped<IFrequencyAnalysis, FrequencyAnalysis>();
builder.Services.AddScoped<ISentenceGenerator, SentenceGenerator>();
builder.Services.AddScoped<TextProcessRepository>();

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	app.UseReDoc();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();