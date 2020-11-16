using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Assessment1;

namespace Assessment1
{
    class Hexagon : Shape
    {
        //Initialises width and height
        int width;

        public Hexagon() : base()
        {

        }

        /// <summary>
        /// Gets passed the pen colour, drawing position and the width 
        /// Stores the width value in the local variable for width 
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public Hexagon(Color colour, int x, int y, int width) : base(colour, x, y)
        {
            this.width = width;
        }

        /// <summary>
        /// Gets passed the pen colour and a list of integers that includes the drwaing position and the width 
        /// Sets the colour and the drawing position
        ///  Stores the width value in the local variable for width 
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="list"></param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.width = list[2];
        }

        /// <summary>
        /// Draws a hexagon with the pen colour from the drawing position with the width of the local variable
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            Point[] Hexagon = new Point[] { new Point(x, y), new Point(x + width, y), new Point(x + width + width/2, y + width), 
                new Point(x + width, y + width + width), new Point(x, y + width + width), new Point(x - width /2, y + width) };
            g.DrawPolygon(Pen, Hexagon);
        }

        /// <summary>
        /// Draws a filled hexagon with the pen colour from the drawing position with the width of the local variables
        /// </summary>
        /// <param name="g"></param>
        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            Point[] Hexagon = new Point[] { new Point(x, y), new Point(x + width, y), new Point(x + width + width/2, y + width),
                new Point(x + width, y + width + width), new Point(x, y + width + width), new Point(x - width /2, y + width) };
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillPolygon(solidBrush, Hexagon);
        }

        /// <summary>
        /// Calculates the area of the hexagon using the width and height
        /// </summary>
        /// <returns></returns>
        public override double calcArea()
        {
            return 0;
        }

        /// <summary>
        /// Calculates the hexagon of the triangle
        /// </summary>
        /// <returns></returns>
        public override double calcPerimeter()
        {
            return 0;
        }

        /// <summary>
        /// Returns the string value of the shape
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "  " + this.width;
        }
    }

}
