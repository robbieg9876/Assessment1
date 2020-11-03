using System;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Assessment1
{
    public class Canvass
    { 
        //Initialises graphics variables
        public  Graphics g;
        public Pen Pen;
        public int xPos, yPos;
        public SolidBrush solidBrush;
        public Boolean Fill;
        public string CurrentVariableName;
        public int CurrentVariableValue;
        public int StartLine;
        public int EndLine;
        public string CurrentMethodName;
        public string[] CurrentParameters  = new string[100];

        public Canvass(Graphics g)
        {
            //Sets initial values for graphics
            this.g = g;
            xPos = yPos = 0;
            Pen = new Pen(Color.White, 1);
        }

        public Canvass()
        {
        }

        public void MoveTo(int toX, int toY)
        {
            //Moves the drawing start point to the values inputted
            xPos = toX;
            yPos = toY;
              
        }

        public void DrawTo(int toX, int toY)
        {
            // Draws a line from the current position to the inputted co-ordinates
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            //Changes current drawing position to where the line finishes
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int width)
        {

            //Draws a square from the current drawing postion with sides of the width inputted
            if (Fill)
            {
                //Fills the square with the current pen colour
                SolidBrush solidBrush = new SolidBrush(Pen.Color);
                g.FillRectangle(solidBrush, xPos, yPos,width,width);
            }
            else
            {
                g.DrawRectangle(Pen, xPos, yPos,width,width);
            }
                
        }
        public void DrawCircle(int radius)
        {
            //Draws a circle with the radius inputted
            if (Fill)
            {
                //Fills the square with the current pen colour
                //Fills the circle with the current pen colour
                SolidBrush solidBrush = new SolidBrush(Pen.Color);
                g.FillEllipse(solidBrush, xPos, yPos, radius + radius, radius + radius);
            }
            else
            {
                g.DrawEllipse(Pen, xPos, yPos, radius + radius, radius + radius);
            }
            
        }
        public void DrawTriangle(int width, int height)
        {
            //Creates an array with 3 points
            //User inputs the width and height
            // 3 Points are starting point, horizantally from start point, vertically from start point
            Point[] Triangle = new Point[] { new Point(xPos, yPos), new Point(xPos + width, yPos), new Point(xPos, yPos + height) };
            if (Fill)
            {
                //Fills the triangle with the current pen colour
                SolidBrush solidBrush = new SolidBrush(Pen.Color);
                g.FillPolygon(solidBrush, Triangle);
            }
            else
            {
                //Draws lines bewtween the points to make a triangle
                g.DrawPolygon(Pen, Triangle);
            }
            
            
        }

        public void DrawRectangle(int width, int height)
        {
            //Draws a rectangle from the start drawing point with width and height values inputted
            if (Fill)
            {
                //Fills the rectangle with the current pen colour
                SolidBrush solidBrush = new SolidBrush(Pen.Color);
                g.FillRectangle(solidBrush, xPos, yPos, width, height);
            }
            else
            {
                g.DrawRectangle(Pen, xPos, yPos, width, height);
            }
            
        }
        public void PenColour(Color colour)
        {
            //Changes the pen colour to the one inputted
            Pen.Color = colour;
        }
        public void clearArea(Color colour)
        {
            //Clears drawing surface and sets background colour
            g.Clear(colour);
        }
        public void resetPenPosition()
        {
            //Resets the start drawing position to (0,0) (top left)
            xPos = yPos = 0;
        }

        public void FillShape(bool fill)
        {
            if (fill)
            {
                Fill = true;
            }
            else
            {
                Fill = false;
            }
        }

        public void InitaliseVariable(string variableName, int value)
        {
            CurrentVariableName = variableName;
            CurrentVariableValue = value;
        }

        public void IfStatement(int startLine, int endLine)
        {
            StartLine = startLine;
            EndLine = endLine;
        }

        public void Loop(int startLine, int endLine)
        {
            StartLine = startLine;
            EndLine = endLine;
        }

        public void Methods(string methodName, string[] parameters)
        {
            CurrentMethodName = methodName;
            foreach (string parameter in parameters){
                CurrentParameters.Append(parameter);
            }
        }
    }
}

