using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Orders.GetAll.Model;

public record Response(string OrderNumber, decimal Total, Guid UserId);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ShopOrder, Response>();
    }
}