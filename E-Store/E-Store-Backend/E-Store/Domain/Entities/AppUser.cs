using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace E_Store.Domain.Entities;

public class AppUser
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    [JsonConstructor]
    private AppUser(Guid id, string email, string username, string password, string role)
    {
        Id = id;
        Email = email;
        Username = username;
        Password = password;
        Role = role;
    }

    public static AppUser Create(string email, string username, string password, string role)
    {
        return new AppUser(Guid.NewGuid(), email, username, password, role);
    }

    public void UpdateUser(string newEmail, string newUsername, string newPassword)
    {
        if (!newEmail.Equals(string.Empty)){
            Email = newEmail;
        }
        if (!newUsername.Equals(string.Empty))
        {
            Username = newUsername;
        }
        if (!newPassword.Equals(string.Empty))
        {
            Password = newPassword;
        }
    }
}
