namespace StaticFactoyMethods.Entities;
public class Bike : IVechicle
{
    public string? Model { get; private set; }

    private Bike(string model)
    {
        Model = model;
    }

    public static Bike CreateBike(string model)
    {
        return new Bike(model);
    }

    public string Drive()
    {
        return $"Pedalando uma bicicleta. {Model}";
    }
}