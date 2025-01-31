namespace StaticFactoyMethods.Entities;

public class Car : IVechicle
{
    public string? Name { get; private set; }
    public string? Carmaker { get; private set; }

    public string Drive()
    {
        return "Dirigindo um carro.";
    }
}