namespace StaticFactoryMethods_2.Entities;

public class Food : IProduct
{
    private readonly decimal _taxRate = 5;
    private string? Name { get; set; }
    private decimal BasePrice { get; set; }

    private Food(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public static Food CreateFood(string name, decimal basePrice)
    {
        return new Food(name, basePrice);
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