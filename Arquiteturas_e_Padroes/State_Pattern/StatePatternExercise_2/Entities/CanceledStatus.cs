namespace StatePatternExercise_2.Entities;

public class CanceledStatus : OrderState
{
    public CanceledStatus(Order? order) : base(order) { }
}