using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public class AspNetCentralServer : ICentralServer
    {
        public CentralServerState State { get; private set; }

        public AspNetCentralServer(CentralServerState state)
        {
            State = state;
        }

        bool ICentralServer.CompleteId(string id, string data)
        {
            return State.CompleteId(id, data);
        }

        string ICentralServer.CreateId(string data)
        {
            return State.NewId(data);
        }

        string ICentralServer.GetDiff(string id)
        {
            var obj = State.Get(id);
            if (obj == null)
                throw new KeyNotFoundException("Id does not exist. " + id);

            if(obj.Data1.Length == obj.Data2.Length)
            {
                return "SAME_LENGTH";
            }else if(obj.Data1.Length > obj.Data2.Length)
            {
                return "Data1 is BIGGER";
            }
            else
            {
                return "Data2 is BIGGER";
            }
        }
    }
}
