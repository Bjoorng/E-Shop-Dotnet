using E_Store.Domain.Entities;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using E_Store.Features.Stores.CreateProduct.Model;

namespace E_Store.Features.Stores.CreateProduct.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/{StoreId}/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Store? store = await context.Stores.FindAsync(req.StoreId);

        if (store == null)
        {
            await SendNotFoundAsync(ct);
        }

        Product product = Product.Create(req.Name, req.Summary, req.Quantity, req.Price, req.Category, req.StoreId);

        product.CreatedBy = store.Name;
        product.CreatedIn = DateTimeOffset.UtcNow;

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync(ct);

        await SendAsync(new Response(product.Id, product.Name, product.Quantity, product.Price), cancellation: ct);
    }
}
