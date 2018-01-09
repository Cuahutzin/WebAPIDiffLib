using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Packets;

namespace DiffLib.Endpoints
{
    /// <summary>
    /// Implementation of Central end point
    /// For more information go to ICentralEndpoint
    /// </summary>
    public class CentralEndpoint : ICentralEndpoint, IDisposable
    {
        /// <summary>
        /// WorkerId. CentralServer will deny requests from an unkown id
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// Holds the api routes
        /// </summary>
        protected IRouteConf Conf { get; private set; }
        /// <summary>
        /// Interface to send data
        /// </summary>
        protected ISender Sender { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">WorkerId. Value is required. This works as a whitelist. CentralServer will deny requests from an unkown woder id</param>
        /// <param name="conf">Api routes holder</param>
        /// <param name="sender">Interface to send data</param>
        public CentralEndpoint(string id, IRouteConf conf, ISender sender)
        {
            Id = id;
            Conf = conf;
            Sender = sender;
        }

        /// <summary>
        /// Byte array is base64 encoded and sends it through ISender
        /// </summary>
        /// <param name="dx"></param>
        /// <returns></returns>
        public Task<Packets.CreateIdResponse> CreateIdAsync(byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CreateIdResponse, CreateIdCentralRequest>(Conf.CreateIdPath, new CreateIdCentralRequest() { WorkerId = Id, Data = data });
        }

        /// <summary>
        /// Byte array is base64 encoded and sent through ISender.
        /// Sends a CompleteIdCentralRequest and returns CompleteIdResponse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dx"></param>
        /// <returns></returns>
        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, byte[] dx)
        {
            string data = Convert.ToBase64String(dx);
            return Sender.PostAsync<CompleteIdResponse, CompleteIdCentralRequest>(Conf.GetCompleteIdPath(id), new CompleteIdCentralRequest() { WorkerId = Id, Data = data });
        }

        /// <summary>
        /// Sends a CreateIdCentralRequest and returns CreateIdResponse
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<Packets.CreateIdResponse> CreateIdAsync(string data)
        {
            return Sender.PostAsync<CreateIdResponse, CreateIdCentralRequest>(Conf.CreateIdPath, new CreateIdCentralRequest() { WorkerId = Id, Data = data });
        }

        /// <summary>
        /// Sends a CompleteIdCentralRequest and returns CompleteIdResponse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, string data)
        {
            return Sender.PostAsync<CompleteIdResponse, CompleteIdCentralRequest>(Conf.GetCompleteIdPath(id), new CompleteIdCentralRequest() { WorkerId = Id, Data = data });
        }

        /// <summary>
        /// Sends a GetDiffRequest and returns GetDiffResponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Packets.GetDiffResponse> GetDiffAsync(string id)
        {
            return Sender.PostAsync<GetDiffResponse, GetDiffRequest>(Conf.GetResultPath(id), new GetDiffRequest() { WorkerId = Id });
        }

        /// <summary>
        /// Disposes ISender object
        /// </summary>
        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
