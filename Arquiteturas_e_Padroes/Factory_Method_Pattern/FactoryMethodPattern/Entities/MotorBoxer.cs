namespace FactoryMethodPattern.Entities;

public class MotorBoxer : IMotor
{
    public void Desligar()
    {
        Console.WriteLine("Desligando motor boxer...");
    }

    public void Ligar()
    {
        Console.WriteLine("Ligando motor boxer...");
    }
}