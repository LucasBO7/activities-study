using HookMethods_Default.Entities;


#region Conta corrente (com taxa)
Console.WriteLine("___________CONTA CORRENTE________");
// Depósito
ContaCorrente contaCorrente = new(2000);
contaCorrente.ProcessOperation(OperationType.Deposit, 120);
float balance = contaCorrente.GetBalance();

Console.WriteLine("Saldo: " + balance);

// Saque
contaCorrente.ProcessOperation(OperationType.Withdraw, 100);
balance = contaCorrente.GetBalance();

Console.WriteLine("Saldo: " + balance);
#endregion

#region Conta normal (sem taxa)
Console.WriteLine("___________CONTA NORMAL__________");
// Depósito
AccountBank accountBank = AccountBank.NewInstance(1000);
accountBank.ProcessOperation(OperationType.Deposit, 120);
float normalBalance = accountBank.GetBalance();

Console.WriteLine("Saldo: " + normalBalance);

// Saque
accountBank.ProcessOperation(OperationType.Withdraw, 100);
normalBalance = accountBank.GetBalance();

Console.WriteLine("Saldo: " + normalBalance);
#endregion