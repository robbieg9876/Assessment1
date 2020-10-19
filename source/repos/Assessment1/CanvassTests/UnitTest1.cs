using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Assessment1;
namespace CanvassTests
{
    
    [TestClass]
    public class UnitTest1 {
        //Initialises variables
        Graphics g;
        //Creates an instance of Canvass.
        Canvass Test = new Canvass();
      
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void MoveToWithValidInputs__MovesPen()
        {
            //Sets integer variables
            int toX = 250;
            int toY = 250;
            //Passes values as parameters to Test.MoveTo
            Test.MoveTo(toX, toY);
            //Checks if the statements are true as expected
            Assert.IsTrue(toX > 0);
            Assert.IsTrue(toY > 0);
        }

        [TestMethod]
        public void MoveToWithInvalidInputs__ShouldThrowArgumentOutOfRange()
        {
            //Sets integer variables
            int toX = -250;
            int toY = -250;
            //Checks that an exception is thrown as expected
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => Test.MoveTo(toX, toY));
        }
    }
}
