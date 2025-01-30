using FactoryMethodPattern.Entities;

Fusca fusca = new();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Fusca - motor Boxer");
Console.ResetColor();
fusca.CreateMotor();
fusca.LigarCarro();
fusca.DesligarCarro();

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Mustang - motor V");
Console.ResetColor();
Mustang mustang = new();
mustang.CreateMotor();
mustang.LigarCarro();
mustang.DesligarCarro();