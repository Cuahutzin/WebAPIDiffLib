using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Central.Controllers
{
    /// <summary>
    /// DiffController for diff operations
    /// </summary>
    public class DiffController : ApiController
    {
        /// <summary>
        /// Diff operations interface.
        /// State is injected by Unity (UnityConfig.cs)
        /// </summary>
        DiffLib.ICentralServer Central;
        
        public DiffController(DiffLib.ICentralServer central)
        {
            Central = central;
        }

        /// <summary>
        /// Creates an id (For more info go to DiffLib.Endpoints or DiffLib.AspNetCentralServer)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/v{version:apiVersion}/diff")]
        [HttpPost]
        public DiffLib.Packets.CreateIdResponse Create([FromBody] DiffLib.Packets.CreateIdCentralRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            string id = Central.CreateId(data.WorkerId, data.Data);

            return new DiffLib.Packets.CreateIdResponse() { Id = id };
        }

        /// <summary>
        /// Completes an id (For more info go to DiffLib.Endpoints or DiffLib.AspNetCentralServer)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/v{version:apiVersion}/diff/{id}")]
        [HttpPost]
        public DiffLib.Packets.CompleteIdResponse Complete(string id, [FromBody] DiffLib.Packets.CompleteIdCentralRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            if (!Central.CompleteId(data.WorkerId, id, data.Data))
                throw new ApplicationException("Central complete id failed to return true.");

            return new DiffLib.Packets.CompleteIdResponse() { Id = id };
        }

        /// <summary>
        /// Diff operation and returns a result (For more info go to DiffLib.Endpoints or DiffLib.AspNetCentralServer)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/v{version:apiVersion}/getdiff/{id}")]
        [HttpPost]
        public DiffLib.Packets.GetDiffResponse GetDiff(string id, [FromBody] DiffLib.Packets.GetDiffRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            var result = Central.GetDiff(data.WorkerId, id);

            return new DiffLib.Packets.GetDiffResponse() { Id = id, Result = result };
        }



        [Route("api/v{version:apiVersion}/test/diff/{id}")]
        [HttpPost]
        public async Task<DiffLib.Packets.CompleteIdResponse> Test(string id, [FromBody] DiffLib.Packets.CompleteIdWorkerRequest data)
        {
            id = id ?? "EMPTY";
            string xdata = "";
            if (data == null)
                xdata = "ISNULL";
            else
            {
                xdata = data.Data;
            }

            return await Task.Run(() => new DiffLib.Packets.CompleteIdResponse() { Id = "CENTRAL|" + id + "|" + xdata });
        }

        [Route("api/v{version:apiVersion}/test/diff/{id}")]
        [HttpGet]
        public async Task<DiffLib.Packets.CompleteIdResponse> TestGet(string id, [FromBody] DiffLib.Packets.CompleteIdWorkerRequest data)
        {
            id = id ?? "EMPTY";
            string xdata = "";
            if (data == null)
                xdata = "ISNULL";
            else
            {
                xdata = data.Data;
            }

            return await Task.Run(() => new DiffLib.Packets.CompleteIdResponse() { Id = "CENTRAL|" + id + "|" + xdata });
        }
    }
}
