using AutoMapper.QueryableExtensions;
using E_Store.Features.Products.GetByPriceHigherThan.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Products.GetByPriceHigherThan.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, List<Response>>
{
    public override void Configure()
    {
        Get("/api/products/{PriceHigh}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        List<Response> list = await context.Products.Where(x => x.Price > req.PriceHigh).ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(list, cancellation: ct);
    }
}
