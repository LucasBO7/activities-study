using Observer_Exercise1.Entities;
using Observer_Exercise1.Interfaces;
using Observer_Exercise1.Observers;

Clock clock = new();

IClockObserver analogicClock = new AnalogicClock();
IClockObserver digitalClock = new DigitalClock();

clock.RegisterObserver(analogicClock);
clock.RegisterObserver(digitalClock);

Console.WriteLine("|Horário no formato de 24 horas|");
clock.SetTime(TimeOnly.FromDateTime(DateTime.Now));

Console.WriteLine();

Console.WriteLine("|Horário no formato de 12 horas|");
clock.SetClockFormat(ClockFormat.TwelveHoursFormat);

clock.SetTime(TimeOnly.FromDateTime(DateTime.Now));