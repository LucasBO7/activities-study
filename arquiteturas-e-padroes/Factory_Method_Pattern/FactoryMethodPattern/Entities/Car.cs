namespace FactoryMethodPattern.Entities;

public abstract class Car
{
    public abstract IMotor CreateMotor();

    public void LigarCarro()
    {
        var motor = CreateMotor();
        motor.Ligar();
    }

    public void DesligarCarro()
    {
        var motor = CreateMotor();
        motor.Desligar();
    }
}