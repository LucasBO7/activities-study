using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metodos_props_generic.Entities
{
    public class Message<MessageType>
    {
        public string? Author { get; set; }

        public MessageType? Body { get; set; }

        
    }
}