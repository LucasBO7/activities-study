namespace StaticFactoyMethods.Entities;

public class VehicleFactory
{
    public static IVechicle CreateBike(string model)
    {
        return Bike.CreateBike(model);
    }

    public static IVechicle CreateTruck()
    {
        return new Truck();
    }

    public static IVechicle CreateCar()
    {
        return new Car();
    }
}