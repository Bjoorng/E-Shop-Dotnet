using E_Store.Infrastructure.Data;
using E_Store.Domain.Entities;
using E_Store.Features.Products.GetById.Model;
using FastEndpoints;

namespace E_Store.Features.Products.GetById.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/api/products/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Product? product = await context.Products.FindAsync(req.Id);

        if(product == null)
        {
            await SendNotFoundAsync(ct);
        }

        Response res = mapper.Map<Response>(product);

        await SendAsync(res, cancellation: ct);
    }
}
