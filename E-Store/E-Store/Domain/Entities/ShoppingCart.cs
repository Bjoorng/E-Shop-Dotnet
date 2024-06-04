using E_Store.Domain.Entities.Common;

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
    }

    private static ShoppingCart Create(Guid userId, List<CartItem> items)
    {
        ShoppingCart newCart = new ShoppingCart(Guid.NewGuid(), userId);
        items.ForEach(item =>
        {
            newCart.Total += item.Product.Price;
        });
        newCart.CartItems = items;

        return newCart;
    }
}
