using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azavar.Sitefinity.Modules.PageSpeed.Tests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void Should_Only_Return_Valid_Uris()
        {
            var uris = Utilities.ParseUrisFromString("http://www.azavar.com,https://www.google.com,asdfasdf,2123e21");

            Assert.IsTrue(uris.Count == 2);
        }

        [TestMethod]
        public void Should_Only_Return_Valid_Guids()
        {
            var guids =
                "not-a-guid,,9a239daa-7c21-62d7-a6b1-ff0000f8079e,b51f9daa-7c21-62d7-a6b1-ff0000f8079e,bd1f9daa-7c21-62d7-a6b1-ff0000f8079e";

            var uris = Utilities.ParseGuidsFromString(guids);

            Assert.IsTrue(uris.Count == 3);
        }

        [TestMethod]
        public void Should_Shorten_Url()
        {
            var url =
                "https://www.azavar.com/images/default-source/default-album/mobile-strategy.jpg?sfvrsn=0";

            var shortendUrl = Utilities.ShortenUrl(url);

            Assert.AreEqual(shortendUrl, "https://www.azavar.com/…fault-album/mobile-strategy.jpg?sfvrsn=0");
        }
    }
}
