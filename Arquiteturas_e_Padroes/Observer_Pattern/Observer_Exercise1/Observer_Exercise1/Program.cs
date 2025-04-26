using Observer_Exercise1.Entities;
using Observer_Exercise1.Interfaces;
using Observer_Exercise1.Observers;

Clock clock = new();

IClockObserver analogicClock = new AnalogicClock();
IClockObserver digitalClock = new DigitalClock();

clock.RegisterObserver(analogicClock);
clock.RegisterObserver(digitalClock);

clock.SetTime(TimeOnly.FromDateTime(DateTime.Now));
Console.WriteLine();
clock.SetTime(TimeOnly.FromDateTime(DateTime.Now.AddSeconds(56)));
Console.WriteLine();

clock.RemoveObserver(analogicClock);
clock.SetTime(TimeOnly.FromDateTime(DateTime.Now.AddSeconds(32)));