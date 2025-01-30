namespace StaticFactoryMethods_2.Entities;

public class Clothing : IProduct
{
    private readonly decimal _taxRate = 10;
    private string? Name { get; set; }
    private decimal BasePrice { get; set; }

    private Clothing(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public static Clothing CreateClothing(string name, decimal basePrice)
    {
        return new Clothing(name, basePrice);
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