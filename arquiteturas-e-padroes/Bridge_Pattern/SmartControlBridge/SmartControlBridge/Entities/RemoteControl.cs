namespace SmartControlBridge.Entities;

public abstract class RemoteControl
{
    protected IDevice _device;

    public RemoteControl(IDevice newDevice)
    {
        _device = newDevice;
    }

    public abstract void Ligar();

    public abstract void Desligar();
}