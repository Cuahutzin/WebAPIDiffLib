using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Endpoints;

namespace Utils
{
    public class RouteConf : DiffLib.Endpoints.IRouteConf
    {
        string IRouteConf.CreateIdPath => "/api/v1/diff";
        string CompleteIdPath => "/api/v1/diff/{ID}";
        string GetResultPath => "/api/v1/diff/{ID}";

        public RouteConf()
        {
            
        }

        string IRouteConf.GetCompleteIdPath(string id)
        {
            return CompleteIdPath.Replace("{ID}", id);
        }

        string IRouteConf.GetResultPath(string id)
        {
            return GetResultPath.Replace("{ID}", id);
        }
    }
}
