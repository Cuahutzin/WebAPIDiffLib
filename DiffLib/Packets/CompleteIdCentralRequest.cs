using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    public class CompleteIdCentralRequest
    {
        public string WorkerId { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
    }
}
