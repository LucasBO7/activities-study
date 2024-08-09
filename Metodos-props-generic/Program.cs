// See https://aka.ms/new-console-template for more information
using Metodos_props_generic.Entities;

Console.WriteLine("Hello, World!");

Message<string> message = new()
{
    Author = "João",
    Body = "Gostei deste sistema! Dahora!"
};

Console.WriteLine($"{message.Author}: {message.Body}");
Console.WriteLine("___________________________________________");
Console.WriteLine("     COM MÉTODO GENÉRICO     ");

string StatusDelegateProcess(string actualDate)
{
    return $"Processado com sucesso! {actualDate}";
}

DelegateMessage delegateMessage = new()
{
    Author = "Tomas",
    Body = "Receba meu poder!",
    GetUserResponse = StatusDelegateProcess
};

Console.WriteLine(@$"{delegateMessage.Author}: {delegateMessage.Body}
{delegateMessage.GetUserResponse(DateTime.Now.ToShortDateString())}");

Console.WriteLine("___________________________________________");
Console.WriteLine("     COM MÉTODO GENÉRICO DE RETORNO GENÉRICO     ");

string GetTheTime()
{
    return DateTime.Now.ToShortTimeString();
}

GenericDelegateMessage<string> genericDelegateMessage = new()
{
    Author = "Melissa",
    Body = "Será que funciona mesmo?",
    GetSomething = GetTheTime
};