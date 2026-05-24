using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Mapping;
using TaskManagement.Application.Validations;
using TaskManagement.Infrastructure.Context;
using TaskManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTaskDtoValidator>();

// Add services to the container.
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<TaskManagement.WebAPI.Middlewares.ExceptionMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Bazı şablonlarda burası boş kalırsa rota şaşırabilir, garantiye alalım:
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Management API V1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
