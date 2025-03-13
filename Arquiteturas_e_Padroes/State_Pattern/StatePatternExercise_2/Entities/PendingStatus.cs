namespace StatePatternExercise_2.Entities;

public class PendingStatus : OrderState
{
    public PendingStatus(Order? order) : base(order) { }

    public override void Approve()
    {
        Console.WriteLine("Pedido aprovado!");
        _order!.SetStatus(new ApprovedStatus(_order));
    }

    public override void Cancel()
    {
        Console.WriteLine("Pedido cancelado!");
        _order!.SetStatus(new CanceledStatus(_order));
    }
}