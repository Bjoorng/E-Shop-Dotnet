using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Stores.GetById.Model;

public record Request(Guid Id);

public record Response(Guid Id, string Name, Guid UserId, List<ProductForStoreResponse> Products);

public record ProductForStoreResponse(Guid Id, string Name, string Summary, decimal Price, string Category);

public class ProductForStoreProfile : Profile
{
    public ProductForStoreProfile() 
    {
        CreateMap<Product, ProductForStoreResponse>();
    }
}
