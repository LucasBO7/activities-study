namespace StatePatternExercise_2.Entities;

public abstract class OrderState
{
    protected Order? _order;

    public OrderState(Order? order)
        => _order = order;

    public virtual void Approve() => Console.WriteLine("Ação inválida neste estado.");
    public virtual void Ship() => Console.WriteLine("Ação inválida neste estado.");
    public virtual void Deliver() => Console.WriteLine("Ação inválida neste estado.");
    public virtual void Cancel() => Console.WriteLine("Ação inválida neste estado.");
}