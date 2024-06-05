using AutoMapper.QueryableExtensions;
using E_Store.Features.Orders.GetByUserId.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Orders.GetByUserId.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, List<Response>>
{
    public override void Configure()
    {
        Get("/api/orders/{UserId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        List<Response> list = await context.Orders.Where(x => x.UserId == req.UserId).ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(list, cancellation: ct);
    }
}
