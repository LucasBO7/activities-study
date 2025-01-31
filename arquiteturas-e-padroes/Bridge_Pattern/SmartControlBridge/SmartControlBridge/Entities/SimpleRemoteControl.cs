namespace SmartControlBridge.Entities;

public class SimpleRemoteControl : RemoteControl
{
    public SimpleRemoteControl(IDevice newDevice) : base(newDevice) { }

    public override void Ligar()
    {
        _device.Ligar();
    }

    public override void Desligar()
    {
        _device.Desligar();
    }
}