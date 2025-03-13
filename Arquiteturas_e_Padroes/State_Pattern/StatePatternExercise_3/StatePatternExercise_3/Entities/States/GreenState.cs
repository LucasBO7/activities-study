namespace StatePatternExercise_3.Entities.States;

internal class GreenState : ITrafficState
{
    public void Change()
    {
        Console.WriteLine("🟡 O sinal mudou para AMARELO! Atenção!");
    }
}