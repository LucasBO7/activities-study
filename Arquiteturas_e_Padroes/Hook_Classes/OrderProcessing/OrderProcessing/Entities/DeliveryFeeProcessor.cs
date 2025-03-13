namespace OrderProcessing.Entities;

// Hook Class
internal class DeliveryFeeProcessor : IOrderCalculation
{
    private const decimal _deliveryFee = 1.1m;

    public decimal Calulate(decimal grossValue)
    {
        return grossValue * _deliveryFee; // Adiciona uma taxa de entrega de 10%
    }
}