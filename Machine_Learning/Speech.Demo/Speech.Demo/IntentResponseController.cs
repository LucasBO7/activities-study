using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.Demo
{
    internal static class IntentResponseController
    {
        /// <summary>
        /// Com base na grupo da intenção detectada, buscará no banco de dados uma resposta para aquela pergunta (a resposta será escolhida ou por lógica ou por aleatoriedade)
        /// </summary>
        /// <param name="intentIdentified"></param>
        /// <returns>Lista de objetos IntentResponse (Resposta do Jarvis)</returns>
        public static IntentResponse GetAResponse(string intentIdentified)
        {
            try
            {
                // Instância do Data Context
                using var context = new AppDbContext();

                // Pega randomicamente uma intenção(Intent)
                Random randomNumber = new Random();

                List<IntentResponse>? intentsIdentifiedFromDb = context.IntentResponses.Where(i => i.Intent == intentIdentified).ToList();

                // Gera um número aleatório e armazena
                int generatedRandomNumber = randomNumber.Next(intentsIdentifiedFromDb.Count());

                IntentResponse intentCatched = intentsIdentifiedFromDb[generatedRandomNumber];
                return intentCatched;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Erro!!: " + exc.Message);
            }
            return null;
        }


    }
}
