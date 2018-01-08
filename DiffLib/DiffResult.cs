using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public class DiffResult
    {
        public DiffResultEnum Result { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }

        public List<DiffOffset> Offsets { get; set; } = new List<DiffOffset>();
    }
}
