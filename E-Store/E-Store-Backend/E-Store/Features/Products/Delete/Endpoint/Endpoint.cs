using E_Store.Features.Products.Delete.Model;
using E_Store.Domain.Entities;
using E_Store.Infrastructure.Data;
using FastEndpoints;

namespace E_Store.Features.Products.Delete.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyRequest>
{
    public override void Configure()
    {
        Delete("/api/products/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Product? product = await context.Products.FindAsync(req.Id);

        if (product == null) 
        {
            await SendNotFoundAsync();
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        
        await SendNoContentAsync(ct);
    }
}
