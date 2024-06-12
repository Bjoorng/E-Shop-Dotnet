using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Products.GetByPriceLowerThan.Model;

public record Request(decimal Price);
public record Response(Guid Id, string Name, string Summary, int Quantity, decimal Price, string Category, Guid StoreId);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<Product, Response>();
    }
}