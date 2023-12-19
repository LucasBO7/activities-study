using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compras.Models.Formularies
{
    public class AlternativeQuestion : Question
    {
        [Key]
        public int Id { get; set; }
        public List<Option> Options { get; set; }
        public int CorrectAlternativeIndex { get; set; }
    }
}