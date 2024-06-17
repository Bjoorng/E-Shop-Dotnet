using AutoMapper.QueryableExtensions;
using E_Store.Features.Orders.GetAll.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Orders.GetAll.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<Response>>
{
    public override void Configure()
    {
        Get("/api/orders");
        AllowAnonymous();
    }
    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        List<Response> orders = await context.Orders.ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(orders, cancellation: ct);
    }
}
