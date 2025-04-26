using Observer_Exercise1.Interfaces;

namespace Observer_Exercise1.Observers;

public class DigitalClock : IClockObserver
{
    public void Update(TimeOnly time)
        => Console.WriteLine("Relógio digital marcando: " + time.ToLongTimeString());
}