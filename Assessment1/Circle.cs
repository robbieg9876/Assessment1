using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Assessment1;

namespace Assessment1
{
    class Circle : Shape
    {
        int radius;

        public Circle():base()
        {

        }

        public Circle(int Fill, Color colour, int x,int y, int radius) : base(colour,x,y)
        {
            this.radius = radius;

        }

        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0],list[1]);
            this.radius = list[2];
        }

        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            g.DrawEllipse(Pen, x, y, radius + radius, radius + radius);
        }
        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            //Fills the square with the current pen colour
                //Fills the circle with the current pen colour
                SolidBrush solidBrush = new SolidBrush(Pen.Color);
                g.FillEllipse(solidBrush, x, y, radius + radius, radius + radius);
        }
        public override double calcArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double calcPerimeter()
        {
            return 2 * Math.PI * radius;
        }
        public override string ToString()
        {
            return base.ToString()+"  "+this.radius;
        }
    }

}
