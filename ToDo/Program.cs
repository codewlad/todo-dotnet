using ToDo.App.Application;
using ToDo.App.Interfaces;
using ToDo.App.Mapper;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Repositories.DataConnector;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Services;
using ToDo.Infra.DataConnector;
using ToDo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddScoped<IDbConnector>(db => new SqlConnector(connectionString));

builder.Services.AddAutoMapper(typeof(Core));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
