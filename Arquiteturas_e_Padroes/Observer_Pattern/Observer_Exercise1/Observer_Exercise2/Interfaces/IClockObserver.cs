namespace Observer_Exercise1.Interfaces;

internal interface IClockObserver
{
    void Update(TimeOnly time, string? format = "HH:MM:ss");
}