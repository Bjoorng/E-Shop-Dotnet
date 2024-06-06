using E_Store.Domain.Entities;
using E_Store.Features.Users.CreateShoppingCart.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;

namespace E_Store.Features.Users.CreateShoppingCart.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/users/{UserId}/shoppingcarts");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        AppUser? user = await context.Users.FindAsync(req.UserId);

        if (user == null)
        {
            await SendNotFoundAsync(ct);
        }

        List<CartItem> items = new();
        req.CartItems.ForEach(item =>
        {
            CartItem itemToAdd = CartItem.Create(item.Name, item.Price, item.Quantity, item.ProductId);
            items.Add(itemToAdd);
        });

        ShoppingCart cart = ShoppingCart.Create(req.UserId, items);
        cart.CreatedBy = user.Username;
        cart.CreatedIn = DateTimeOffset.UtcNow;

        Response res = mapper.Map<Response>(cart);

        await context.ShoppingCarts.AddAsync(cart);
        await context.SaveChangesAsync(ct);

        await SendAsync(res, cancellation: ct);
    }
}
