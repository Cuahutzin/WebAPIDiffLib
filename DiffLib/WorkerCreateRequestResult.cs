using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public class WorkerCreateRequestResult
    {
        public StatusEnum ResponseEnum { get; private set; }
        public string Id { get; private set; }

        public WorkerCreateRequestResult(StatusEnum status)
        {
            Id = string.Empty;
        }

        public WorkerCreateRequestResult(StatusEnum status, string id)
        {
            ResponseEnum = status;
            Id = id;
        }
    }
}
