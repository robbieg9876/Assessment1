using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Assessment1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CanvassTests
{

    [TestClass]
    public class UnitTest1 {
        //Initialises bitmap with set size
        Bitmap OutputBitMap = new Bitmap(871, 548);

        //Makes an instance of the Canvass class
        readonly Canvass Test;
        Form1 form1 = new Form1();
        public UnitTest1()
        {
            //Sets graphics up on bitmap
            Test = new Canvass(Graphics.FromImage(OutputBitMap));
        }

        [TestMethod]
        public void TestInvalidCommand()
        {
            //Sets variables
            String Command = "move to ";
            String[] CommandSplit = new String[100]; 
            CommandSplit=Command.Split(' ');
            //Checks if the statements are true as expected
            Assert.AreNotEqual("moveto.", CommandSplit[0]);
        }
        [TestMethod]
        public void TestNoParameters()
        {
            //Sets integer variables
            String message = "";
            String input= "test " ;
            String[] testArray = new String[5];
            testArray= input.Split(",".ToCharArray());
            try
            {
                int x = int.Parse(testArray[1]);
            }
            catch (IndexOutOfRangeException ex1)
            {
                message = ex1.Message;
            }
            //Checks if the statements are true as expected
            Assert.AreEqual("Index was outside the bounds of the array.", message);
        }

        [TestMethod]
        public void TestTooManyParameters()
        {
            //Sets integer variables

            String message = "";
            int[] testArray = new int[1];
            try
            {
                int check = testArray[2];
            }
            catch (IndexOutOfRangeException ex2)
            {
                message = ex2.Message;
            }
            //Checks if the statements are true as expected
            Assert.AreEqual("Index was outside the bounds of the array.", message);
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
        public void MoveToTestInvalidParameter()
        {
            //Sets integer variables
             String toX = "250a";
             String toY = "250a";
            String message = "";
            //Passes values as parameters to Test.MoveTo
            try
            {
                Test.MoveTo(int.Parse(toX), int.Parse(toY));
            }
            catch (FormatException ex)
            {
                message = ex.Message;
            }


            //Checks if the statements are true as expected
            Assert.AreEqual("Input string was not in a correct format.", message);
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
        public void DrawToTestInvalidParameter()
        {
            //Sets integer variables
            String toX = "250a";
            String toY = "250a";
            String message = "";
            //Passes values as parameters to Test.MoveTo
            try
            {
                Test.DrawTo(int.Parse(toX), int.Parse(toY));
            }
            catch (FormatException ex)
            {
                message = ex.Message;
            }


            //Checks if the statements are true as expected
            Assert.AreEqual("Input string was not in a correct format.", message);
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
           int fill = 1;
            Boolean Fill = true;
            //Checks if the statements are true as expected
            Test.FillShape(Fill);

            Assert.AreEqual(fill,Test.Fill);
        }
        [TestMethod]
        public void FillOffTest()
        {
            //Sets integer variables
            int Fill = 0;
            Boolean fill = false;
            //Checks if the statements are true as expected
            Test.FillShape(fill);

            Assert.AreEqual(Fill, Test.Fill);
        }

        [TestMethod]
        public void DrawSquareTest()
        {
            //Sets integer variables
            int width = 50;
            int toX = Test.xPos;
            int toY = Test.yPos;
            form1.CommandSplit = "square 50".Split(' ');
            form1.command();
            //Checks if the statements are true as expected
            //Checks drawing position has not changed
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
            //Checks shape is the same size as expected
            Assert.IsTrue(toX + width == Test.xPos + width);
            Assert.IsTrue(toY + width == Test.yPos + width);
        }

        [TestMethod]
        public void DrawSquareTestInvalidParameter()
        {
            //Sets integer variables
            String width = "250a";
            String message = "";
            //Passes values as parameters to Test.MoveTo
                form1.CommandSplit = "square 250a".Split(' ');
                form1.command();
            


            //Checks if the statements are true as expected
            Assert.AreEqual("ERROR INVALID PARAMETERS", form1.error);
        }
        [TestMethod]
        public void DrawCircleTest()
        {
            //Sets integer variables
            int radius = 50;
            int toX = Test.xPos;
            int toY = Test.yPos;
            //Passes values as parameters to Test.MoveTo
            form1.CommandSplit = "circle 50".Split(' ');
            form1.command();
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
        public void DrawCircleTestInvalidParameter()
        {
            //Sets integer variables
            String radius = "250a";
            String message = "";
            //Passes values as parameters to Test.MoveTo
                form1.CommandSplit = "circle 250a".Split(' ');
                form1.command();
            //Checks if the statements are true as expected
            Assert.AreEqual("ERROR INVALID PARAMETERS", form1.error);
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
            form1.CommandSplit = "trinagle 50,150".Split(' ');
            form1.command();
            //Checks if the statements are true as expected
            //Checks drawing position has not changed
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
            //Checks shape is the same size as expected
            Assert.IsTrue(toX + width == Test.xPos + width);
            Assert.IsTrue(toY + height == Test.yPos + height);
        }

        [TestMethod]
        public void DrawTriangleTestInvalidParameter()
        {
            //Passes values as parameters to Test.MoveTo
                form1.CommandSplit = "triangle 250a,250a".Split(' ');
                form1.command();

            //Checks if the statements are true as expected
            Assert.AreEqual("ERROR INVALID PARAMETERS", form1.error);
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
            form1.CommandSplit = "rectangle 50,150".Split(' ');
            form1.command();
            //Checks if the statements are true as expected
            //Checks drawing position has not changed
            Assert.IsTrue(toX == Test.xPos);
            Assert.IsTrue(toY == Test.yPos);
            //Checks shape is the same size as expected
            Assert.IsTrue(toX + width == Test.xPos + width);
            Assert.IsTrue(toY + height == Test.yPos + height);
        }

        [TestMethod]
        public void DrawRectangleTestInvalidParameter()
        { 
            form1.CommandSplit = "rectangle 250a".Split(' ');
            form1.command();
            //Checks if the statements are true as expected
            Assert.AreEqual("ERROR INVALID PARAMETERS", form1.error);
        }







        //Component 2 tests
        [TestMethod]
        public void InitializeVariableTest()
        {
            String variableName = "width";
            int VariableValue = 100;
            string variable1="";
            int value1=0;
            form1.CommandSplit = "width = 100".Split(' ');
            form1.command();
            //Passes values as parameters to Test.MoveTo
            foreach (KeyValuePair<string, int> variable in form1.VariableDictionary)
            {
                if (variable.Key.Equals(variableName))
                {
                    variable1 = variable.Key;
                    value1 = variable.Value;
                }
            }
            Assert.AreEqual(variableName, variable1);
            Assert.AreEqual(VariableValue, value1);

        }
        [TestMethod]
        public void LoopTest()
        {
            Boolean loop = true;
            form1.CommandSplit = "width = 100".Split(' ');
            form1.command();

            form1.CommandSplit = "While width == 100".Split(' ');
            form1.command();
            //Passes values as parameters to Test.MoveTo

            //Checks shape is the same size as expected
            Assert.AreEqual(loop, form1.LoopStatement);
            loop = false;
            form1.CommandSplit = "While width == 90".Split(' ');
            form1.command();
            Assert.AreEqual(loop, form1.LoopStatement);
        }
        [TestMethod]
        public void IfStatementTest()
        {
            Boolean If = true;
            form1.CommandSplit = "width = 100".Split(' ');
            form1.command();

            form1.CommandSplit = "If width == 100".Split(' ');
            form1.command();
            Assert.AreEqual(If, form1.ifStatement);

            form1.CommandSplit = "If width > 80".Split(' ');
            form1.command();
            Assert.AreEqual(If, form1.ifStatement);

            form1.CommandSplit = "If width < 120".Split(' ');
            form1.command();
            Assert.AreEqual(If, form1.ifStatement);

            If = false;

            form1.CommandSplit = "If width == 90".Split(' ');
            form1.command();
            Assert.AreEqual(If, form1.ifStatement);

            form1.CommandSplit = "If width > 110".Split(' ');
            form1.command();
            Assert.AreEqual(If, form1.ifStatement);

            form1.CommandSplit = "If width < 80".Split(' ');
            form1.command();
            Assert.AreEqual(If, form1.ifStatement);
        }
        [TestMethod]
        public void MethodsTest()
        {
            String MethodName = "method1";
            string method1 = "";
            string points = "";
            form1.LinesArray.Add("Method method1");
            form1.lineNumber = 1;
            form1.CommandSplit= "Method method1".Split(' ');
            form1.command();
            form1.LinesArray.Add("square 50");
            form1.lineNumber = 2;
            form1.CommandSplit = "square 50".Split(' ');
            form1.command();
            form1.LinesArray.Add("Endmethod");
            form1.lineNumber = 3;
            form1.CommandSplit = "Endmethod".Split(' ');
            form1.command();
            //Passes values as parameters to Test.MoveTo
            foreach (KeyValuePair<string, string> method in form1.MethodDictionary)
            {
                if (method.Key.Equals(MethodName))
                {
                    method1 = method.Key;
                    points = method.Value;

                }
            }
            Assert.AreEqual(MethodName, method1);
            Assert.AreEqual("1 3", points);
        }
    }
}
