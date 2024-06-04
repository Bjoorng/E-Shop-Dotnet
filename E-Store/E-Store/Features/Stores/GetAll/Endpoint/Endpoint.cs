using E_Store.Infrastructure.Data;
using E_Store.Features.Stores.GetAll.Model;
using FastEndpoints;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Stores.GetAll.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<Response>>
{
    public override void Configure()
    {
        Get("/api/stores");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        List<Response> list = await context.Stores.ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(list, cancellation: ct);
    }
}
