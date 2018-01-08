using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// WARNING: TODO, IdObjects are not thread safe
    /// </summary>
    public class CentralServerState
    {
        public Dictionary<string, IdObject> Table { get; private set; } = new Dictionary<string, IdObject>();
        private object Lock = new object();

        public string NewId(string data)
        {
            string id = Guid.NewGuid().ToString();
            lock (Lock)
            {
                Table.Add(id, new IdObject() { Id = id, Data1 = data });
            }
            return id;
        }

        public bool CompleteId(string id, string data)
        {
            lock (Lock)
            {
                if (Table.ContainsKey(id))
                {
                    var obj = Table[id];
                    obj.Data2 = data;
                    return true;
                }
            }
            return false;
        }

        public IdObject Get(string id)
        {
            lock (Lock)
            {
                return Table.ContainsKey(id) ? Table[id] : null;
            }
        }
    }
}
