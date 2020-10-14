using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Assessment1
{
    class Canvass
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

        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int width)
        {
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + width);
        }
        public void DrawCircle(int radius)
        {
            g.DrawEllipse(Pen, xPos - radius, yPos - radius, xPos + radius , yPos+radius);
        }
        public void DrawTriangle(int toX, int toY, int toX2, int toY2)
        {
            Point[] Triangle = new Point[] { new Point(xPos, yPos), new Point(toX, toY), new Point(toX2, toY2) };
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

        public void FillSquare( int width)
        {
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillRectangle(solidBrush,xPos, yPos, xPos + width, yPos + width);
        }

        public void FillCircle(int radius)
        {
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillEllipse(solidBrush, xPos - radius, yPos - radius, xPos + radius, yPos + radius);
        }

        public void FillTriangle(int toX, int toY, int toX2, int toY2)
        {
            Point[] Triangle = new Point[] { new Point(xPos, yPos), new Point(toX, toY), new Point(toX2, toY2) };
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
