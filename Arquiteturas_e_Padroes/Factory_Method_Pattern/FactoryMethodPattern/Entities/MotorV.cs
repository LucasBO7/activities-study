namespace FactoryMethodPattern.Entities;

public class MotorV : IMotor
{
    public void Desligar()
    {
        Console.WriteLine("Desligando motor V....");
    }

    public void Ligar()
    {
        Console.WriteLine("Ligando motor V....");
    }
}