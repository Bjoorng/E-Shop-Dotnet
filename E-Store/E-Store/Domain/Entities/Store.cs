using AutoMapper;
using E_Store.Domain.Entities.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace E_Store.Domain.Entities;

public class Store : AuditableBaseEntity<Guid>
{
    public string Name { get; private set; }
    public Guid UserId { get; private set; }
    public AppUser User { get; private set; }
    public List<Product> Products { get; private set; }

    [JsonConstructor]
    private Store(Guid id, string name, Guid userId) : base(id)
    {
        Name = name;
        UserId = userId;
        Products = new List<Product>();
    }

    public static Store Create(string name, Guid userId)
    {
        return new Store(Guid.NewGuid(), name, userId);
    }

    public Product AddItem(string name, string summary, int quantity, decimal price, string category)
    {
        Product product = Product.Create(name, summary, quantity, price, category, Id);
        Products.Add(product);
        return product;
    }

    public void Update(string name)
    {
        if (!name.IsNullOrEmpty())
        {
            Name = name;
        }
    }
}

