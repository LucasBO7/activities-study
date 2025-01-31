using StaticFactoyMethods.Entities;

IVechicle carFactory = VehicleFactory.CreateCar();
IVechicle bikeFactory = VehicleFactory.CreateBike("Casa grande");
IVechicle truckFactory = VehicleFactory.CreateTruck();

Console.WriteLine(carFactory.Drive());
Console.WriteLine(bikeFactory.Drive());
Console.WriteLine(truckFactory.Drive());