using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib;
using DiffLib.Packets;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDiffCentral central = new CentralImplementation(new List<string>() { "workerid1", "workerid2", "workerid3" });

            var conf = new RouteConf();
            var worker1 = new DiffLib.Endpoints.WorkerEndpoint("w1", conf, new HardcodedSender());
            var task = worker1.CreateIdAsync("binarydata");
            CreateIdResponse ret = null;
            try
            {
                ret = task.GetAwaiter().GetResult();
                if (ret == null || string.IsNullOrEmpty(ret.Id))
                    throw new ApplicationException("Return is null or id is empty");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                Console.WriteLine("End of application");
                Console.ReadLine();
                return;
            }

            if (SecondStep(ret.Id, conf))
            {
                string result = ThirdStep(ret.Id, conf);
                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine($"Got final result: {result}");
                }
            }
            Console.WriteLine("End of application");
            Console.ReadLine();
        }

        static bool SecondStep(string id, RouteConf conf)
        {
            var worker1 = new DiffLib.Endpoints.WorkerEndpoint("w2", conf, new HardcodedSender());
            var task = worker1.CompleteIdAsync(id, "binarydata");
            CompleteIdResponse ret = null;
            try
            {
                ret = task.GetAwaiter().GetResult();
                if (ret == null || string.IsNullOrEmpty(ret.Id))
                    throw new ApplicationException("SecondStep=> Return is null or id is empty");
            }
            catch (Exception e)
            {
                Console.WriteLine($"SecondStep=> Exception: {e}");
                return false;
            }
            return true;
        }

        static string ThirdStep(string id, RouteConf conf)
        {
            var client = new DiffLib.Endpoints.CentralEndpoint("client", conf, new HardcodedSender());
            var task = client.GetDiffAsync(id);
            GetDiffResponse ret = null;
            try
            {
                ret = task.GetAwaiter().GetResult();
                if (ret == null || string.IsNullOrEmpty(ret.Id))
                    throw new ApplicationException("SecondStep=> Return is null or id is empty");
            }
            catch (Exception e)
            {
                Console.WriteLine($"SecondStep=> Exception: {e}");
                return null;
            }
            return ret.Result;
        }
    }
}
