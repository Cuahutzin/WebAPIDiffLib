using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Endpoints;

namespace ConsoleApp
{
    public class RouteConfTest : DiffLib.Endpoints.IRouteConf
    {
        string IRouteConf.CreateIdPath => "/api/v1.0/diff";
        string CompleteIdPath => "/api/v1.0/diff/{ID}";
        string GetResultPath => "/api/v1.0/getdiff/{ID}";
        
        public RouteConfTest()
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
