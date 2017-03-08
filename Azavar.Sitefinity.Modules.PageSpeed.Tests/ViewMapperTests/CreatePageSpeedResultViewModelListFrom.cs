using System;
using System.Collections.Generic;
using System.Linq;
using Azavar.Sitefinity.Modules.PageSpeed.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azavar.Sitefinity.Modules.PageSpeed.Tests.ViewMapperTests
{
    [TestClass]
    public class CreatePageSpeedResultViewModelListFrom
    {
        private Uri _serviceUri;
        private string _apiKey = "AIzaSyDklKkvMz3u5FJfX5cz2YdoADiNWAOYASA";

        [TestInitialize]
        public void TestInit()
        {
            _serviceUri = new Uri("https://www.googleapis.com/pagespeedonline/v2/runPagespeed");
        }

        [TestMethod]
        public void Should_Map_Stuff()
        {
            var service = new PageSpeedService(_apiKey, _serviceUri);

            var uris = new List<Uri>
            {
                new Uri("http://www.azavar.com/work"),
                new Uri("http://www.azavar.com/contact"),
                new Uri("http://www.azavar.com/")
            };

            var results = service.RunPageSpeedAsync(uris);

            var resultViewModels = ViewMapper.CreatePageSpeedResultViewModelListFrom(results);

            Assert.IsTrue(resultViewModels.Any());
        }

        [TestMethod]
        public void Mappings_Should_Not_Be_Null()
        {
            var service = new PageSpeedService(_apiKey, _serviceUri);

            var uris = new List<Uri>
            {
                new Uri("http://www.azavar.com")
            };

            var results = service.RunPageSpeedAsync(uris);

            var resultViewModels = ViewMapper.CreatePageSpeedResultViewModelListFrom(results);

            Assert.IsTrue(resultViewModels.Any());
        }
    }
}
