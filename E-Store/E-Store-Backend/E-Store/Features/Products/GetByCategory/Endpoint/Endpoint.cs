using AutoMapper.QueryableExtensions;
using E_Store.Features.Products.GetByCategory.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Products.GetByCategory.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, List<Response>>
{
    public override void Configure()
    {
        Get("/api/products/{Category}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        List<Response> list = await context.Products.Where(x => x.Category == req.Category).ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(list, cancellation: ct);
    }
}
