using AutoMapper;
using E_Store.Domain.Entities;

namespace E_Store.Features.ShoppingCarts.Update.Model;

public record Request(Guid Id, Guid CartItemId, string Condition, int Quantity);