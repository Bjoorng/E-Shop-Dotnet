namespace E_Store.Features.Users.Create.Model;

public record Request(string Email, string Username, string Password, string Role);

public record Response(Guid Id);