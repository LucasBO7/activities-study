namespace StatePatternExercise_2.Entities;

public class ShippedStatus : OrderState
{
    public ShippedStatus(Order? order) : base(order) { }

    public override void Deliver()
    {
        Console.WriteLine("Pedido entregue!");
    }
}