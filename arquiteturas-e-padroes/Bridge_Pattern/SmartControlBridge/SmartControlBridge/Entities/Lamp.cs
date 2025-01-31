namespace SmartControlBridge.Entities;

internal class Lamp : IDevice
{
    public void Ligar()
    {
        Console.WriteLine("Ligando lâmpada...");
    }

    public void Desligar()
    {
        Console.WriteLine("Desligando lâmpada...");
    }
}