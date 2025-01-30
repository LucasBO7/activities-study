namespace FactoryMethodPattern.Entities;

public class Mustang : Car
{
    public override IMotor CreateMotor()
    {
        return new MotorV();
    }
}