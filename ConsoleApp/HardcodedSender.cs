using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HardcodedSender : DiffLib.ISender
    {
        Func<object, string, string> Handler { get; set; }

        public HardcodedSender(Func<object, string, string> handler)
        {
            Handler = handler;
        }

        public object Send(string url, string data)
        {
            return Handler(url, data);
        }
    }
}
