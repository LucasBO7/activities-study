using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.Demo
{
    internal class IntentResponse
    {
        public int Id { get; set; }
        public string Intent { get; set; }
        public string Phrase { get; set; }
    }
}