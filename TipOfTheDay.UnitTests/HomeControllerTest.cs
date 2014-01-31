using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipOfTheDay.Domain.Concrete;
using System.Web.Mvc;

namespace TipOfTheDay.UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestGetTodaysTip()
        {
            // Arrange
            FakeTipRepository repo = new FakeTipRepository();
            var target = new TipOfTheDay.WebUI.Controllers.HomeController(repo);
            
            // Act
            target.Index();

            // Assert
            Assert.AreEqual(repo.CurrentTip.Title, "Tip 1");
        }
    }
}
