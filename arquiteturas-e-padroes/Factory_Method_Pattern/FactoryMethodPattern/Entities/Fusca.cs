namespace FactoryMethodPattern.Entities;

public class Fusca : Car
{
    public override IMotor CreateMotor()
    {
        return new MotorBoxer();
    }
}