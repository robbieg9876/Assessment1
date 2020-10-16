using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Assessment1;
namespace CanvassTests
{
    
    [TestClass]
    public class UnitTest1 {
        Graphics g;
        Canvass Test = new Canvass();
      
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void MoveToWithValidInputs__MovesPen()
        {
            int toX = 250;
            int toY = 250;
            Test.MoveTo(toX, toY);

            Assert.IsTrue(toX > 0);
            Assert.IsTrue(toY > 0);
        }

        [TestMethod]
        public void MoveToWithInvalidInputs__ShouldThrowArgumentOutOfRange()
        {
            int toX = -250;
            int toY = -250;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => Test.MoveTo(toX, toY));
        }
    }
}
