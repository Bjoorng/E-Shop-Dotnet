using AutoMapper;
using E_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace E_Store.Features.Users.CreateShoppingCart.Model;

public record Request(Guid UserId, List<CartItemRequest> CartItems);
public record CartItemRequest(string Name, decimal Price, int Quantity, Guid ProductId);
public record Response();

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ShoppingCart, Response>();
    }
}
