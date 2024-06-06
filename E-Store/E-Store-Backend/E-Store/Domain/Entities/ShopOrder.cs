using E_Store.Domain.Entities.Common;

namespace E_Store.Domain.Entities;

public class ShopOrder : AuditableBaseEntity<Guid>
{
    public string OrderNumber { get; private set; }
    public decimal Total { get; private set; }
    public Guid UserId { get; private set; }
    public AppUser User { get; private set; }
    public List<CartItem> CartItems { get; private set; }

    private ShopOrder(Guid id, string orderNumber, decimal total, Guid userId) : base(id)
    {
        OrderNumber = orderNumber;
        Total = total;
        UserId = userId;
        CartItems = new List<CartItem>();
    }

    public static ShopOrder Create( decimal total, Guid userId, List<CartItem> items)
    {
        ShopOrder order = new ShopOrder(Guid.NewGuid(), Guid.NewGuid().ToString(), total, userId);
        order.CartItems = items;
        return order;
    }
}
