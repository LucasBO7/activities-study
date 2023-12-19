using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Formularies
{
    public class EssayQuestion : Question
    {
        [Key]
        public int Id { get; set; }
        public string CorrectAnswer { get; set; }
    }
}