using System;
using Azavar.Sitefinity.Modules.PageSpeed.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azavar.Sitefinity.Modules.PageSpeed.Tests
{
    [TestClass]
    public class MapTokensFrom
    {
        [TestMethod]
        public void Null_Args_Should_Return_Format()
        {
            var summary = new Summary
            {
                Args = null,
                Format = "format"
            };

            var formattedString = ViewMapper.MapTokensFrom(summary);

            Assert.IsTrue(formattedString == summary.Format);
        }

        [TestMethod]
        public void Link_Args_Should_Replace_Tokens()
        {
            var arg = new Arg
            {
                Key = "LINK",
                Type = "not used right now?",
                Value = "http://www.google.com"
            };

            var summary = new Summary
            {
                Args = new[]
                {
                    arg
                },
                Format = "Your page has no redirects. Learn more about {{BEGIN_LINK}}avoiding landing page redirects{{END_LINK}}."
            };

            var formattedString = ViewMapper.MapTokensFrom(summary);

            Assert.IsTrue(formattedString.Contains(arg.Value));
        }
    }
}
