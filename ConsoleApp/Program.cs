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
        static string WorkerBaseAddr = "http://localhost:49778";
        static string CentralBaseAddtr = "http://localhost:49782";
        static string WorkerId = "w1";

        static void Main(string[] args)
        {
            var id = Step1();
            if (!string.IsNullOrEmpty(id))
            {
                if(id == Step2(id))
                {
                    Step3(id);
                }
            }
            Console.WriteLine("End of application");
            Console.ReadLine();
        }

        static string Step1()
        {
            var newconf = new RouteConfTest();
            var worker1x = new DiffLib.Endpoints.WorkerEndpoint(newconf, new DiffLib.WebApiSender(WorkerBaseAddr));
            var task = worker1x.CreateIdAsync("mydata1");
            try
            {
                var realobj = task.GetAwaiter().GetResult();
                if (realobj == null)
                {
                    Console.WriteLine("Step1:Obj is null");
                }
                else
                {
                    Console.WriteLine("Result 1: " + realobj.Id);
                    return realobj.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            return null;
        }

        static string Step2(string id)
        {
            var newconf = new RouteConfTest();
            var worker1x = new DiffLib.Endpoints.WorkerEndpoint(newconf, new DiffLib.WebApiSender(WorkerBaseAddr));
            var task = worker1x.CompleteIdAsync(id, "mydata2BIGGER");
            try
            {
                var realobj = task.GetAwaiter().GetResult();
                if (realobj == null)
                {
                    Console.WriteLine("Step2:Obj is null");
                }
                else
                {
                    Console.WriteLine("Result 2: " + realobj.Id);
                    return realobj.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            return null;
        }

        static string Step3(string id)
        {
            var newconf = new RouteConfTest();
            var worker1x = new DiffLib.Endpoints.CentralEndpoint(WorkerId, newconf, new DiffLib.WebApiSender(CentralBaseAddtr));
            var task = worker1x.GetDiffAsync(id);
            try
            {
                var realobj = task.GetAwaiter().GetResult();
                if (realobj == null)
                {
                    Console.WriteLine("Step3:Obj is null");
                }
                else
                {
                    Console.WriteLine($"Result 3: {realobj.Id} | Data:{realobj.Result}");
                    return realobj.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            return null;
        }

    }
}
