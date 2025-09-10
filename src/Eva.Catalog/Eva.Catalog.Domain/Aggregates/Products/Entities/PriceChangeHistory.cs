using Eva.Catalog.Domain.Aggregates.Products.ValueObjects;

namespace Eva.Catalog.Domain.Aggregates.Products.Entities;

public class PriceChangeHistory
{
    public ProductId ProductId { get; init; }
    public DateTime ChangedAtUtc { get; init; }
    public Money Price { get; init; }
    public string? Reason { get; init; }
}
