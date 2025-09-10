namespace Eva.Catalog.Domain.Aggregates.Products.ValueObjects;

public readonly record struct Money(decimal Value)
{
    public static Money New(decimal value) => new(value);
    public static Money From(decimal value) => new(value);
    public override string ToString() => Value.ToString();
}
