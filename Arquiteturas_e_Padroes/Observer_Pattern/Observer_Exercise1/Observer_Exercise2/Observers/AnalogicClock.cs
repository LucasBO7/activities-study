using Observer_Exercise1.Interfaces;

namespace Observer_Exercise1.Observers;

public class AnalogicClock : IClockObserver
{
    public void Update(TimeOnly time, string? format = "HH:mm:ss")
        => Console.WriteLine("Relógio analógico marcando: " + time.ToString(format));
}