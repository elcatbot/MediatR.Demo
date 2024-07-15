using Demo.Commands;
using Demo.Handlers;
using Demo.Infrastructure;
using Demo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderContext>(o => o.UseInMemoryDatabase("OrdersDB"));

builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();

builder.Services.AddMediatR(cg => cg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/orders", async ([FromServices] IMediator mediator) => 
{
    var list = await mediator.Send(new GetListOrderQuery());

    return Results.Ok(list);
});

app.MapGet("/api/orders/{id}", async (int id, IMediator mediator) => 
{
    var list = await mediator.Send(new GetOrderQuery { OrderId = id});

    return Results.Ok(list);
});

app.MapPost("/api/orders", async ([FromBody] CreateOrderCommand command, [FromServices] IMediator mediator) => 
{
    await mediator.Send(command);

    return Results.Created();
});

app.Run();
