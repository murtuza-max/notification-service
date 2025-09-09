using MessagingService.Controllers;
using MessagingService.Data;
using MessagingService.Model;
using MessagingService.Validation;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Reflection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSqlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MessageDb"))
);

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<MessageValidator>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

var v1 = app.MapGroup("/v1");
v1.MapDelete("/message/{id}", MessageEndPoint.DeleteMessage)
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status401Unauthorized)
    .Produces(StatusCodes.Status403Forbidden)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status500InternalServerError)
    .Produces(StatusCodes.Status503ServiceUnavailable);

v1.MapGet("/message/{id}", MessageEndPoint.GetMessage)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status500InternalServerError);

v1.MapPost("/message", MessageEndPoint.SendMessage)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status500InternalServerError);

app.Run();