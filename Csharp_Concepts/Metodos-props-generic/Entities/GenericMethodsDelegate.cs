using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metodos_props_generic.Entities
{
    public class GenericMethodsDelegate<GenericReturn>
    {
        public delegate GenericReturn GetSomething(string something);
    }
}