namespace OrderProcessing.Entities;

// Hook Class
internal class DiscountProcessor : IOrderCalculation
{
    public decimal Calulate(decimal grossValue)
    {
        return grossValue * 0.9m; // Aplica um desconto de 10%
    }
}