using E_Store.Features.Stores.GetById.Model;
using E_Store.Domain.Entities;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Stores.GetById.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/api/stores/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Store? store = await context.Stores.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == req.Id);
        List<ProductForStoreResponse> products = new();

        store.Products.ForEach(product =>
        {
            ProductForStoreResponse response = mapper.Map<ProductForStoreResponse>(product);
            products.Add(response);
        });

        await SendAsync(new Response(store.Id, store.Name, store.UserId, products), cancellation: ct);
    }
}
