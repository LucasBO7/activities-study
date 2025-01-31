namespace StaticFactoryMethods_2.Entities;
public class Product : IProduct
{
    private decimal _taxRate;
    private string? Name { get; set; }
    private decimal BasePrice { get; set; }
    private Category Category { get; set; }

    private Product(string name, decimal basePrice, Category category)
    {
        Name = name;
        BasePrice = basePrice;
        Category = category;
        _taxRate = Category switch
        {
            Category.Electronics => 15,
            Category.Clothing => 10,
            Category.Food => 5,
            _ => throw new ArgumentException("Categoria inválida!")
        };
    }

    public static Product CreateEletronics(string name, decimal basePrice)
    {
        return new Product(name, basePrice, Category.Electronics);
    }
    public static Product CreateClothing(string name, decimal basePrice)
    {
        return new Product(name, basePrice, Category.Clothing);
    }
    public static Product CreateFood(string name, decimal basePrice)
    {
        return new Product(name, basePrice, Category.Food);
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

public enum Category
{
    Electronics,
    Clothing,
    Food
}