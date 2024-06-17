using E_Store.Domain.Entities;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using E_Store.Features.Users.Create.Model;

namespace E_Store.Features.Users.Create.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        AppUser user = AppUser.Create(req.Email, req.Username, req.Password, req.Role);

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync(ct);

        await SendAsync(new Response(user.Id), cancellation: ct);
    }
}
