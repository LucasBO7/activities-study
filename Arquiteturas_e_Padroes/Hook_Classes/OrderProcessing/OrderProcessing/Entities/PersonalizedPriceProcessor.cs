namespace OrderProcessing.Entities;

// Hook Class
internal class PersonalizedPriceProcessor : IOrderCalculation
{
    public decimal Calulate(decimal grossValue)
    {
        return grossValue * 1.2m; // Aplica um aumento no preço, exemplo de personalização
    }}