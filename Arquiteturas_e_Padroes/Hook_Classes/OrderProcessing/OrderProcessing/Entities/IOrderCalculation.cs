namespace OrderProcessing.Entities;

public interface IOrderCalculation
{
    decimal Calulate(decimal grossValue);
}