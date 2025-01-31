using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using static Metodos_props_generic.Entities.GenericMethodsDelegate<string>;


namespace Metodos_props_generic.Entities
{
    public class GenericDelegateMessage<ReturnType>
    {
        public string? Author { get; set; }

        public string? Body { get; set; }

        public GenericMethodsDelegate<ReturnType>.GetSomething? GetSomething;
    }
}