using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azavar.Sitefinity.Modules.PageSpeed.Tests.ViewMapperTests
{
    [TestClass]
    public class GetContextClassFromScore
    {
        [TestMethod]
        public void Should_Return_Success_When_Score_Equal_Or_Above_90()
        {
            var result = ViewMapper.GetContextClassFromScore(90);

            Assert.IsTrue(result == "success");
        }

        [TestMethod]
        public void Should_Return_Success_When_Score_Between_70_and_90()
        {
            var result = ViewMapper.GetContextClassFromScore(70);

            Assert.IsTrue(result == "warning");
        }

        [TestMethod]
        public void Should_Return_Success_When_Score_Below_60()
        {
            var result = ViewMapper.GetContextClassFromScore(59);

            Assert.IsTrue(result == "fail");
        }
    }
}
