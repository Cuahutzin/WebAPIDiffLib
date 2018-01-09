using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public interface ICentralServerState
    {
        string NewId(string data);
        bool CompleteId(string id, string data);
        IdObject Get(string id);
    }
}
