namespace GeometryDrawer.Entities;

internal class Outline : IDesign
{
    public void Draw(string shape)
    {
        Console.WriteLine($"Desenhando um {shape} com contorno.");
    }
}