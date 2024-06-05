using Microsoft.IdentityModel.Tokens;

namespace E_Store.Domain.Entities;

public class CartItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Total { get; private set; }
    public int Quantity { get; private set; }
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public Guid? ShoppingCartId { get; private set; }
    public ShoppingCart ShoppingCart { get; private set; }
    public Guid? OrderId { get; private set; }
    public ShopOrder ShopOrder { get; private set; }

    private CartItem(Guid id, string name, decimal total, int quantity, Guid productId)
    {
        Id = id;
        Total = total;
        Name = name;
        Quantity = quantity;
        ProductId = productId;
    }

    public static CartItem Create(string name, decimal price, int quantity, Guid productId)
    {
        decimal total = price * quantity;
        return new CartItem(Guid.NewGuid(), name, total, quantity, productId);
    }

    public void UpdateQuantityMore(int quantity)
    {
        Quantity = Quantity - quantity;
    }

    public void UpdateQuantityLess(int quantity)
    {
        Quantity = Quantity + quantity;
    }
}
