using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib.Endpoints;

namespace ConsoleApp
{
    public class HardcodedRouteConf : DiffLib.Endpoints.IRouteConf
    {
        string IRouteConf.CreateIdPath => "/v1/diff/create";
        string CompleteIdPath => "/v1/diff/{ID}";
        string GetResultPath => "/v1/get-diff/{ID}";

        public HardcodedRouteConf()
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
