Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(@$"
=========================
                         
       JOGO DA VELHA     
                         
=========================

--> INSTRUÇÕES
Para jogar, utilize números referentes a cada casa:

  1  |  2  |  3  |
__________________
  4  |  5  |  6  |
__________________
  7  |  8  |  9  |


");
Console.ResetColor();

Console.Write($"Deseja que você comece a partida?(sim/não): ");
string usuarioComecaPartida = Console.ReadLine().ToLower();

Console.Write($"Deseja utilizar 'x' ou 'o'? ");
char simboloUsuario = char.Parse(Console.ReadLine().ToLower());

// Pega o simbolo do bot como o contrário do usuário
char simboloBot = simboloUsuario == 'x' ? 'o' : 'x';

// Se o usuário for começar a partida

char[] valores = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

// Insere valores padrões da tabela (1,2,3...9)
Dictionary<string, int> jogadas = new Dictionary<string, int>();


// Pega todos os valores padrão da lista de jogadas

foreach (var item in valores)
{
    Console.WriteLine(item.ToString());
}

char continuarJogo = 's';
do
{
    if (usuarioComecaPartida == "sim")
    {
        Console.WriteLine(@$"
  {valores[0]}  |  {valores[1]}  |  {valores[2]}  |
__________________

  {valores[3]}  |  {valores[4]}  |  {valores[5]}  |
__________________

  {valores[6]}  |  {valores[7]}  |  {valores[8]}  |


    ");

        Console.Write($"Insira a casa em que deseja jogar: ");
        int casaJogada = int.Parse(Console.ReadLine());

        valores[casaJogada - 1] = 'x';

        Console.WriteLine(@$"
  {valores[0]}  |  {valores[1]}  |  {valores[2]}  |
__________________

  {valores[3]}  |  {valores[4]}  |  {valores[5]}  |
__________________

  {valores[6]}  |  {valores[7]}  |  {valores[8]}  |


    ");



        int[] posicoesLivres = new int[9]; // Posições que o usuário ainda não jogou]
        for (int i = 0; i <= valores.Length; i++)
        {
          posicoesLivres[i] = valores[i];
          Console.WriteLine($"Posição: {posicoesLivres[i]}");
        }
        // foreach (var item in valores)
        // {
        //     Console.WriteLine($"{item}");
        //     // adicionar o valor somente se o usuário já não colocou naquela posição
        //     Console.WriteLine("item: " + item);

        //     posicoesLivres.Add(item);

        //     if (item != simboloUsuario)
        //     {
        //     }
        // }
        // Console.ReadLine();

        foreach (var item in posicoesLivres)
        {
            Console.WriteLine($"{item}");
        }

        // Random randomNumberSelector = new Random(DateTime.Now.Millisecond);
        // int indice = randomNumberSelector.Next(1);
        // int numeroAleatorio = posicoesLivres[indice];
        // Console.WriteLine($"Número aleatório escolhido: {numeroAleatorio}");


        // var jogadaEscolhida = posicoesLivres[randomNumberSelector.Next(posicoesLivres.Count)];
        // Console.WriteLine($"Casa escolhida pelo bot: {jogadaEscolhida}");

        // // Insere a casa escolhida pelo bot na lista de valores
        // valores[jogadaEscolhida - 1] = simboloBot;
        // continuarJogo = char.Parse(Console.ReadLine().ToLower());
    }
} while (continuarJogo == 's');