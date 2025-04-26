using Observer_Exercise1.Interfaces;
using Observer_Exercise2.Entities;
using System.Security.AccessControl;

namespace Observer_Exercise1.Entities;

internal class Clock
{
    private readonly ObserverManager _observerManager;

    public TimeOnly CurrentTime { get; private set; }

    private string selectedClockFormat;
    public ClockFormat CurrentClockFormat
    {
        get
        {
            return CurrentClockFormat;
        }
        set
        {
            if (value is ClockFormat.TwelveHoursFormat)
                selectedClockFormat = "hh:mm tt";
            else
                selectedClockFormat = "HH:mm:ss";
        }
    }

    public Clock()
    {
        _observerManager = new();
        CurrentTime = TimeOnly.FromDateTime(DateTime.Now);
        CurrentClockFormat = ClockFormat.TwentyFourHoursFormat;
    }

    public void RegisterObserver(IClockObserver observer)
        => _observerManager.RegisterObserver(observer);

    public void RemoveObserver(IClockObserver observer)
        => _observerManager.RemoveObserver(observer);

    public void SetClockFormat(ClockFormat newClockFormat)
    {
        CurrentClockFormat = newClockFormat;
    }

    public void SetTime(TimeOnly time)
    {
        CurrentTime = time;
        _observerManager.NotifyObservers(time, selectedClockFormat);
    }
}

public enum ClockFormat
{
    TwelveHoursFormat,
    TwentyFourHoursFormat
}