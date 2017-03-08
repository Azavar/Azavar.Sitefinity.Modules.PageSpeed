using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azavar.Sitefinity.Modules.PageSpeed.Tests.ViewMapperTests
{
    [TestClass]
    public class GetSeverityFromRuleImpact
    {
        [TestMethod]
        public void GetSeverity_Should_Return_Should_Fix_When_Impact_Greater_Than_Ten()
        {
            var severity = ViewMapper.GetSeverityFromRuleImpact(11);

            Assert.IsTrue(severity == "should-fix");
        }

        [TestMethod]
        public void GetSeverity_Should_Return_Passed_When_Impact_Is_Zero()
        {
            var severity = ViewMapper.GetSeverityFromRuleImpact(0);

            Assert.IsTrue(severity == "passed");
        }

        [TestMethod]
        public void GetSeverity_Should_Return_Consider_Fixing_When_Impact_Is_Zero()
        {
            var severity = ViewMapper.GetSeverityFromRuleImpact(5);

            Assert.IsTrue(severity == "consider-fixing");
        }
    }
}
