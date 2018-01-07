using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    public class CreateIdRequest
    {
        public string WorkerId { get; set; }
        public string Data { get; set; }
    }
}
