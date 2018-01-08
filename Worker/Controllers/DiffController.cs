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
        [HttpGet]
        public async Task<DiffLib.Packets.CreateIdResponse> Create([FromBody] string data)
        {
            //string data = "";
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Data is null or empty");
            
            return await CreateCentralEndPoint().CreateIdAsync(data);
        }

        [Route("api/v{version:apiVersion}/diff/{id}")]
        [HttpGet]
        public async Task<DiffLib.Packets.CompleteIdResponse> Complete(string id, [FromBody] string data)
        {
            //string data = "";
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Data is null or empty");
            
            return await CreateCentralEndPoint().CompleteIdAsync(id, data);
        }


        [Route("api/v{version:apiVersion}/test/diff/{id}")]
        [HttpGet]
        public async Task<DiffLib.Packets.CompleteIdResponse> Test(string id, [FromBody] string data)
        {
            id = id ?? "EMPTY";
            data = data ?? "EMPTY";
            
            return await Task.Run(() => new DiffLib.Packets.CompleteIdResponse() { Id = id + "|" + data });
        }
    }

    
}


