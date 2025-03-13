namespace StatePatternExercise_3.Entities.States;

internal class RedState : ITrafficState
{
    public void Change()
    {
        Console.WriteLine("🔵 O sinal mudou para VERDE! Os carros podem andar.");
    }
}