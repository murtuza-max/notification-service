using PaymentService.Controllers;
using PaymentService.Data;
using PaymentService.Model;
using PaymentService.Validation;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Reflection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSqlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PaymentDb"))
);

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<PaymentValidator>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
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
v1.MapPost("/payment/refund/{id}", PaymentEndPoint.RefundPayment)
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status401Unauthorized)
    .Produces(StatusCodes.Status403Forbidden)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status500InternalServerError)
    .Produces(StatusCodes.Status503ServiceUnavailable);

v1.MapGet("/payment/{id}", PaymentEndPoint.GetPayment)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status500InternalServerError);

v1.MapPost("/payment", PaymentEndPoint.ProcessPayment)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status500InternalServerError);

app.Run();