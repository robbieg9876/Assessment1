using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Assessment1;

namespace Assessment1
{
    class Arc : Shape
    {
        //Initialises radius
        int width;
        int height;

        public Arc() : base()
        {

        }

        /// <summary>
        /// Gets passed the pen colour, drawing position and the width and height
        /// Stores the width and height values in the local variable for radius 
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param
        public Arc(int Fill, Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;

        }

        /// <summary>
        /// Gets passed the pen colour and a list of integers that includes the drwaing position and the width and height
        /// Sets the colour and the drawing position
        ///  Stores the radius value in the local variable for radius 
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
        /// Draws a arc with the pen colour from the drawing position with the width and height of the local variables
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            g.DrawArc(Pen, x, y, width, height, 0, 180);
        }

        /// <summary>
        /// Draws a filled arc with the pen colour from the drawing position with the width and height of the local variables
        /// </summary>
        /// <param name="g"></param>
        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            g.DrawArc(Pen, x, y, width, height, 0, 180);
        }

        /// <summary>
        /// Calculates the area of the arc using the radius
        /// </summary>
        /// <returns>area</returns>
        public override double calcArea()
        {
            return 0;
        }

        /// <summary>
        /// Calculates the perimeter of the arc
        /// </summary>
        /// <returns>perimeter</returns>
        public override double calcPerimeter()
        {
            return 0;
        }
        /// <summary>
        /// Returns the string value of the shape
        /// </summary>
        /// <returns>as string</returns>
        public override string ToString()
        {
            return base.ToString() + "  " + this.width+" "+this.height;
        }
    }

}
