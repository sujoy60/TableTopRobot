using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTopRobo;

namespace TableTopRobo.Tests
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Robot_InitialisedButNotPlaced_CannotBeMoved()
        {
            var robot = new Robot();
            var result = robot.Move();
            Assert.IsFalse(result);
            Assert.AreEqual("Robot cannot move until it has been placed on the table.", robot.LastError);
        }


        [TestMethod]
        public void Robot_PlacedAndTurnedRight_ReportsCorrectPosition()
        {
            var robot = new Robot();
            robot.Place(1, 1, Facing.North);
            robot.Right();
            Assert.AreEqual("1,1,EAST", robot.Report());
        }
    }
}
