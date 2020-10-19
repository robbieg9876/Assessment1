using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Assessment1
{
    public class Canvass
    { 
        //Initialises graphics variables
        Graphics g;
        Pen Pen;
        int xPos, yPos;

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
            //checks if inputs are valid
            if (toX < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", toX, "Point is out of range");
            }
           
            if (toY < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", toY, "Point is out of range");
            }
            //Moves the drawing start point to the values inputted
            xPos = toX;
            yPos = toY;
              
        }

        public void DrawTo(int toX, int toY)
        {
            //checks if inputs are valid
            if (toX < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", toX, "Point is out of range");
            }

            if (toY < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", toY, "Point is out of range");
            }
            // Draws a line from the current position to the inputted co-ordinates
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            //Changes current drawing position to where the line finishes
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int width)
        {
            //Checks that the shape will fit on the graphics panel
            if (xPos+width <0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", xPos+width, "Point is out of range");
            }

            if (xPos +width < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", yPos+width, "Point is out of range");
            }
            //Draws a square from the current drawing postion with sides of the width inputted
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + width);
        }
        public void DrawCircle(int radius)
        {
            //Checks that the shape will fit on the graphics panel
            if (xPos - radius < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", xPos - radius , "Point is out of range");
            }

            if (xPos + radius < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", xPos + radius, "Point is out of range");
            }

            if (yPos - radius < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", yPos - radius, "Point is out of range");
            }

            if (yPos + radius < 0)
            {
                //Throws exception if input is invalid
                throw new System.ArgumentOutOfRangeException("MoveTo", yPos + radius, "Point is out of range");
            }
            //Draws a circle with the radius inputted
            g.DrawEllipse(Pen, xPos - radius, yPos - radius, xPos + radius, yPos + radius);
        }
        public void DrawTriangle(int width, int height)
        {
            //Creates an array with 3 points
            //User inputs the width and height
            // 3 Points are starting point, horizantally from start point, vertically from start point
            Point[] Triangle = new Point[] { new Point(xPos, yPos), new Point(xPos + width, yPos), new Point(xPos, yPos + height) };
            //Draws lines bewtween the points to make a triangle
            g.DrawPolygon(Pen, Triangle);
        }

        public void DrawRectangle(int width, int height)
        {
            //Draws a rectangle from the start drawing point with width and height values inputted
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
        }
        public void PenColour(Color colour)
        {
            //Changes the pen colour to the one inputted
            Pen.Color = colour;
        }

        public void FillSquare(int width)
        {
            //Draws a sqaure from the start drawing point with width values inputted
            //Fills the square with the current pen colour
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillRectangle(solidBrush, xPos, yPos, xPos + width, yPos + width);
        }

        public void FillCircle(int radius)
        {
            //Draws a circle with the radius inputted
            //Fills the circle with the current pen colour
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillEllipse(solidBrush, xPos - radius, yPos - radius, xPos + radius, yPos + radius);
        }

        public void FillTriangle(int width, int height)
        {
            //Draws lines bewtween the points to make a triangle
            //Fills the triangle with the current pen colour
            Point[] Triangle = new Point[] { new Point(xPos, yPos), new Point(xPos + width, yPos), new Point(xPos, yPos + height) };
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillPolygon(solidBrush, Triangle);
        }

        public void FillRectangle(int width, int height)
        {
            //Draws a rectangle from the start drawing point with width and height values inputted
            //Fills the rectangle with the current pen colour
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillRectangle(solidBrush, xPos, yPos, xPos + width, yPos + height);
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
    }
}

