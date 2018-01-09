using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public class AspNetCentralServer : ICentralServer
    {
        ICentralServerState State { get; set; }
        string WorkerId { get; set; }
        public AspNetCentralServer(string authorizedWorkerId, ICentralServerState state)
        {
            State = state;
            if (string.IsNullOrEmpty(authorizedWorkerId))
                throw new ArgumentException("authorizedWorkerId is null or empty");
            WorkerId = authorizedWorkerId;
        }

        bool ICentralServer.CompleteId(string workerId, string id, string data)
        {
            CheckWorkerId(workerId);
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("data variable is empty or null");
            return State.CompleteId(id, data);
        }

        string ICentralServer.CreateId(string workerId, string data)
        {
            CheckWorkerId(workerId);
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("data variable is empty or null");
            return State.NewId(data);
        }

        DiffResult ICentralServer.GetDiff(string workerId, string id)
        {
            CheckWorkerId(workerId);
            var obj = State.Get(id);
            if (obj == null)
                throw new KeyNotFoundException("Id does not exist. " + id);

            var result = new DiffResult();
            if (string.IsNullOrEmpty(obj.Data1) || string.IsNullOrEmpty(obj.Data2))
                throw new NullReferenceException("Data is null or empty for Id: " + id);

            result.Data1 = obj.Data1;
            result.Data2 = obj.Data2;

            byte[] da1 = Convert.FromBase64String(obj.Data1);
            byte[] da2 = Convert.FromBase64String(obj.Data2);
            
            if(da1.Length != da2.Length)
            {
                result.Result = DiffResultEnum.NotEqualSize;
            }
            else
            {
                int c = da1.Length;
                DiffOffset offset = null;
                for(int i = 0; i < c; i++)
                {
                    if(da1[i] != da2[i])
                    {
                        if (offset == null)
                        {
                            offset = new DiffOffset();
                            offset.Offset = i;
                        }
                        else
                        {
                            offset.Length++;
                        }
                    }
                    else
                    {
                        if(offset != null)
                        {
                            result.Offsets.Add(offset);
                            offset = null;
                        }
                    }
                }

                if (offset != null)
                {
                    result.Offsets.Add(offset);
                    offset = null;
                }

                result.Result = result.Offsets.Count > 0 ? DiffResultEnum.SameSize_ContentNotEqual : DiffResultEnum.Equal;
            }
            return result;
        }

        protected void CheckWorkerId(string id)
        {
            if (WorkerId != id)
                throw new ApplicationException("Worker is not authorized. Id: " + id);
        }
        
    }
}
