namespace POO_Architectured.Entities.Payments;

public class Pix(string receiverKey) : IPayment
{
    private string ReceiverKey = receiverKey;

    public void Pay(decimal amount)
    {
        Console.WriteLine(@$"Processando pagamento no PIX: 
        Valor: {amount}
        Chave do Recebedor: {ReceiverKey}");
        Console.WriteLine("Pagamento concluído!");
    }
}