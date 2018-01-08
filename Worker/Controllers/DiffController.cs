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
        DiffLib.Endpoints.CentralEndpoint CreateCentralEndPoint()
        {
            string _id = ConfigurationManager.AppSettings["WorkerId"];
            string url = ConfigurationManager.AppSettings["CentralBaseUrl"];

            var endpoint = new DiffLib.Endpoints.CentralEndpoint(_id, new Utils.RouteConf(), new DiffLib.WebApiSender(url));
            return endpoint;
        }
        [Route("api/v{version:apiVersion}/diff")]
        [HttpPost]
        public async Task<DiffLib.Packets.CreateIdResponse> Create([FromBody] DiffLib.Packets.CreateIdWorkerRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            return await CreateCentralEndPoint().CreateIdAsync(data.Data);
        }

        [Route("api/v{version:apiVersion}/diff/{id}")]
        [HttpPost]
        public async Task<DiffLib.Packets.CompleteIdResponse> Complete(string id, [FromBody] DiffLib.Packets.CompleteIdWorkerRequest data)
        {
            if (data == null)
                throw new NullReferenceException("data is null");

            return await CreateCentralEndPoint().CompleteIdAsync(id, data.Data);
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


