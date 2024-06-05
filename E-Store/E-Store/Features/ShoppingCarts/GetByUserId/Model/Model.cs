using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.ShoppingCarts.GetByUserId.Model;

public record Request(Guid UserId);
public record Response(Guid Id, decimal Total, Guid UserId, List<CartItemResponse> CartItems);
public record CartItemResponse(Guid Id, string Name, decimal Total, int Quantity, Guid ProductId);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<CartItem, CartItemResponse>();
        CreateMap<ShoppingCart, Response>();
    }
}
