using E_Store.Domain.Entities;
using E_Store.Features.ShoppingCarts.Delete.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.ShoppingCarts.Delete.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/api/shoppingcarts/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        ShoppingCart? cart = await context.ShoppingCarts.FindAsync(req.Id);

        if (cart == null) 
        {
            await SendNotFoundAsync(ct);
        }

        context.ShoppingCarts.Remove(cart);

        await context.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}
