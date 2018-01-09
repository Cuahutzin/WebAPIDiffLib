using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Worker.Controllers
{
    /// <summary>
    /// DiffController for diff operations.
    /// Create and Complete are passed to central server
    /// </summary>
    [Microsoft.Web.Http.ApiVersion("1.0")]
    public class DiffController : ApiController
    {
        /// <summary>
        /// Central server endpoint interface
        /// </summary>
        DiffLib.ICentralEndpoint CentralEndPoint;
        public DiffController(DiffLib.ICentralEndpoint endpoint)
        {
            CentralEndPoint = endpoint;
        }

        /// <summary>
        /// Sends request to central server to create an id (For more info go to DiffLib.Endpoints or DiffLib.AspNetCentralServer)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/v{version:apiVersion}/diff")]
        [HttpPost]
        public async Task<DiffLib.Packets.CreateIdResponse> Create([FromBody] DiffLib.Packets.CreateIdWorkerRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            return await CentralEndPoint.CreateIdAsync(data.Data);
        }

        /// <summary>
        /// Completes an id by sending request to server (For more info go to DiffLib.Endpoints or DiffLib.AspNetCentralServer)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/v{version:apiVersion}/diff/{id}")]
        [HttpPost]
        public async Task<DiffLib.Packets.CompleteIdResponse> Complete(string id, [FromBody] DiffLib.Packets.CompleteIdWorkerRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            return await CentralEndPoint.CompleteIdAsync(id, data.Data);
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
            
            return await Task.Run(() => new DiffLib.Packets.CompleteIdResponse() { Id = id + "|" + xdata });
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

            return await Task.Run(() => new DiffLib.Packets.CompleteIdResponse() { Id = id + "|" + xdata });
        }
    }

    
}


