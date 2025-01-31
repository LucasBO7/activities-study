namespace HookMethods_Default.Entities;

public class ContaCorrente : AccountBank
{
    private readonly float operationTax = 0.1f; // taxa de 10%

    public ContaCorrente(float balance)
    {
        this.Balance = balance;
    }

    protected override void Withdraw(float money)
    {
        base.Withdraw(money);
        // Insere a taxa de operação se for mais de 20 reais
        money = ApplyOperationTax(money);
        Console.WriteLine("Foi aplicado uma taxa de 10% de saque.");
        Console.WriteLine("Valor total do saque: " + money);
    }

    private float ApplyOperationTax(float money)
    {
        return money >= 20
            ? money - (operationTax * money)
            : money;
    }
}