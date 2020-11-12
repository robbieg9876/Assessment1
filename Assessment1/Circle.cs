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
        //Initialises radius
        int radius;

        public Circle():base()
        {

        }

        /// <summary>
        /// Gets passed the pen colour, drawing position and the radius
        /// Stores the radius value in the local variable for radius 
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param
        public Circle(int Fill, Color colour, int x,int y, int radius) : base(colour,x,y)
        {
            this.radius = radius;

        }

        /// <summary>
        /// Gets passed the pen colour and a list of integers that includes the drwaing position and the radius
        /// Sets the colour and the drawing position
        ///  Stores the radius value in the local variable for radius 
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="list"></param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0],list[1]);
            this.radius = list[2];
        }

        /// <summary>
        /// Draws a circle with the pen colour from the drawing position with the radius of the local variable
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            g.DrawEllipse(Pen, x, y, radius + radius, radius + radius);
        }

        /// <summary>
        /// Draws a filled circle with the pen colour from the drawing position with the radius of the local variable
        /// </summary>
        /// <param name="g"></param>
        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            //Fills the square with the current pen colour
                //Fills the circle with the current pen colour
                SolidBrush solidBrush = new SolidBrush(Pen.Color);
                g.FillEllipse(solidBrush, x, y, radius + radius, radius + radius);
        }

        /// <summary>
        /// Calculates the area of the circle using the radius
        /// </summary>
        /// <returns></returns>
        public override double calcArea()
        {
            return Math.PI * (radius ^ 2);
        }

        /// <summary>
        /// Calculates the perimeter of the circle
        /// </summary>
        /// <returns></returns>
        public override double calcPerimeter()
        {
            return 2 * Math.PI * radius;
        }
        /// <summary>
        /// Returns the string value of the shape
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString()+"  "+this.radius;
        }
    }

}
