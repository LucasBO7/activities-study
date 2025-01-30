namespace POO_Architectured.Entities;

public class Debt(int number, int cardCode) : IPayment
{
    private int Number = number;
    private int CardCode = cardCode;

    public void Pay(decimal amount)
    {
        Console.WriteLine(@$"Processando pagamento no Débito: 
        Valor: {amount}
        Número: {Number}
        Número cartão: {CardCode}");
        Console.WriteLine("Pagamento concluído!");
    }
}