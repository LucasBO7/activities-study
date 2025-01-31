using UsoHerancaCorreto.Entities;

Vehicle car = new Car();
Vehicle motorCycle = new Motorcycle();

// Pode-se utiizar o mesmo objeto (Vehicle) para acessar os métodos e propriedades de diferentes classes (Car e Motorcycle)
void DriveVehicle(Vehicle vehicle)
{
    vehicle.Drive();
}

DriveVehicle(car);
DriveVehicle(motorCycle);

// Comportamento específico para carro
Car car2 = new Car();
car2.OpenDoor(doorIsClosed: true);