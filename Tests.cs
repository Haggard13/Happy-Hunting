using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Hunting
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void DirectionTest()
        {
            Assert.AreEqual(new Point(1, 0), Direction.Right.CreateNewPosition(new Point(0, 0)));
            Assert.AreEqual(new Point(-1, 0), Direction.Left.CreateNewPosition(new Point(0, 0)));
            Assert.AreEqual(new Point(0, -1), Direction.Up.CreateNewPosition(new Point(0, 0)));
            Assert.AreEqual(new Point(0, 1), Direction.Down.CreateNewPosition(new Point(0, 0)));
        }

        [Test]
        public void FindElementsText()
        {
            var testLevel = new GameLevel(new ElementsOfMap[,] { { ElementsOfMap.Gomer, ElementsOfMap.Flanders, ElementsOfMap.Donut } });
            Assert.AreEqual(new Point(0, 0), testLevel.Gomer.Position);
            Assert.AreEqual(new Point(0, 1), testLevel.Flanders.Position);
            Assert.IsTrue(testLevel.Donuts.Contains(new Point(0, 2)));
        }

        [Test]
        public void GomerMoveing()
        {
            var Gomer1 = new Gomer(new Point(0,0));
            Gomer1.Move(new GameLevel(new ElementsOfMap[,] { { ElementsOfMap.Gomer } }), Direction.Down);

            var Gomer2 = new Gomer(new Point(0, 0));
            var levelForGomer2 = new GameLevel(new ElementsOfMap[,] { { ElementsOfMap.Gomer, ElementsOfMap.Donut, ElementsOfMap.Donut } });
            Gomer2.GomerGrabeDount += (q) => { };
            Gomer2.GomerMove += (q) => { };
            Gomer2.Move(levelForGomer2, Direction.Down);

            var Gomer3 = new Gomer(new Point(0, 0));
            var levelForGomer3 = new GameLevel(new ElementsOfMap[,] { { ElementsOfMap.Gomer, ElementsOfMap.Donut, ElementsOfMap.Bible, ElementsOfMap.Donut } });
            Gomer3.GomerGrabeDount += (q) => { };
            Gomer3.GomerMove += (q) => { };
            Gomer3.Move(levelForGomer3, Direction.Down);
            Gomer3.Move(levelForGomer3, Direction.Down);

            Assert.AreEqual(new Point(0, 0), Gomer1.Position);
            Assert.AreEqual(1, Gomer2.Donuts);
            Assert.AreEqual(0, Gomer3.Donuts);
        }

    }
}
