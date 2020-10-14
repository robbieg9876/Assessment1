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
        public void DrawCircle(Rectangle radius)
        {
            g.DrawEllipse(Pen,radius);
        }
        public void DrawTriangle(double toX, double toY, int toX2, int toY2)
        {
            //g.DrawLines(Pen, point1);
        }

        public void PenColour(Color colour)
        {
            Pen.Color = colour;
        }

        public void shapeFill(Brush  brush, float x, float y, float width, float height)
        {
            g.FillRectangle(brush,x,y,width,height);
        }

        public void shapeUnFill(Brush brush, float x, float y, float width, float height)
        {
            
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
