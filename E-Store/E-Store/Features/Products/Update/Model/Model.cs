using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Products.Update.Model;

public record Request(Guid Id, string Name, string Summary, string Description, string Quantity, string Price, string Category);

public record Response(Guid Id);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<Product, Response>();
    }
}
