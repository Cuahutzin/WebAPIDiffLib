using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// WARNING: TODO: IdObjects are not thread safe.
    /// Holds the created ids and their data
    /// </summary>
    public class CentralServerState : ICentralServerState
    {
        /// <summary>
        /// key (string) = id
        /// IdObject = Holds the data
        /// </summary>
        public Dictionary<string, IdObject> Table { get; private set; } = new Dictionary<string, IdObject>();
        private object Lock = new object();

        /// <summary>
        /// Creates a new id (Guid) and inserts into the dictionary
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string NewId(string data)
        {
            string id = Guid.NewGuid().ToString();
            lock (Lock)
            {
                Table.Add(id, new IdObject() { Id = id, Data1 = data });
            }
            return id;
        }

        /// <summary>
        /// Completes the IdObject with the missing data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Returns false if id does not exist</returns>
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

        /// <summary>
        /// Returns IdObject based on the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns null of it does not exist</returns>
        public IdObject Get(string id)
        {
            lock (Lock)
            {
                return Table.ContainsKey(id) ? Table[id] : null;
            }
        }
    }
}
