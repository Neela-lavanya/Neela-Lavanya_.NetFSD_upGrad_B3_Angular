using WebApplication9.repositories;
using WebApplication9.repositories;
using WebApplication9.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Memory Cache
builder.Services.AddMemoryCache();

// Dependency Injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();