using E_Store.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using YamlDotNet.Serialization;

namespace E_Store.Domain.Entities;

public class Order : AuditableBaseEntity<Guid>
{
    public string OrderNumber { get; private set; }
    public Guid UserId { get; private set; }
    public AppUser User { get; private set; }
    public Guid ShoppingCartId { get; private set; }
    public ShoppingCart ShoppingCart { get; private set; }

    private Order(Guid id, string orderNumber, Guid userId, Guid shoppingCartId) : base(id)
    {
        OrderNumber = orderNumber;
        UserId = userId;
        ShoppingCartId = shoppingCartId;
    }

    public static Order Create(Guid userId, Guid shoppingCartId)
    {
        return new Order(Guid.NewGuid(), Guid.NewGuid().ToString(), userId, shoppingCartId);
    }
}
