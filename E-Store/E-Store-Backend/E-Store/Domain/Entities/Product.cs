using E_Store.Domain.Entities.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace E_Store.Domain.Entities;

public class Product : AuditableBaseEntity<Guid>
{
    public string Name { get; private set; }
    public string Summary { get; private set; }
    public string? Description { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public string Category { get; private set; }
    public Guid StoreId { get; private set; }
    public Store Store { get; private set; }
    public List<CartItem> CartItems { get; private set; }

    private Product(Guid id, string name, string summary, int quantity, decimal price, string category, Guid storeId) : base(id)
    {
        Name = name;
        Summary = summary;
        Quantity = quantity;
        Price = price;
        Category = category;
        StoreId = storeId;
    }

    [JsonConstructor]
    private Product(Guid id, string name, string summary, string description, int quantity, decimal price, string category, Guid storeId) : base(id)
    {
        Name = name; 
        Summary = summary;
        Description = description;
        Quantity = quantity; 
        Price = price; 
        Category = category;
        StoreId = storeId;
    }

    public static Product Create(string name, string summary, int quantity, decimal price, string category, Guid storeId)
    {
        return new Product(Guid.NewGuid(), name, summary, quantity, price, category, storeId);
    }

    public void Update(string newName, string newSummary, string newDescription, string newQuantity, string newPrice, string newCategory)
    {
        if (!newName.IsNullOrEmpty()) 
        {
            Name = newName;
        }
        if (!newSummary.IsNullOrEmpty())
        {
            Summary = newSummary;
        }
        if (!newDescription.IsNullOrEmpty()) 
        {
            Description = newDescription;
        }
        if (!newQuantity.IsNullOrEmpty() && int.TryParse(newQuantity, out int parsedQuantity))
        {
            Quantity = parsedQuantity;
        }
        if (!newPrice.IsNullOrEmpty() && decimal.TryParse(newPrice, out decimal parsedPrice))
        {
            Price = parsedPrice;
        }
        if (!Category.IsNullOrEmpty())
        {
            Category = newCategory;
        }
    }

    public void UpdatePrice(string newPrice)
    {
        if (!newPrice.IsNullOrEmpty() && decimal.TryParse(newPrice, out decimal parsedPrice))
        {
            Price = parsedPrice;
        }
    }

    public void UpdateQuantityOnOrderCreate(int quantity) 
    {
        Quantity = Quantity - quantity;
    }

    public void UpdateQuantityOnOrderDelete(int quantity)
    {
        Quantity = Quantity + quantity;
    }
}
