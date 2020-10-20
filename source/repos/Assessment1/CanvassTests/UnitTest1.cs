using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Assessment1;
namespace CanvassTests
{
    
    [TestClass]
    public class UnitTest1 {
        //Initialises bitmap with set size
        Bitmap OutputBitMap = new Bitmap(871, 548);
        //Makes an instance of the Canvass class
        Canvass Test;
        Form1 test;
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
           Color colour = Color.White;
            //Passes values as parameters to Test.MoveTo
            //Test.PenColour(colour);
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
        public void ClearTest()
        {
            
            //Passes values as parameters to Test.MoveTo
            Test.clearArea(Color.Black);
            //Checks if the statements are true as expected
            
        }
    }
}
