namespace E_Store.Features.Stores.CreateProduct.Model;

public record Request(string Name, string Summary, int Quantity, decimal Price, string Category, Guid StoreId);

public record Response(Guid Id, string Name, int Quantity, decimal Price);