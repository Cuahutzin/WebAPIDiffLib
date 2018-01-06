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
    public interface ISender
    {
        object Send(string url, string data);
    }
}
