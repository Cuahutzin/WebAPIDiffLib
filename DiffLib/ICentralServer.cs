using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public interface ICentralServer
    {
        string CreateId(string workerId, string data);
        bool CompleteId(string workerId, string id, string data);
        DiffResult GetDiff(string workerId, string id);
    }
}
