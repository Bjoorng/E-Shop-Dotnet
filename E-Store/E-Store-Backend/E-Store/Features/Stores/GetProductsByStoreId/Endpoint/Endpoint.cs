using E_Store.Infrastructure.Data;
using E_Store.Features.Stores.GetProductsByStoreId.Model;
using FastEndpoints;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Stores.GetProductsByStoreId.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, List<Response>>
{
    public override void Configure()
    {
        Get("/api/stores/{StoreId}/products");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        List<Response> list = await context.Products.Where(x => x.StoreId == req.StoreId).ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);
        
        await SendAsync(list, cancellation: ct);
    }
}