using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Assessment1
{
    public class Canvass
    {
        Graphics g;
        Pen Pen;
        int xPos, yPos;

        public Canvass(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;
            Pen = new Pen(Color.White, 1);
        }

        public Canvass()
        {
        }

        public void MoveTo(int toX, int toY)
        {
            if (toX < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", toX, "Point is out of range");
            }
           
            if (toY < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", toY, "Point is out of range");
            }
            xPos = toX;
            yPos = toY;
              
        }

        public void DrawTo(int toX, int toY)
        {
            if (toX < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", toX, "Point is out of range");
            }

            if (toY < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", toY, "Point is out of range");
            }
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int width)
        {
            if (xPos+width <0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", xPos+width, "Point is out of range");
            }

            if (xPos +width < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", yPos+width, "Point is out of range");
            }
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + width);
        }
        public void DrawCircle(int radius)
        {
            if (xPos - radius < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", xPos - radius , "Point is out of range");
            }

            if (xPos + radius < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", xPos + radius, "Point is out of range");
            }

            if (yPos - radius < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", yPos - radius, "Point is out of range");
            }

            if (yPos + radius < 0)
            {
                throw new System.ArgumentOutOfRangeException("MoveTo", yPos + radius, "Point is out of range");
            }

            g.DrawEllipse(Pen, xPos - radius, yPos - radius, xPos + radius, yPos + radius);
        }
        public void DrawTriangle(int width, int height)
        {
            Point[] Triangle = new Point[] { new Point(xPos, yPos), new Point(xPos + width, yPos), new Point(xPos, yPos + height) };
            g.DrawPolygon(Pen, Triangle);
        }

        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
        }
        public void PenColour(Color colour)
        {
            Pen.Color = colour;
        }

        public void FillSquare(int width)
        {
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillRectangle(solidBrush, xPos, yPos, xPos + width, yPos + width);
        }

        public void FillCircle(int radius)
        {
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillEllipse(solidBrush, xPos - radius, yPos - radius, xPos + radius, yPos + radius);
        }

        public void FillTriangle(int width, int height)
        {
            Point[] Triangle = new Point[] { new Point(xPos, yPos), new Point(xPos + width, yPos), new Point(xPos, yPos + height) };
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillPolygon(solidBrush, Triangle);
        }

        public void FillRectangle(int width, int height)
        {
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillRectangle(solidBrush, xPos, yPos, xPos + width, yPos + height);
        }

        public void clearArea(Color colour)
        {
            g.Clear(colour);
        }
        public void resetPenPosition()
        {
            xPos = yPos = 0;
        }
    }
}

