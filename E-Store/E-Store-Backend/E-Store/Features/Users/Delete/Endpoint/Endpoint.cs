using E_Store.Domain.Entities;
using E_Store.Features.Users.Delete.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;

namespace E_Store.Features.Users.Delete.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/api/users/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        AppUser? user = await context.Users.FindAsync(req.Id);

        if (user == null) 
        {
            await SendNotFoundAsync(ct);
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}
