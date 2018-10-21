using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Test
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void RoverNavigation_SingleStep_Test()
        {
            // First test with a starting position and movement command
            var rover = new Rover(0, 0, 'N', 100, 100);

            rover.Navigate("F");

            Assert.AreEqual(0, rover.X);
            Assert.AreEqual(1, rover.Y);
            Assert.AreEqual('N', rover.Heading.ToString()[0]);
        }

        [TestMethod]
        public void RoverNavigation_MultipleSteps_Test()
        {
            var rover = new Rover(0, 0, 'N', 100, 100);

            rover.Navigate("FFRL");

            Assert.AreEqual(0, rover.X);
            Assert.AreEqual(2, rover.Y);
            Assert.AreEqual('N', rover.Heading.ToString()[0]); // Turn Right and then Left should bring to original heading
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RoverNavigation_GridLimit_Test()
        {
            var rover = new Rover(0, 0, 'N', 100, 100);

            // Throws ArgumentOutOfRangeException as rover could navigate out of grid boundaries
            rover.Navigate("BLF"); // this should be invalid as the rover should not go out of bounds now!
        }
    }
}
