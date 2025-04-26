using Observer_Exercise1.Interfaces;

namespace Observer_Exercise1.Entities;

internal class Clock
{
    private List<IClockObserver> Observers = [];
    public TimeOnly CurrentTime { get; private set; } = TimeOnly.FromDateTime(DateTime.Now);
    private ClockFormat CurrentClockFormat = ClockFormat.TwentyFourHoursFormat;

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

    public void SetClockSystem(ClockFormat newClockFormat)
    {
        CurrentClockFormat = newClockFormat;
    }

    public void SetTime(TimeOnly time)
    {
        CurrentTime = time;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        Observers.ForEach(observer => observer.Update(CurrentTime));
    }
}

public enum ClockFormat
{
    TwelveHoursFormat,
    TwentyFourHoursFormat
}