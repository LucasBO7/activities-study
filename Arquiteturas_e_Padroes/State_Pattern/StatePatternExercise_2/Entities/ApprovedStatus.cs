namespace StatePatternExercise_2.Entities;

public class ApprovedStatus : OrderState
{
    public ApprovedStatus(Order? order) : base(order) { }

    public override void Ship()
    {
        Console.WriteLine("Pedido enviado!");
        _order!.SetStatus(new ShippedStatus(_order));
    }
}