using System;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Assessment1
{
    public class Canvass
    { 
        //Initialises graphics variables
        public  Graphics g;
        public Pen Pen;
        public int xPos, yPos;
        public SolidBrush solidBrush;
        public int Fill=0;
        public string CurrentVariableName;
        public int CurrentVariableValue;
        public int StartLine;
        public int EndLine;
        public string CurrentMethodName;
        public string[] CurrentParameters  = new string[100];
        /// <summary>
        /// Initialises the graphics variables 
        /// Sets the starting drawing position and the pen colour
        /// </summary>
        /// <param name="g"></param>
        public Canvass(Graphics g)
        {
            //Sets initial values for graphics
            this.g = g;
            xPos = yPos = 0;
            Pen = new Pen(Color.White, 1);
        }

        public Canvass()
        {
        }

        /// <summary>
        /// Takes in the parameters inputted and moves the drawing position to those values
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void MoveTo(int toX, int toY)
        {
            //Moves the drawing start point to the values inputted
            xPos = toX;
            yPos = toY;
              
        }

        /// <summary>
        /// Draws a line from the current drawing position to the point inputted
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void DrawTo(int toX, int toY)
        {
            // Draws a line from the current position to the inputted co-ordinates
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            //Changes current drawing position to where the line finishes
            xPos = toX;
            yPos = toY;
        }
        /// <summary>
        /// Changes the pen colour to the one inputted
        /// </summary>
        /// <param name="colour"></param>
        public void PenColour(Color colour)
        {
            //Changes the pen colour to the one inputted
            Pen.Color = colour;
        }
        /// <summary>
        /// Clears the  outbox with the colour of the background
        /// </summary>
        /// <param name="colour"></param>
        public void clearArea(Color colour)
        {
            //Clears drawing surface and sets background colour
            g.Clear(colour);
        }

        /// <summary>
        /// Resets the drawing position back to the original position
        /// </summary>
        public void resetPenPosition()
        {
            //Resets the start drawing position to (0,0) (top left)
            xPos = yPos = 0;
        }

        /// <summary>
        /// Takes in a boolean value for whether the shapes should be filled
        /// Changes the value of int Fill accordingly, so that they can be checked when a shape is being drawn
        /// </summary>
        /// <param name="fill"></param>
        public void FillShape(bool fill)
        {
            if (fill)
            {
                Fill = 1;
            }
            else
            {
                Fill = 0;
            }
        }
    }
}

