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
        //Initialises width
        int width;

        public Square() : base()
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
        public Square(Color colour, int x, int y, int width) : base(colour, x, y)
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
        /// Draws a square with the pen colour from the drawing position with the width of the local variable
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            g.DrawRectangle(Pen, x, y, width, width);
        }

        /// <summary>
        /// Draws a filled square with the pen colour from the drawing position with the width of the local variable
        /// </summary>
        /// <param name="g"></param>
        public override void fill(Graphics g)
        {
            Pen Pen = new Pen(colour, 1);
            //Fills the square with the current pen colour
            //Fills the circle with the current pen colour
            SolidBrush solidBrush = new SolidBrush(Pen.Color);
            g.FillRectangle(solidBrush, x, y, width , width);
        }
        /// <summary>
        /// Calculates the area of the square using the width
        /// </summary>
        /// <returns></returns>
        public override double calcArea()
        {
            return width * width;
        }

        /// <summary>
        /// Calculates the perimeter of the square
        /// </summary>
        /// <returns></returns>
        public override double calcPerimeter()
        {
            return 4 * width;
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
