using E_Store.Domain.Entities;
using E_Store.Features.Orders.Delete.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Orders.Delete.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/api/orders/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        ShopOrder? order = await context.Orders.Include(x => x.CartItems).FirstOrDefaultAsync(x => x.Id == req.Id);

        if (order == null) 
        {
            await SendNotFoundAsync(ct);
        }

        order.CartItems.ForEach(item =>
        {
            Product? product = context.Products.Find(item.ProductId);
            product.UpdateQuantityOnOrderDelete(item.Quantity);
        });

        context.Orders.Remove(order);
        await context.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}
