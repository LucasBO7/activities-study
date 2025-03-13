namespace StaticFactoryMethods_2.Entities;

public class Electronics : IProduct
{
    private const decimal _taxRate = 15;
    private string? Name { get; set; }
    private decimal BasePrice { get; set; }

    private Electronics(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public static Electronics CreateEletronic(string name, decimal basePrice)
    {
        return new Electronics(name, basePrice);
    }

    public decimal GetPriceWithTax()
    {
        return BasePrice - (BasePrice * (_taxRate / 100));
    }

    public string GetProduceDetails()
    {
        return $"{Name} {BasePrice:F2}";
    }
}