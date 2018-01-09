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
    public class CentralDiffController
    {
        [TestMethod]
        public void CreateShouldWork()
        {
            var mock = new Moq.Mock<DiffLib.ICentralServer>();
            mock.Setup(x => x.CreateId("w1", "data1")).Returns("newid1");

            Central.Controllers.DiffController dc = new Central.Controllers.DiffController(mock.Object);
            var result = dc.Create(new DiffLib.Packets.CreateIdCentralRequest()
            {
                Data = "data1",
                WorkerId = "w1"
            });
            
            Assert.AreEqual(result.Id, "newid1");
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "Central complete id failed to return true.")]
        public void CompleteShouldWorkThrowException()
        {
            var mock = new Moq.Mock<DiffLib.ICentralServer>();
            mock.Setup(x => x.CompleteId("w1", "id1", "data")).Returns(false);

            Central.Controllers.DiffController dc = new Central.Controllers.DiffController(mock.Object);
            var result = dc.Complete("id1", new DiffLib.Packets.CompleteIdCentralRequest()
            {
                Data = "data1",
                WorkerId = "w1"
            });
        }
    }
}
