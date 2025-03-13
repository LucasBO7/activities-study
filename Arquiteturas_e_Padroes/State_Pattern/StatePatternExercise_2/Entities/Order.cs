using StatePatternExercise_2.Entities;

public class Order
{
    public OrderState _state;

    public Order()
    {
        _state = new PendingStatus(this);
    }

    public void SetStatus(OrderState newOrderState)
    {
        _state = newOrderState;
    }

    public void Approve() => _state.Approve();
    public void Ship() => _state.Ship();
    public void Deliver() => _state.Deliver();
    public void Cancel() => _state.Cancel();
}