using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Users.GetById.Model;

public record Request(Guid Id);

public record Response(Guid Id, string Username, string Password);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<AppUser, Response>();
    }
}
