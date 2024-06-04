using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.ShoppingCarts.GetByUserId.Model;

public record Request(Guid UserId);
public record Response(decimal Total, Guid UserId, List<CartItemResponse> Items);
public record CartItemResponse(string Name, decimal Total, int Quantity, Guid ProductId);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<CartItem, CartItemResponse>();
        CreateMap<ShoppingCart, Response>();
    }
}
