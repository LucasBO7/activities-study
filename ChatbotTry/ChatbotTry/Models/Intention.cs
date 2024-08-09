using static ChatbotTry.Models.Method;

namespace ChatbotTry.Models
{
    public class Intention
    {
        public IntentionNames? Name { get; set; }
        public bool? IsThis { get; set; } = false;
        public string? Response { get; set; }
        public IEnumerable<string>? PossibleResponses { get; set; }

        // Propriedade referente à função genérica
        public CustomGenericFunction? CustomGenericFunction { get; set; } = null;
        public CustomGenericFunctionAsync? CustomGenericFunctionAsync { get; set; } = null;


        public Intention(IntentionNames name, bool isThisIntention, List<string> possibleResponses)
        {
            Name = name;
            IsThis = isThisIntention;
            PossibleResponses = possibleResponses;
        }

        public Intention(IntentionNames name, bool isThisIntention, string response)
        {
            Name = name;
            IsThis = isThisIntention;
            Response = response;
        }

        public Intention(IntentionNames name, bool isThisIntention, string response, CustomGenericFunction customGenericFunction)
        {
            Name = name;
            IsThis = isThisIntention;
            Response = response;
            CustomGenericFunction = customGenericFunction;
        }
        public Intention(IntentionNames name, bool isThisIntention, string response, CustomGenericFunctionAsync customGenericFunctionAsync)
        {
            Name = name;
            IsThis = isThisIntention;
            Response = response;
            CustomGenericFunctionAsync = customGenericFunctionAsync;
        }


        /// <summary>
        /// Cria uma nova Intention, já verificando se a intenção é esta ou não
        /// </summary>
        /// <param name="intentionsList">Lista de todas intenções</param>
        /// <param name="intentionType">Tipo de intenção</param>
        /// <param name="wordsList">Lista de palavras para reconhecimento</param>
        /// <param name="userMessageFormated">Texto do usuário formatado</param>
        /// <param name="response">Resposta do bot</param>
        public static void CreateNewIntention(List<Intention> intentionsList, IntentionNames intentionType, IEnumerable<string> wordsList, string userMessageFormated, string response)
        {
            intentionsList.Add(new Intention
            (
                name: intentionType,
                isThisIntention: wordsList.Any(w => userMessageFormated.Contains(w)),
                response: response
            ));
        }

        public static void CreateNewIntention(List<Intention> intentionsList, IntentionNames intentionType, IEnumerable<string> wordsList, IEnumerable<string> sndWordsList, string userMessageFormated, string response)
        {
            intentionsList.Add(new Intention
            (
                name: intentionType,
                isThisIntention: wordsList.Any(w => userMessageFormated.Contains(w)) && sndWordsList.Any(w => userMessageFormated.Contains(w)),
                response: response
            ));
        }
        public static void CreateNewIntention(List<Intention> intentionsList, IntentionNames intentionType, IEnumerable<string> wordsList, string userMessageFormated, string response, CustomGenericFunctionAsync customGenericFunctionAsync)
        {
            intentionsList.Add(new Intention
            (
                name: intentionType,
                isThisIntention: wordsList.Any(w => userMessageFormated.Contains(w)),
                response: response,
                customGenericFunctionAsync: customGenericFunctionAsync
            ));
        }

        public static void CreateNewIntention(List<Intention> intentionsList, IntentionNames intentionType, IEnumerable<string> wordsList, string userMessageFormated, string response, CustomGenericFunction customGenericFunction)
        {
            intentionsList.Add(new Intention
            (
                name: intentionType,
                isThisIntention: wordsList.Any(w => userMessageFormated.Contains(w)),
                response: response,
                customGenericFunction: customGenericFunction
            ));
        }

        public static void CreateNewIntention(List<Intention> intentionsList, IntentionNames intentionType, IEnumerable<string> wordsList, IEnumerable<string> sndWordsList, string userMessageFormated, string response, CustomGenericFunctionAsync customGenericFunctionAsync)
        {
            intentionsList.Add(new Intention
            (
                name: intentionType,
                isThisIntention: wordsList.Any(w => userMessageFormated.Contains(w)) && sndWordsList.Any(w => userMessageFormated.Contains(w)),
                response: response,
                customGenericFunctionAsync: customGenericFunctionAsync
            ));
        }

        public static void CreateNewIntention(List<Intention> intentionsList, IntentionNames intentionType, IEnumerable<string> wordsList, IEnumerable<string> sndWordsList, string userMessageFormated, string response, CustomGenericFunction customGenericFunction)
        {
            intentionsList.Add(new Intention
            (
                name: intentionType,
                isThisIntention: wordsList.Any(w => userMessageFormated.Contains(w)) && sndWordsList.Any(w => userMessageFormated.Contains(w)),
                response: response,
                customGenericFunction: customGenericFunction
            ));
        }
    }
}
