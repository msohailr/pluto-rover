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
            var rover = new Rover(0, 0, 'N', new PlutoGrid(100, 100));

            rover.Navigate("F");

            Assert.AreEqual(0, rover.X);
            Assert.AreEqual(1, rover.Y);
            Assert.AreEqual('N', rover.Heading.ToString()[0]);
        }

        [TestMethod]
        public void RoverNavigation_MultipleSteps_Test()
        {
            var rover = new Rover(0, 0, 'N', new PlutoGrid(100, 100));

            rover.Navigate("FFRL");

            Assert.AreEqual(0, rover.X);
            Assert.AreEqual(2, rover.Y);
            Assert.AreEqual('N', rover.Heading.ToString()[0]); // Turn Right and then Left should bring to original heading
        }

        [TestMethod]
        public void RoverNavigation_RoverToString_Test()
        {
            var rover = new Rover(0, 0, 'N', new PlutoGrid(100, 100));

            rover.Navigate("FFRFF");

            Assert.AreEqual("2, 2, facing East", rover.ToString());
        }

        [TestMethod]
        public void RoverNavigation_Obstacle_Test()
        {
            var grid = new PlutoGrid(100, 100);
            grid.AddObstacle(10, 15);

            var rover = new Rover(9, 12, 'N', grid);

            rover.Navigate("FFFRF");

            Assert.AreEqual("Found obstacle at {10, 15}", rover.ObstacleReport);
        }

        [TestMethod]
        public void RoverNavigation_WrapGrid_Test()
        {
            var grid = new PlutoGrid(10, 10);
            var rover = new Rover(8, 9, 'E', grid);

            rover.Navigate("FFLFF");

            Assert.AreEqual("10, 0, facing North", rover.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void RoverNavigation_InvalidCommand_Test()
        {
            var grid = new PlutoGrid(10, 10);
            var rover = new Rover(8, 9, 'E', grid);

            rover.Navigate("FFC");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void RoverNavigation_InvalidHeading_Test()
        {
            var grid = new PlutoGrid(10, 10);
            var rover = new Rover(8, 9, 'P', grid);
        }
    }
}
