using Observer_Exercise1.Interfaces;
using Observer_Exercise2.Interfaces;

namespace Observer_Exercise2.Entities;

internal class ObserverManager : IObserverManager
{
    private List<IClockObserver> Observers = [];

    public void RegisterObserver(IClockObserver observer)
    {
        if (Observers.Contains(observer)) return;

        Observers.Add(observer);
    }

    public void RemoveObserver(IClockObserver observer)
    {
        if (!Observers.Contains(observer)) return;

        Observers.Remove(observer);
    }

    public void NotifyObservers(TimeOnly newTime, string? format)
    {
        Observers.ForEach(observer => observer.Update(newTime, format));
    }
}