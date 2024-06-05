using E_Store.Domain.Entities;
using E_Store.Features.ShoppingCarts.GetByUserId.Model;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Features.ShoppingCarts.GetByUserId.Endpoint;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/api/shoppingcarts/{UserId}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        ShoppingCart? cart = await context.ShoppingCarts.Include(x => x.CartItems).FirstOrDefaultAsync(x => x.UserId == req.UserId);

        if (cart == null) 
        {
            await SendNotFoundAsync(ct);
        }

        Response res = mapper.Map<Response>(cart);

        await SendAsync(res, cancellation: ct);
    }
}
