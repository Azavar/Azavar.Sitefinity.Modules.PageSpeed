using System;
using System.Collections.Generic;
using System.Linq;
using Azavar.Sitefinity.Modules.PageSpeed.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azavar.Sitefinity.Modules.PageSpeed.Tests
{
    [TestClass]
    public class PageSpeedServiceTests
    {
        private Uri _serviceUri;
        private string _apiKey = "AIzaSyDklKkvMz3u5FJfX5cz2YdoADiNWAOYASA"; //please change this as it will likely stop working

        [TestInitialize]
        public void TestInit()
        {
            _serviceUri = new Uri("https://www.googleapis.com/pagespeedonline/v2/runPagespeed");
        }

        [TestMethod]
        public void PageSpeedService_Should_Return_Results()
        {           
            var pageSpeedService = new PageSpeedService(_apiKey, _serviceUri);

            var pages = new List<Uri>
            {
                new Uri("http://www.azavar.com/home")
            };

            var results = pageSpeedService.RunPageSpeedAsync(pages).Result;

            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_ArgumentException_When_No_Api_Key()
        {
            var pageSpeedService = new PageSpeedService(string.Empty, _serviceUri);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_ArgumentException_When_No_Service_Uri_Key()
        {
            var pageSpeedService = new PageSpeedService(_apiKey, null);
        }

        [TestMethod]
        public void Should_Raise_Event()
        {
            var pageSpeedService = new PageSpeedService(_apiKey, _serviceUri);

            var pages = new List<Uri>
            {
                new Uri("http://www.azavar.com/home"),
                new Uri("http://www.azavar.com/work")
            };

            int count = 0;

            pageSpeedService.PageScanned += delegate (object sender, PageScannedEventArgs args)
            {
                count++;
            };

            var results = pageSpeedService.RunPageSpeedAsync(pages).Result;

            Assert.IsTrue(count == pages.Count);
        }

        [TestMethod]
        public void PageSpeedService_With_Specific_Rule_Should_Return_Results()
        {
            var service = new PageSpeedService(_apiKey, _serviceUri);

            var uris = new List<Uri> { new Uri("http://www.azavar.com/work") };

            var result = service.RunPageSpeedAsync(uris, "LeverageBrowserCaching").Result;

            Assert.IsTrue(result.Any());
        }
    }
}
