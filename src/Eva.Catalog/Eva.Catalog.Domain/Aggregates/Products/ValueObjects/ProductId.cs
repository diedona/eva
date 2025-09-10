using Eva.Catalog.Domain.SharedKernel.Abstractions;

namespace Eva.Catalog.Domain.Aggregates.Products.ValueObjects;

public readonly record struct ProductId(Guid Value) : IValueObject
{
    public static ProductId New() => new(Guid.NewGuid());
    public static ProductId From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
