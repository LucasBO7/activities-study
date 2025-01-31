using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Compras.Models.Formularies
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Statement { get; set; }
        public string? ImgPath { get; set; }

    }
}