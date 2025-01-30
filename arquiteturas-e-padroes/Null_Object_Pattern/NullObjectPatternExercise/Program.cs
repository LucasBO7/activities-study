using NullObjectPatternExercise.Entities;

// Implementação sem Null Object
ILogger logger = new ConsoleLogger();

// Se logger recebesse null mais pra frente, daria erro
if (logger != null)
    logger.Log("Tá funcionando");


// Implementação com Null Object
ILogger logger2 = new NullLogger();
logger2.Log("Tá funcionando");