namespace POO_Architectured.Entities.Payments;

public class BankSlip(string codeBar) : IPayment
{
    private string CodeBar = codeBar;

    public void Pay(decimal amount)
    {
        Console.WriteLine(@$"Processando pagamento com Boleto Bancário: 
        Valor: {amount}
        Código de barras: {CodeBar}");
        Console.WriteLine("Pagamento concluído!");
    }
}