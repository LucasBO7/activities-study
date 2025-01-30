using System.Xml.Serialization;

namespace HookMethods_Default.Entities;

public class AccountBank
{
    protected float Balance { get; private set; }

    public AccountBank()
    {
    }

    private AccountBank(float balance)
    {
        Balance = balance;
    }

    public static AccountBank NewInstance(float balance)
    {
        return new AccountBank(balance);
    }

    public float GetBalance()
    {
        return Balance;
    }

    public void ProcessOperation(OperationType operationType, float moneyValue)
    {
        // Deposito/Saque
        switch (operationType)
        {
            case OperationType.Deposit:
                Deposit(moneyValue);
                break;
            case OperationType.Withdraw:
                Withdraw(moneyValue);
                break;
            default:
                break;
        }
    }

    protected void Deposit(float money)
    {
        Balance += money;
        Console.WriteLine("Depositando o dinheiro no valor de: " + money);
    }

    protected virtual void Withdraw(float money)
    {
        Balance -= money;
        Console.WriteLine("Efetuando o saque no valor de: " + money);
    }
}

public enum OperationType
{
    Deposit,
    Withdraw
}