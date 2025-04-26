using Observer_Exercise1.Interfaces;

namespace Observer_Exercise2.Interfaces;

internal interface IObserverManager
{
    void RegisterObserver(IClockObserver observer);
    void RemoveObserver(IClockObserver observer);
    void NotifyObservers(TimeOnly newTime, string? format);
}