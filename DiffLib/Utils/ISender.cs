using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib
{
    /// <summary>
    /// Interface that Worker uses to send data remotely
    /// </summary>
    public interface ISender : IDisposable
    {
        /// <summary>
        /// Async post.
        /// </summary>
        /// <typeparam name="T">Response object to be sent to server/entity</typeparam>
        /// <typeparam name="K">Request object to be sent to server/entity</typeparam>
        /// <param name="path">Api route</param>
        /// <param name="obj">See Typeparam K</param>
        /// <returns></returns>
        Task<T> PostAsync<T, K>(string path, K obj) where T : class, new();
        
    }
}
