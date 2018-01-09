using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Endpoints;

namespace Utils
{
    /// <summary>
    /// Implementation of api route holder.
    /// Values are hardcoded.
    /// For more info go to IRouteConf
    /// </summary>
    public class RouteConf : DiffLib.Endpoints.IRouteConf
    {
        /// <summary>
        /// Create id api route
        /// </summary>
        string IRouteConf.CreateIdPath => "/api/v1.0/diff";
        string CompleteIdPath => "/api/v1.0/diff/{ID}";
        string GetResultPath => "/api/v1.0/getdiff/{ID}";
        
        /// <summary>
        /// Replaces params that go into the URI. Complete id api route
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string IRouteConf.GetCompleteIdPath(string id)
        {
            return CompleteIdPath.Replace("{ID}", id);
        }

        /// <summary>
        /// Replaces params that go into the URI. GetDiff api route
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string IRouteConf.GetResultPath(string id)
        {
            return GetResultPath.Replace("{ID}", id);
        }
    }
}
