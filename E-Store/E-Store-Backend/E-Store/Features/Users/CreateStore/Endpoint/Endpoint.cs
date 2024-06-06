using E_Store.Domain.Entities;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using E_Store.Features.Users.CreateStore.Model;

namespace E_Store.Features.Users.CreateStore.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/{UserId}/stores");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        AppUser? user = await context.Users.FindAsync(req.UserId);
        if (user == null) 
        {
            await SendNotFoundAsync(ct);
        }

        Store store = Store.Create(req.Name, req.UserId);

        store.CreatedBy = user.Username;
        store.CreatedIn = DateTimeOffset.UtcNow;

        await context.Stores.AddAsync(store);
        await context.SaveChangesAsync(ct);

        await SendAsync(new Response(store.Id, store.Name), cancellation: ct);
    }
}
