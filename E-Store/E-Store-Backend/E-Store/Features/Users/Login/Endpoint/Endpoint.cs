using E_Store.Infrastructure.Data;
using E_Store.Features.Users.Login.Model;
using FastEndpoints;
using E_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Users.Login.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("api/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        AppUser? user = await context.Users.FirstOrDefaultAsync(x => x.Username == req.Username && x.Password == req.Password);

        if (user == null) {
            await SendNotFoundAsync(ct);
        }
        
        Response res = mapper.Map<Response>(user);

        await SendAsync(res, cancellation: ct);
    }
}
