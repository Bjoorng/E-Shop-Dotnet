using AutoMapper;
using E_Store.Domain.Entities.Common;
using E_Store.Features.Users.GetAll.Model;
using System.Text.Json.Serialization;

namespace E_Store.Domain.Entities;

public class AppUser
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Role {  get; private set; }

    [JsonConstructor]
    private AppUser(Guid id, string username, string password, string role)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
    }

    public static AppUser Create(string username, string password, string role)
    {
        return new AppUser(Guid.NewGuid(), username, password, role);
    }

    public void UpdateUser(string newUsername, string newPassword)
    {
        if (!newUsername.Equals(string.Empty))
        {
            Username = newUsername;
        }
        if (!newPassword.Equals(string.Empty))
        {
            Password = newPassword;
        }
    }

    public class ResponseProfile : Profile
    {
        public ResponseProfile() 
        {
            CreateMap<AppUser, Response>();
        }
    }

}
