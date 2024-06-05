using E_Store.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace E_Store.Domain.Entities;

public class ShoppingCart : AuditableBaseEntity<Guid>
{
    public decimal Total { get; private set; }
    public Guid UserId { get; private set; }
    public AppUser User { get; private set; }
    public List<CartItem> CartItems { get; private set; }

    private ShoppingCart(Guid id, Guid userId) : base(id)
    {
        UserId = userId;
        CartItems = new List<CartItem>();
    }

    [JsonConstructor]
    private ShoppingCart(Guid id, decimal total, Guid userId) : base(id)
    {
        Total = total;
        UserId = userId;
        CartItems = new List<CartItem>();
    }

    public static ShoppingCart Create(Guid userId, List<CartItem> items)
    {
        ShoppingCart newCart = new ShoppingCart(Guid.NewGuid(), userId);
        newCart.CartItems = items;
        items.ForEach(item =>
        {
            newCart.Total += item.Total;
        });

        return newCart;
    }
}
