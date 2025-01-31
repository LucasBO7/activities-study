namespace SmartControlBridge.Entities;

public class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice newDevice) : base(newDevice) { }

    public override void Ligar()
    {
        _device.Ligar();
    }

    public override void Desligar()
    {
        _device.Desligar();
    }

    public void AumentarVolume()
    {
        if (_device is Tv)
            (_device as Tv)!.AumentarVolume();
        else
            Console.WriteLine("Este dispositivo não tem opção de aumentar o volume.");
    }

    public void DiminuirVolume()
    {
        if (_device is Tv)
            (_device as Tv)!.DiminuirVolume();
        else
            Console.WriteLine("Este dispositivo não tem opção de reduzir o volume.");
    }
}