using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Assessment1;
using System;

namespace CanvassTests
{
    
    [TestClass]
    public class UnitTest1 {
        //Initialises bitmap with set size
        Bitmap OutputBitMap = new Bitmap(871, 548);

        //Makes an instance of the Canvass class
        readonly Canvass Test;
        public UnitTest1()
        {
            //Sets graphics up on bitmap
            Test = new Canvass(Graphics.FromImage(OutputBitMap));
        }

        [TestMethod]
        public void MoveToTest()
        {
            //Sets integer variables
            int toX = 250;
            int toY = 250;
            //Passes values as parameters to Test.MoveTo
            Test.MoveTo(toX, toY);
            //Checks if the statements are true as expected
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY ==Test.yPos);
        }

        [TestMethod]
        public void DrawToTest()
        {
            //Sets integer variables
            int toX = 250;
            int toY = 250;
            //Passes values as parameters to Test.MoveTo
            Test.DrawTo(toX, toY);
            //Checks if the statements are true as expected
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
        }

        [TestMethod]
        public void PenColourCheck()
        {
            //Sets integer variables
           Color colour = Color.Red;
            //Passes values as parameters to Test.MoveTo
            Test.PenColour(colour);
            //Checks if the statements are true as expected
            Assert.AreEqual(colour, Test.Pen.Color);
            
        }
        [TestMethod]
        public void ResetPenTest()
        {
            //Sets integer variables
            int toX = 0;
            int toY = 0;
            //Passes values as parameters to Test.MoveTo
            Test.resetPenPosition();
            //Checks if the statements are true as expected
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
        }

        [TestMethod]
        public void FillOnTest()
        {
            //Sets integer variables
            Boolean fill = true;
            //Checks if the statements are true as expected
            Test.FillShape(fill);

            Assert.AreEqual(fill,Test.Fill);
        }
        [TestMethod]
        public void FillOffTest()
        {
            //Sets integer variables
            Boolean fill = false;
            //Checks if the statements are true as expected
            Test.FillShape(fill);

            Assert.AreEqual(fill, Test.Fill);
        }

        [TestMethod]
        public void DrawSquareTest()
        {
            //Sets integer variables
            int width = 50;
            int toX = Test.xPos;
            int toY = Test.yPos;
            //Passes values as parameters to Test.MoveTo
            Test.DrawSquare(width);
            //Checks if the statements are true as expected
            //Checks drawing position has not changed
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
            //Checks shape is the same size as expected
            Assert.IsTrue(toX + width == Test.xPos + width);
            Assert.IsTrue(toY + width == Test.yPos + width);
        }
        [TestMethod]
        public void DrawCircleTest()
        {
            //Sets integer variables
            int radius = 50;
            int toX = Test.xPos;
            int toY = Test.yPos;
            //Passes values as parameters to Test.MoveTo
            Test.DrawCircle(radius);
            //Checks if the statements are true as expected
            //Checks drawing position has not changed
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
            //Checks shape is the same size as expected
            Assert.IsTrue(toX + radius == Test.xPos + radius);
            Assert.IsTrue(toY + radius == Test.yPos + radius);
            Assert.IsTrue(toX - radius == Test.xPos - radius);
            Assert.IsTrue(toY - radius == Test.yPos - radius);
        }
        [TestMethod]
        public void DrawTriangleTest()
        {
            //Sets integer variables
            int width = 50;
            int height = 150;
            int toX = Test.xPos;
            int toY = Test.yPos;
            //Passes values as parameters to Test.MoveTo
            Test.DrawTriangle(width,height);
            //Checks if the statements are true as expected
            //Checks drawing position has not changed
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
            //Checks shape is the same size as expected
            Assert.IsTrue(toX + width == Test.xPos + width);
            Assert.IsTrue(toY + height == Test.yPos + height);
        }
        [TestMethod]
        public void DrawRectangleTest()
        {
            //Sets integer variables
            int width = 50;
            int height = 150;
            int toX = Test.xPos;
            int toY = Test.yPos;
            //Passes values as parameters to Test.MoveTo
            Test.DrawRectangle(width, height);
            //Checks if the statements are true as expected
            //Checks drawing position has not changed
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
            //Checks shape is the same size as expected
            Assert.IsTrue(toX + width == Test.xPos + width);
            Assert.IsTrue(toY + height == Test.yPos + height);
        }
    }
}
