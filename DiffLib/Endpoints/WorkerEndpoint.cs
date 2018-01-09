using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Packets;

namespace DiffLib.Endpoints
{
    /// <summary>
    /// Worker end point that clients will use to communicate to Worker servers
    /// </summary>
    public class WorkerEndpoint
    {
        /// <summary>
        /// Holds api routes
        /// </summary>
        protected IRouteConf Conf { get; private set; }
        /// <summary>
        /// Interface to send data
        /// </summary>
        protected ISender Sender { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conf">Api routes holder</param>
        /// <param name="sender">Interface to send data</param>
        public WorkerEndpoint(IRouteConf conf, ISender sender)
        {
            Conf = conf;
            Sender = sender;
        }

        /// <summary>
        /// In order to start the process, an id must be created.
        /// The first byte array is sent through this request
        /// </summary>
        /// <param name="dx"></param>
        /// <returns></returns>
        public Task<Packets.CreateIdResponse> CreateIdAsync(byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CreateIdResponse, CreateIdWorkerRequest>(Conf.CreateIdPath, new CreateIdWorkerRequest() { Data = data });
        }

        /// <summary>
        /// Worker servers use this because client already base64 encoded the byte array.
        /// Worker server will just pass it to Central server
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dx"></param>
        /// <returns></returns>
        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CompleteIdResponse, CompleteIdWorkerRequest>(Conf.GetCompleteIdPath(id), new CompleteIdWorkerRequest() { Data = data });
        }
        
    }
}
