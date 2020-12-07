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
        //Initialises width and height
        int width;
        int height;

        public Triangle() : base()
        {

        }

        /// <summary>
        /// Gets passed the pen colour, drawing position, the width and the height
        /// Stores the width value in the local variable for width and height 
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        public Triangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets passed the pen colour and a list of integers that includes the drwaing position and the width and height
        /// Sets the colour and the drawing position
        ///  Stores the width value in the local variable for width and height
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="list"></param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }

        /// <summary>
        /// Draws a triangle with the pen colour from the drawing position with the width and height of the local variables
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            Point[] Triangle = new Point[] { new Point(x, y), new Point(x + width, y), new Point(x, y + height) };
            g.DrawPolygon(Pen, Triangle);
        }

        /// <summary>
        /// Draws a filled triangle with the pen colour from the drawing position with the width and height of the local variables
        /// </summary>
        /// <param name="g"></param>
        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            Point[] Triangle = new Point[] { new Point(x, y), new Point(x + width, y), new Point(x, y + height) };
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillPolygon(solidBrush, Triangle);
        }

        /// <summary>
        /// Calculates the area of the triangle using the width and height
        /// </summary>
        /// <returns>area</returns>
        public override double calcArea()
        {
            return width * height/2;
        }

        /// <summary>
        /// Calculates the perimeter of the triangle
        /// </summary>
        /// <returns>perimeter</returns>
        public override double calcPerimeter()
        {
            return width+height+Math.Sqrt(width^2+height^2);
        }

        /// <summary>
        /// Returns the string value of the shape
        /// </summary>
        /// <returns>as string</returns>
        public override string ToString()
        {
            return base.ToString() + "  " + this.width + "  " + this.height;
        }
    }

}
