using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Stores.Update.Model;

public record Request(Guid Id, string Name);

public record Response(Guid Id, string Name);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<Store, Response>();
    }
}
