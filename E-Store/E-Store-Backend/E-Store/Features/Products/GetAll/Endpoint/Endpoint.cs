using AutoMapper.QueryableExtensions;
using E_Store.Features.Products.GetAll.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Products.GetAll.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<Response>>
{
    public override void Configure()
    {
        Get("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        List<Response> list = await context.Products.ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(ct);

        await SendAsync(list, cancellation: ct);
    }
}
