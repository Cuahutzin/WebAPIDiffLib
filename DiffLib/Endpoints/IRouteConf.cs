using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLib.Endpoints
{
    public interface IRouteConf
    {
        string BaseUrl { get; }
        string CreateIdPath { get; }

        string GetResultPath(string id);
        string GetCompleteIdPath(string id);
    }
}
