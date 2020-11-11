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

        public void MoveTo(int toX, int toY)
        {
            //Moves the drawing start point to the values inputted
            xPos = toX;
            yPos = toY;
              
        }

        public void DrawTo(int toX, int toY)
        {
            // Draws a line from the current position to the inputted co-ordinates
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            //Changes current drawing position to where the line finishes
            xPos = toX;
            yPos = toY;
        }
        public void PenColour(Color colour)
        {
            //Changes the pen colour to the one inputted
            Pen.Color = colour;
        }
        public void clearArea(Color colour)
        {
            //Clears drawing surface and sets background colour
            g.Clear(colour);
        }
        public void resetPenPosition()
        {
            //Resets the start drawing position to (0,0) (top left)
            xPos = yPos = 0;
        }

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

        public void InitaliseVariable(string variableName, int value)
        {
            CurrentVariableName = variableName;
            CurrentVariableValue = value;
        }

        public void IfStatement(int startLine, int endLine)
        {
            StartLine = startLine;
            EndLine = endLine;
        }

        public void Loop(int startLine, int endLine)
        {
            StartLine = startLine;
            EndLine = endLine;
        }

        public void Methods(string methodName, string[] parameters)
        {
            CurrentMethodName = methodName;
            foreach (string parameter in parameters){
                CurrentParameters.Append(parameter);
            }
        }
    }
}

