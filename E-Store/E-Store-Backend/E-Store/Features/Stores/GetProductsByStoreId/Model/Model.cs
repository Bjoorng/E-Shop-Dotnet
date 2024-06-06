using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Stores.GetProductsByStoreId.Model;

public record Request(Guid StoreId);
public record Response(Guid Id, string Name, string Summary, decimal Price);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<Product, Response>();
    }
}