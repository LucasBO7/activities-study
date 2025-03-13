namespace OrderProcessing.Entities;

public class OrderProcessor
{
    private IOrderCalculation _orderCalculation;

    public OrderProcessor() { }

    public void ChangePriceCalculationTo(IOrderCalculation orderCalculation)
    {
        _orderCalculation = orderCalculation;
    }

    public decimal CalculateTotal(decimal orderPrice)
    {
        if (_orderCalculation == null)
            return orderPrice;

        decimal priceValueProcessed = _orderCalculation.Calulate(orderPrice);
        return priceValueProcessed;
    }
}