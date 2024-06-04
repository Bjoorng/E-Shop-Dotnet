using Microsoft.IdentityModel.Tokens;

namespace E_Store.Domain.Entities;

public class CartItem
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    private CartItem(Guid id, int quantity, Guid productId)
    {
        Id = id;
        Quantity = quantity;
        ProductId = productId;
    }

    public static CartItem Create(int quantity, Guid productId)
    {
        return new CartItem(Guid.NewGuid(), quantity, productId);
    }

    public void Update(string quantity)
    {
        if(!quantity.IsNullOrEmpty() && int.TryParse(quantity, out int parsedQuantity))
        {
            Quantity = parsedQuantity;
        }
    }
}
