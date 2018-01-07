using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public interface ICentralServer
    {
        string CreateId(string data);
        bool CompleteId(string id, string data);
        string GetDiff(string id);
    }
}
