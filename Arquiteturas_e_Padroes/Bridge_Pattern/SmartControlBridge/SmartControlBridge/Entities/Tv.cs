namespace SmartControlBridge.Entities;

internal class Tv : IDevice
{
    public void Ligar()
    {
        Console.WriteLine("Ligando a tv...");
    }
    public void Desligar()
    {
        Console.WriteLine("Desligando a tv...");
    }

    public void AumentarVolume()
    {
        Console.WriteLine("Aumentando volume da tv...");
    }

    public void DiminuirVolume()
    {
        Console.WriteLine("Aumentando volume da tv...");
    }
}