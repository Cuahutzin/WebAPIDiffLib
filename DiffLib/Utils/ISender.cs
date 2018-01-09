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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<T> PostAsync<T, K>(string path, K obj) where T : class, new();
        
    }
}
