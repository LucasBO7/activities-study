// E-Commerce -> pedidos
// Processar pedidos
// Pagamentos: Cartão, Boleto, Pix, +...
// Permitir inserção de futuros novos métodos de pagamento

// REQUISITOS
// 1. classe princiapl para representar o Pedido OK
// 2. pagamentos devem ser processados de forma polimórfica OK
// 3. abstração para definir um contrato(interface) comum -> para os métodos de pagamento OK
// 4. detalhes de implementação dos pagamentos -> encapsulados OK
// 5. permitir inserção de novos métodos de pagamento sem alterar o código OK

// CONCEITOS
// Encapsulamento
// Abstração
// Polimorfismo
// Herança

// Menu
using POO_Architectured.Entities;
using POO_Architectured.Entities.Payments;

string result;
do
{
    Console.WriteLine(@"
---------------------------------------------------------
                    Processar Pedido
---------------------------------------------------------
");

    Order newOrder = new("Bananas", 12);
    IPayment? payment = null;


    Console.Write(@"Forma de pagamento (c/d/b/p): ");
    string? paymentType = Console.ReadLine();

    switch (paymentType)
    {
        case "c":
            payment = new Credt(3213, "Carlos");
            newOrder.SetPaymentMethod(payment);
            break;
        case "d":
            payment = new Debt(9321329, 432);
            newOrder.SetPaymentMethod(payment);
            break;
        case "b":
            payment = new BankSlip("932sddsaj321g734f");
            newOrder.SetPaymentMethod(payment);
            break;
        case "p":
            payment = new Pix("tomas@gmail.com.br");
            newOrder.SetPaymentMethod(payment);
            break;
        default:
            Console.WriteLine("ERRO!!!!");
            break;
    };

    newOrder.ConcludePayment();
    result = Console.ReadLine()!;
    Console.Clear();
} while (result != "exit");

Console.WriteLine("FIM");