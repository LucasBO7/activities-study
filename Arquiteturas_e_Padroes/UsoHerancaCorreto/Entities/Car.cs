namespace UsoHerancaCorreto.Entities;

public class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Dirigindo o carro...");
    }

    public void OpenDoor(bool doorIsClosed)
    {
        if (doorIsClosed)
            Console.WriteLine("Abrindo a porta do carro...");
    }
}