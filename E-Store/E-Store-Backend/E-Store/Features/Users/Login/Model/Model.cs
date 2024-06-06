using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.Users.Login.Model;

public record Request(string Username, string Password);

public record Response(Guid Id, string Username, string Password, string Role);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<AppUser, Response>();
    }
}