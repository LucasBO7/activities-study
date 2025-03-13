namespace StatePatternExercise_3.Entities.States;

internal class YellowState : ITrafficState
{
    public void Change()
    {
        Console.WriteLine("🔴 O sinal mudou para VERMELHO! PARE!");
    }
}