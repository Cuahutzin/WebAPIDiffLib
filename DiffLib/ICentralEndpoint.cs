using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Endpoint interface that clients and Worker server use.
    /// This servers as a contract for api routes
    /// </summary>
    public interface ICentralEndpoint
    {
        /// <summary>
        /// In order to start the process, an id must be created.
        /// The first byte array is sent through this request
        /// </summary>
        /// <param name="dx"></param>
        /// <returns></returns>
        Task<Packets.CreateIdResponse> CreateIdAsync(byte[] dx);
        /// <summary>
        /// Once an id is given, the second byte array must be sent, using the given id from CreateId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dx"></param>
        /// <returns></returns>
        Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, byte[] dx);
        /// <summary>
        /// Worker servers use this because client already base64 encoded the byte array.
        /// Worker server will just pass it to Central server
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<Packets.CreateIdResponse> CreateIdAsync(string data);
        /// <summary>
        /// Worker servers use this because client already base64 encoded the byte array.
        /// Worker server will just pass it to Central server
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, string data);
        /// <summary>
        /// Client will use this to collect the result. An id must be given (the one that was created by CreateId)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Packets.GetDiffResponse> GetDiffAsync(string id);
    }
}
