namespace POO_Architectured.Entities;

public class Credt(int number, string? clientName) : IPayment
{
    private int Number = number;
    private string? ClientName = clientName;

    public void Pay(decimal amount)
    {
        Console.WriteLine(@$"Processando pagamento no Crédito: 
        Valor: {amount}
        Número: {Number}
        Nome: {ClientName}");
        Console.WriteLine("Pagamento concluído!");
    }
}