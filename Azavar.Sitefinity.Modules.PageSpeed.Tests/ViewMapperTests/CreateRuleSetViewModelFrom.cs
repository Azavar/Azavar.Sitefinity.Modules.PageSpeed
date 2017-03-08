using System;
using System.Collections.Generic;
using Azavar.Sitefinity.Modules.PageSpeed.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azavar.Sitefinity.Modules.PageSpeed.Tests.ViewMapperTests
{
    [TestClass]
    public class CreateRuleSetViewModelFrom
    {
        private Uri _serviceUri;
        private string _apiKey = "AIzaSyDklKkvMz3u5FJfX5cz2YdoADiNWAOYASA";
        private PageSpeedService _service;
        private List<Uri> _uris;

        [TestInitialize]
        public void TestInit()
        {
            _serviceUri = new Uri("https://www.googleapis.com/pagespeedonline/v2/runPagespeed");
            _service = new PageSpeedService(_apiKey, _serviceUri);
            _uris = new List<Uri> { new Uri("http://www.azavar.com/work") };
        }

        [TestMethod]
        public void CreateRuleSetViewModelFrom_Should_Map()
        {           
            var ruleName = "LeverageBrowserCaching";

            var result = _service.RunPageSpeedAsync(_uris, ruleName);

            var ruleSetViewModel = ViewMapper.CreateRuleSetViewModelFrom(result.Result, ruleName);

            Assert.IsNotNull(ruleSetViewModel);
        }

        [TestMethod]
        public void CreateRuleSetViewModelFrom_Using_LeverageBrowserCaching_Should_Map()
        {
            var ruleName = "LeverageBrowserCaching";

            var result = _service.RunPageSpeedAsync(_uris, ruleName).Result;

            var ruleSetViewModel = ViewMapper.CreateRuleSetViewModelFrom(result, ruleName);

            Assert.IsNotNull(ruleSetViewModel);
        }

        [TestMethod]
        public void CreateRuleSetViewModelFrom_Using_EnableGzipCompression_Should_Map()
        {
            var service = new PageSpeedService(_apiKey, _serviceUri);

            var uris = new List<Uri> { new Uri("http://www.azavar.com/work") };

            var ruleName = "EnableGzipCompression";

            var result = service.RunPageSpeedAsync(uris, ruleName).Result;

            var ruleSetViewModel = ViewMapper.CreateRuleSetViewModelFrom(result, ruleName);

            Assert.IsNotNull(ruleSetViewModel);
        }

        [TestMethod]
        public void CreateRuleSetViewModelFrom_Using_MinimizeRenderBlockingResources_Should_Map()
        {
            var ruleName = "MinimizeRenderBlockingResources";

            var result = _service.RunPageSpeedAsync(_uris, ruleName).Result;

            var ruleSetViewModel = ViewMapper.CreateRuleSetViewModelFrom(result, ruleName);

            Assert.IsNotNull(ruleSetViewModel);
        }

        [TestMethod]
        public void CreateRuleSetViewModelFrom_Using_MainResourceServerResponseTime_Should_Map()
        {
            var ruleName = "MainResourceServerResponseTime";

            var result = _service.RunPageSpeedAsync(_uris, ruleName).Result;

            var ruleSetViewModel = ViewMapper.CreateRuleSetViewModelFrom(result, ruleName);

            Assert.IsNotNull(ruleSetViewModel);
        }

        [TestMethod]
        public void CreateRuleSetViewModelFrom_Using_OptimizeImages_Should_Map()
        {
            var ruleName = "OptimizeImages";

            var result = _service.RunPageSpeedAsync(_uris, ruleName).Result;

            var ruleSetViewModel = ViewMapper.CreateRuleSetViewModelFrom(result, ruleName);

            Assert.IsNotNull(ruleSetViewModel);
        }
    }
}
