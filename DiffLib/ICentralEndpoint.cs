using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    public interface ICentralEndpoint
    {
        Task<Packets.CreateIdResponse> CreateIdAsync(byte[] dx);
        Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, byte[] dx);
        Task<Packets.CreateIdResponse> CreateIdAsync(string data);
        Task<Packets.CompleteIdResponse> CompleteIdAsync(string id, string data);
        Task<Packets.GetDiffResponse> GetDiffAsync(string id);
    }
}
