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

// Se o usuário for começar a partida

char[] valores = new char[9];

// Insere valores padrões da tabela (1,2,3...9)
Dictionary<string, int> jogadas = new Dictionary<string, int>();
for (int x = 1; x <= 9; x++)
{
    // jogadas.Add($"padrao{x}", x);
    valores[x - 1] = (char)x; // Tá dando erro
}


// Pega todos os valores padrão da lista de jogadas

foreach (var item in valores)
{
    Console.WriteLine(item);
}


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

    valores[casaJogada] = 'x';

}
