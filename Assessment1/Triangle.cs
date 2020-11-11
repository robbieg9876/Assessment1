using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Assessment1;

namespace Assessment1
{
    class Triangle : Shape
    {
        int width;
        int height;

        public Triangle() : base()
        {

        }

        public Triangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }

        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            Point[] Triangle = new Point[] { new Point(x, y), new Point(x + width, y), new Point(x, y + height) };
            g.DrawPolygon(Pen, Triangle);
        }

        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            Point[] Triangle = new Point[] { new Point(x, y), new Point(x + width, y), new Point(x, y + height) };
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillPolygon(solidBrush, Triangle);
        }
        public override double calcArea()
        {
            return width * height;
        }

        public override double calcPerimeter()
        {
            return 2 * width + 2 * height;
        }
        public override string ToString()
        {
            return base.ToString() + "  " + this.width + "  " + this.height;
        }
    }

}
