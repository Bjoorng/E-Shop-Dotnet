using AutoMapper;
using E_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace E_Store.Features.Users.GetAll.Model;

public record Response(Guid Id, string Username, string Role);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<AppUser, Response>();
    }
}