using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public class CentralServerState
    {
        public Dictionary<string, IdObject> Table { get; private set; }

        public string NewId(string data)
        {
            string id = Guid.NewGuid().ToString();
            Table.Add(id, new IdObject() { Id = id, Data1 = data });
            return id;
        }

        public bool CompleteId(string id, string data)
        {
            if (Table.ContainsKey(id))
            {
                var obj = Table[id];
                obj.Data2 = data;
                return true;
            }
            return false;
        }

        public IdObject Get(string id)
        {
            return Table.ContainsKey(id) ? Table[id] : null;
        }
    }
}
