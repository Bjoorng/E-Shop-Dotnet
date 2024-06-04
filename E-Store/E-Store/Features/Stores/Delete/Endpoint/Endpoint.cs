using E_Store.Domain.Entities;
using E_Store.Features.Users.Delete.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;

namespace E_Store.Features.Stores.Delete.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/api/stores/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Store? store = await context.Stores.FindAsync(req.Id);

        if (store == null) 
        {
            await SendNotFoundAsync(ct);
        }

        context.Stores.Remove(store);
        await context.SaveChangesAsync(ct);

        await SendNoContentAsync(cancellation: ct);
    }
}
