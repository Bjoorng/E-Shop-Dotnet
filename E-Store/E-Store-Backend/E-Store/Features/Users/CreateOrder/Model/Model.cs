using AutoMapper;
using E_Store.Domain.Entities;
using E_Store.Features.ShoppingCarts.GetByUserId.Model;

namespace E_Store.Features.Users.CreateOrder.Model;

public record Request(Guid ShoppingCartId, Guid UserId);
public record Response(Guid Id, decimal Total, List<CartItemResponse> CartItems);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ShopOrder, Response>();
    }
}