using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Worker.Tests
{
    [TestClass]
    public class IntegrationTest
    {
        static string WorkerBaseAddr = "http://localhost:49778";
        static string CentralBaseAddtr = "http://localhost:49782";
        static string WorkerId = "w1";
        static Utils.RouteConf Conf = new Utils.RouteConf();

        [TestMethod]
        public void IntegrationTest_HappyPath()
        {
            byte[] B1 = new byte[] { 0x01, 0x76, 0x1F, 0x87, 0xA1, 0x43, 0x44, 0x46, 0x45 };
            byte[] B2 = new byte[] { 0x01, 0x76, 0x1F, 0x87, 0xA1, 0x43, 0x44, 0x46, 0x44 };

            var ep1 = new DiffLib.Endpoints.WorkerEndpoint(Conf, new DiffLib.WebApiSender(WorkerBaseAddr));
            var task1 = ep1.CreateIdAsync(B1);
            var result1 = task1.GetAwaiter().GetResult();

            Assert.AreNotEqual(result1, null);
            Assert.IsFalse(string.IsNullOrEmpty(result1.Id));

            var ep2 = new DiffLib.Endpoints.WorkerEndpoint(Conf, new DiffLib.WebApiSender(WorkerBaseAddr));
            var task2 = ep2.CompleteIdAsync(result1.Id, B2);
            var result2 = task2.GetAwaiter().GetResult();

            Assert.AreNotEqual(result2, null);
            Assert.IsFalse(string.IsNullOrEmpty(result2.Id));

            var ep3 = new DiffLib.Endpoints.CentralEndpoint(WorkerId, Conf, new DiffLib.WebApiSender(CentralBaseAddtr));
            var task3 = ep3.GetDiffAsync(result1.Id);
            var result3 = task3.GetAwaiter().GetResult();

            Assert.AreNotEqual(result3, null);
            Assert.AreNotEqual(result3.Result, null);
            Assert.IsFalse(string.IsNullOrEmpty(result3.Id));
            Assert.IsFalse(string.IsNullOrEmpty(result3.Result.Data1));
            Assert.IsFalse(string.IsNullOrEmpty(result3.Result.Data2));
            Assert.IsFalse(result3.Result.Offsets.Count == 0);
            Assert.IsTrue(result3.Result.Result == DiffLib.DiffResultEnum.SameSize_ContentNotEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "data variable is empty or null")]
        public void IntegrationTest_ArrayByteIsEmpty()
        {
            
            var ep1 = new DiffLib.Endpoints.WorkerEndpoint(Conf, new DiffLib.WebApiSender(WorkerBaseAddr));
            var task1 = ep1.CreateIdAsync(new byte[] { });
            try
            {
                var result1 = task1.GetAwaiter().GetResult();
            }
            catch(ApplicationException ae)
            {
                //data variable is empty or null
                if(ae.Message.Contains("data variable is empty or null"))
                {
                    throw new ApplicationException("data variable is empty or null", ae);
                }
            }
            
            
        }
    }
}
