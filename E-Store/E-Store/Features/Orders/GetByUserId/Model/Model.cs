using AutoMapper;
using E_Store.Domain.Entities;
using E_Store.Features.ShoppingCarts.GetByUserId.Model;

namespace E_Store.Features.Orders.GetByUserId.Model;

public record Request(Guid UserId);
public record Response(Guid Id, string OrderNumber, decimal Total, Guid UserId, List<CartItemResponse> CartItems);

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<ShopOrder, Response>();
    }
}
