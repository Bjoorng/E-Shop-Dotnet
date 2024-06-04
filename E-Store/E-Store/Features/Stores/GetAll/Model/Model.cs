using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Stores.GetAll.Model;

public record Response(Guid Id, string Name);

public class ResponseMapper : Profile
{
    public ResponseMapper()
    {
        CreateMap<Store, Response>();
    }
}