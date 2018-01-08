using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Packets
{
    public class GetDiffResponse
    {
        public string Id { get; set; } = string.Empty;
        public DiffLib.DiffResult Result { get; set; }
        
    }
}
