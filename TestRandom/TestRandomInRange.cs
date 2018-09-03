using System;
using RandomNumberGenerators;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRandom
{
    [TestClass]
    public class TestRandomInRange
    {
        [TestMethod]
        public void GetRandomNumber_InRangeFromOneToTen_ReturnsNumberFromOneToTen()
        {
            int min = 1;
            int max = 10;
            RandomInRange randomInRange = new RandomInRange(min, max);
            int actual = randomInRange.GetRandomNumber();
            Assert.IsTrue(actual >= min && actual <= max);
        }

        [TestMethod]
        public void GetRandomNumber_MoquedRandom_ReturnsNumberInRangeAndUsesMockedRandom()
        {
            int min = 5;
            int max = 10;
            Mock<Random> randomMock = new Mock<Random>();
            randomMock.Setup(random => random.NextDouble()).Returns(0.42);
            RandomInRange randomInRange = new RandomInRange(min, max);
            randomInRange.random = randomMock.Object;
            int expected = (int)(0.42 * (10 - 5) + 5);
            int actual = randomInRange.GetRandomNumber();
            randomMock.Verify(mock => mock.NextDouble(), Times.Once());
            Assert.AreEqual(actual, expected);
        }
    }
}
