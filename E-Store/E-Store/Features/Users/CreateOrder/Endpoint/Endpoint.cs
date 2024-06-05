using E_Store.Features.Users.CreateOrder.Model;
using E_Store.Domain.Entities;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.Users.CreateOrder.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/users/{UserId}/orders");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        ShoppingCart? cart = await context.ShoppingCarts.Include(x => x.CartItems).FirstOrDefaultAsync(x => x.Id == req.ShoppingCartId);
        AppUser? user = await context.Users.FindAsync(req.UserId);

        if (cart is null || user is null)
        {
            await SendNotFoundAsync(ct);
        }

        ShopOrder order = ShopOrder.Create(cart.Total, req.UserId, cart.CartItems);
        order.CreatedBy = user.Username;
        order.CreatedIn = DateTimeOffset.UtcNow;

        order.CartItems.ForEach(item =>
        {
            Product? product = context.Products.Find(item.ProductId);
            product.UpdateQuantityOnOrderCreate(item.Quantity);
        });

        Response res = mapper.Map<Response>(order);

        await context.Orders.AddAsync(order);
        context.ShoppingCarts.Remove(cart);

        await context.SaveChangesAsync();

        await SendAsync(res, cancellation: ct);
    }
}
