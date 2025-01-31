namespace NullObjectPatternExercise.Entities;

internal class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        if (message == null) throw new ArgumentNullException("message");
        Console.WriteLine(message);
    }
}