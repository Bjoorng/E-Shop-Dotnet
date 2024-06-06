using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Products.GetById.Model;

public record Request(Guid Id);

public record Response(Guid Id, string Name, string? Description, int Quantity, decimal Price, string Category, Guid StoreId);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<Product, Response>();
    }
}