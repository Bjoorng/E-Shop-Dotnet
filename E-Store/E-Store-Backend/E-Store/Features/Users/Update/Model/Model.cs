namespace E_Store.Features.Users.Update.Model;

public record Request(Guid Id, string Email, string Username, string Password);

public record Response(Guid Id, string Username, string Password);
