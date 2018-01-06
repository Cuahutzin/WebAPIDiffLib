using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffLib;

namespace ConsoleApp
{
    //Aqui me qeude: centralendpoint es el que necesita el ISender
    class Program
    {
        static void Main(string[] args)
        {
            IDiffCentral central = new CentralImplementation(new List<string>() { "workerid1", "workerid2" });

            HardcodedSender firstClientSender = new HardcodedSender(
                (url, data) =>
                {
                    //central.CreateRequest()
                    return null;
                });
            HardcodedSender secondClientSender = new HardcodedSender(
                (url, data) =>
                {
                    //central.CreateRequest()
                    return null;
                });
            string id = CreateRequest(firstClientSender);
            CompleteRequest(id, secondClientSender);
            

            
        }

        static string CreateRequest(ISender sender)
        {
            IDiffWorker worker = new Worker("workerid1", new CentralEndpoint("central_url_endpoint"), sender);
            WorkerCreateRequestResult result;

            try
            {
                result = worker.CreateRequest("mydata1");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception for worker:{worker.Id}. Exception: {e}");
                throw;
            }

            if (result.ResponseEnum == StatusEnum.OK)
            {
                Console.WriteLine($"Request was created by worker:{worker.Id} and request id:{result.Id}");
            }
            else if (result.ResponseEnum == StatusEnum.Unauthorized)
            {
                Console.WriteLine($"Worker:{worker.Id} is not authorized by Central");
            }
            else
            {
                Console.WriteLine($"This status for this request does not make sense:{result.ResponseEnum}");
            }
            return result.Id;
        }

        static void CompleteRequest(string id, ISender sender)
        {
            ///SECOND WORKER SECOND WORKER SECOND WORKER
            IDiffWorker worker = new Worker("workerid2", new CentralEndpoint("central_url_endpoint"), sender);
            WorkerCreateRequestResult result2;

            try
            {
                result2 = worker.CompleteRequest(id, "mydata1");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception for worker:{worker.Id}. Exception: {e}");
                throw;
            }

            if (result2.ResponseEnum == StatusEnum.OK)
            {
                Console.WriteLine($"Request was created by worker:{worker.Id} and request id:{result2.Id}");
            }
            else if (result2.ResponseEnum == StatusEnum.Unauthorized)
            {
                Console.WriteLine($"Worker:{worker.Id} is not authorized by Central");
            }
            else if (result2.ResponseEnum == StatusEnum.IdNotCreated)
            {
                Console.WriteLine($"Request id:{result2.Id} was not created!");
            }
            else
            {
                Console.WriteLine($"This status for this request does not make sense:{result2.ResponseEnum}");
            }
        }

        
    }
}
