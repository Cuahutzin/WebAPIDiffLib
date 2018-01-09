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
        static byte[] B1 = new byte[] { 0x01, 0x76, 0x1F, 0x87, 0xA1, 0x43, 0x44, 0x46, 0x45 };
        static byte[] B2 = new byte[] { 0x01, 0x76, 0x1F, 0x87, 0xA1, 0x43, 0x44, 0x46, 0x44 };
        static void Main(string[] args)
        {
            Console.Write($"B1 Length: {B1.Length} Data: ");
            foreach(var b in B1) { Console.Write(((int)b).ToString() + ","); }
            Console.WriteLine("");
            Console.Write($"B2 Length: {B2.Length} Data: ");
            foreach (var b in B2) { Console.Write(((int)b).ToString() + ","); }
            Console.WriteLine("");

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
            var newconf = new Utils.RouteConf();
            var worker1x = new DiffLib.Endpoints.WorkerEndpoint(newconf, new DiffLib.WebApiSender(WorkerBaseAddr));
            var task = worker1x.CreateIdAsync(B1);
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
            var newconf = new Utils.RouteConf();
            var worker1x = new DiffLib.Endpoints.WorkerEndpoint(newconf, new DiffLib.WebApiSender(WorkerBaseAddr));
            var task = worker1x.CompleteIdAsync(id, B2);
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
            var newconf = new Utils.RouteConf();
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
                    Console.WriteLine($"Result 3: {realobj.Id} | Result(enum):{realobj.Result.Result}");
                    
                    var b1a = Convert.FromBase64String(realobj.Result.Data1);
                    var b2a = Convert.FromBase64String(realobj.Result.Data2);

                    Console.Write($"CentralB1 Length: {b1a.Length} Data: ");
                    foreach (var b in b1a) { Console.Write(((int)b).ToString() + ","); }
                    Console.WriteLine("");
                    Console.Write($"CentralB2 Length: {b2a.Length} Data: ");
                    foreach (var b in b2a) { Console.Write(((int)b).ToString() + ","); }
                    Console.WriteLine("");

                    if (realobj.Result.Offsets.Count > 0)
                    {
                        foreach(var o in realobj.Result.Offsets)
                        {
                            Console.WriteLine($"Offset: {o.Offset} Length: {o.Length}");
                        }
                    }
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
