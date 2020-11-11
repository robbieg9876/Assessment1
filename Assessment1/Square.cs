using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Assessment1;

namespace Assessment1
{
    class Square : Shape
    {
        int width;

        public Square() : base()
        {

        }

        public Square(Color colour, int x, int y, int width) : base(colour, x, y)
        {
            this.width = width;
        }

        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.width = list[2];
        }

        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            g.DrawRectangle(Pen, x, y, width, width);
        }
        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            //Fills the square with the current pen colour
            //Fills the circle with the current pen colour
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillRectangle(solidBrush, x, y, width , width);
        }
        public override double calcArea()
        {
            return width * width;
        }

        public override double calcPerimeter()
        {
            return 4 * width;
        }
        public override string ToString()
        {
            return base.ToString() + "  " + this.width;
        }
    }

}
