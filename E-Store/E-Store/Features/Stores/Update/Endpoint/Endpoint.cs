using E_Store.Domain.Entities;
using E_Store.Features.Stores.Update.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;

namespace E_Store.Features.Stores.Update.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Put("/api/stores/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Store? store = await context.Stores.FindAsync(req.Id);

        if (store == null)
        {
            await SendNotFoundAsync(ct);
        }

        store.Update(req.Name);

        await context.SaveChangesAsync();

        Response res = mapper.Map<Response>(store);

        await SendAsync(res, cancellation: ct);
    }
}
