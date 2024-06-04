namespace E_Store.Features.Users.GetById.Model;

public record Request(Guid Id);

public record Response(Guid Id, string Username, string Password);
