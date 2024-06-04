using E_Store.Domain.Entities;
using E_Store.Features.Products.Update.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;

namespace E_Store.Features.Products.Update.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Put("/api/products/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Product? product = await context.Products.FindAsync(req.Id);
        if (product == null)
        {
            await SendNotFoundAsync(ct);
        }

        product.Update(req.Name, req.Summary, req.Description, req.Quantity, req.Price, req.Category);
        Response res = mapper.Map<Response>(product);

        await context.SaveChangesAsync();

        await SendAsync(res, cancellation: ct);
    }
}
