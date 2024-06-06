namespace E_Store.Features.Users.CreateStore.Model;

public record Request(string Name, Guid UserId);

public record Response(Guid Id, string Name);