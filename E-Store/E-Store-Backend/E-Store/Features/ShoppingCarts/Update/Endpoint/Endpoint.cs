using E_Store.Domain.Entities;
using E_Store.Features.ShoppingCarts.Update.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.ShoppingCarts.Update.Endpoint;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
{
    public override void Configure()
    {
        Put("/api/shoppingcarts/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        ShoppingCart? cart = await context.ShoppingCarts.Include(x => x.CartItems).FirstOrDefaultAsync(x => x.Id == req.Id);

        if (cart == null)
        {
            await SendNotFoundAsync(ct);
        }

        CartItem? item = cart.CartItems.FirstOrDefault(x => x.Id == req.CartItemId);

        if (item == null)
        {
            await SendNotFoundAsync(ct);
        }

        decimal price = item.Total / item.Quantity;

        if (req.Condition.ToUpper().Equals("REMOVE"))
        {
            item.UpdateQuantityLess(req.Quantity);
            if (item.Quantity > 0)
            {
                item.CalculateTotal(price, item.Quantity);
                context.CartItems.Update(item);
            }
            else
            {
                context.CartItems.Remove(item);
            }
            await context.SaveChangesAsync(ct);
        }
        else if (req.Condition.ToUpper().Equals("ADD"))
        {
            item.UpdateQuantityMore(req.Quantity);
            item.CalculateTotal(price, item.Quantity);
            context.CartItems.Update(item);
            await context.SaveChangesAsync(ct);
        }

        if (cart.CartItems.Count > 0)
        {
            cart.CalculateTotal(cart.CartItems);
        }
        else
        {
            context.ShoppingCarts.Remove(cart);
        }

        await context.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}
