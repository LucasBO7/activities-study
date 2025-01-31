namespace ChatbotTry.Models
{
    public class Method
    {
        public delegate Task<string> CustomGenericFunctionAsync(string prompt);
        public delegate string CustomGenericFunction(string prompt);

        //public delegate GenericType CustomGenericTypeFunction(string prompt);
    }
}
