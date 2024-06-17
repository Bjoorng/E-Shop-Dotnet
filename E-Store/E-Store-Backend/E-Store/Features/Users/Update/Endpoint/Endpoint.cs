using E_Store.Domain.Entities;
using E_Store.Features.Users.Update.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;

namespace E_Store.Features.Users.Update.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Put("/api/users/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        AppUser? user = await context.Users.FindAsync(req.Id);

        if (user == null)
        {
            await SendNotFoundAsync(ct);
        }

        user.UpdateUser(req.Email, req.Username, req.Password);
        await context.SaveChangesAsync();

        await SendAsync(new Response(user.Id, user.Username, user.Password), cancellation: ct);
    }
}
