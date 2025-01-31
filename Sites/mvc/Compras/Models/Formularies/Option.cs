using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compras.Models.Formularies
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey("AlternativeQuestion")]
        public int AlternativeQuestionId { get; set; }
        public AlternativeQuestion AlternativeQuestion { get; set; }
    }
}