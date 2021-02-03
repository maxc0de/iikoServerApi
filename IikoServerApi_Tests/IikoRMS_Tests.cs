using System;
using NUnit.Framework;
using IikoServerApi;

namespace IikoServerApi_Tests
{
    class IikoRMS_Tests
    {
        [Test]
        public void TestServerUri()
        {
            IikoRMS iikoServerApi = new IikoRMS("176.118.219.130", 18281, "Zx08365#");

            Assert.AreEqual("http://176.118.219.130:18281/", iikoServerApi.ServerUri.ToString());
        }
    }
}
