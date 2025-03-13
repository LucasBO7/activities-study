namespace GeometryDrawer.Entities;

internal class Fill : IDesign
{
    public void Draw(string shape)
    {
        Console.WriteLine($"Desenhando um {shape} preenchido.");
    }
}