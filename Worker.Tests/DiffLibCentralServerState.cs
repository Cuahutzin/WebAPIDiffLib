using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Worker.Tests
{
    [TestClass]
    public class DiffLibCentralServerState
    {
        [TestMethod]
        public void MultiThreadNewIdTest()
        {
            var t = new DiffLib.CentralServerState();

            List<Action> actions = new List<Action>();
            ConcurrentBag<string> ids = new ConcurrentBag<string>();

            for (int i = 0; i < 100; i++)
            {
                actions.Add(new Action(() =>
                {
                    var id = t.NewId("myrealdata1");
                    t.CompleteId(id, "myrealdata2");
                    ids.Add(id);
                }));
            }

            Parallel.ForEach(actions, (x) => { x.Invoke(); });

            List<string> listIds = ids.ToList();
            foreach(var id in listIds)
            {
                var obj = t.Get(id);
                Assert.AreNotEqual(obj, null);
                Assert.AreEqual(obj.Id, id);
                Assert.AreEqual(obj.Data1, "myrealdata1");
                Assert.AreEqual(obj.Data2, "myrealdata2");
            }
        }
    }
}
