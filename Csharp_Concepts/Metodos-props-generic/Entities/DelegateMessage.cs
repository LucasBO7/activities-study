using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metodos_props_generic.Entities;
using static Metodos_props_generic.Entities.DelegateMethods;

namespace Metodos_props_generic.Entities
{
    public class DelegateMessage
    {
        public string? Author { get; set; }

        public string? Body { get; set; }

        public GetUserResponse? GetUserResponse;
    }
}