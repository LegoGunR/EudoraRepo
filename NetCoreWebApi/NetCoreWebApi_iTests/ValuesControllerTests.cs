using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NetCoreWebApi;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void GetterTest()
        {
            using (TestServer server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>()))
            using (HttpClient client = server.CreateClient())
            {
                Task<string> t = client.GetStringAsync("/api/values/5");
                Assert.That(t.Wait(TimeSpan.FromSeconds(5)), "timeout");
                StringAssert.AreEqualIgnoringCase("value", t.Result, "result");
            }
        }
    }
}