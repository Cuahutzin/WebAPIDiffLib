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
    [Microsoft.Web.Http.ApiVersion("1.0")]
    public class DiffController : ApiController
    {
        DiffLib.ICentralEndpoint CentralEndPoint;
        public DiffController(DiffLib.ICentralEndpoint endpoint)
        {
            CentralEndPoint = endpoint;
        }
        
        [Route("api/v{version:apiVersion}/diff")]
        [HttpPost]
        public async Task<DiffLib.Packets.CreateIdResponse> Create([FromBody] DiffLib.Packets.CreateIdWorkerRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            return await CentralEndPoint.CreateIdAsync(data.Data);
        }

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


