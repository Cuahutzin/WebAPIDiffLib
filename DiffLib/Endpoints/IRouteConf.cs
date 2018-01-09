using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Endpoints
{
    public interface IRouteConf
    {
        /// <summary>
        /// CreateId route api
        /// </summary>
        string CreateIdPath { get; }

        /// <summary>
        /// GetDiff route api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetResultPath(string id);
        /// <summary>
        /// CompleteId route api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetCompleteIdPath(string id);
    }
}
