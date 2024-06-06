using AutoMapper.QueryableExtensions;
using E_Store.Features.Users.GetAll.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Users.GetAll.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<Response>>
{
    public override void Configure()
    {
        Get("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        List<Response> users = await context.Users.ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(users, cancellation: ct);
    }
}
