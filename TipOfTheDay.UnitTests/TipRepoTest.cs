using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipOfTheDay.Domain.Concrete;
using TipOfTheDay.Domain.Entities;

namespace TipOfTheDay.UnitTests
{

    // Note: this is just an example of how to write a unit test
    // It also tests our search code that is in the fake repository
    // But we don't really need to test a fake repository. This is just
    // for practice
    [TestClass]
    public class TipRepoTest
    {
        [TestMethod]
        public void GetTipsTest()
        {
            // Arrange
            var target = new FakeTipRepository();
            
            // Act
            var tips = target.GetTips();

            // Assert
            int i = 0;
            foreach (Tip tip in tips)
            {
                i++;
                if(i < 4)
                    Assert.AreEqual(tip.Title, "Tip " + i.ToString());
                else
                    Assert.AreEqual(tip.Title, "C# Object Initialization");
            }

        }


        [TestMethod]
        public void GetTipTest()
        {
            // Arrange
            var target = new FakeTipRepository();

            // Act
            var tip = target.GetTip(new DateTime(2012,3,3));

            // Assert
                Assert.AreEqual(tip.Title, "Tip 3");
        }

    }
}
