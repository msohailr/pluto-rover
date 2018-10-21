using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Test
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void RoverNavigation_Test()
        {
            // First test with a starting position and movement command
            var rover = new Rover(0, 0, 'N');

            rover.Navigate('F');

            Assert.AreEqual(0, rover.X);
            Assert.AreEqual(1, rover.Y);
            Assert.AreEqual('N', rover.Heading);
        }
    }
}
