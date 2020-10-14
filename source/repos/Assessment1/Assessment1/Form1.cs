using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment1
{
    public partial class Form1 : Form
    {
        Bitmap OutputBitMap = new Bitmap(640, 480);
        Canvass MyCanvass;
        Boolean Fill = false;
        public Form1()
        {
            InitializeComponent();
            MyCanvass= new Canvass(Graphics.FromImage(OutputBitMap));
        }

        

       
        private void txtCommandLine_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                String Command = txtCommandLine.Text.Trim().ToLower();
                if (Command.Equals("line") == true)
                {
                    MyCanvass.DrawLine(160, 120);
                    Console.WriteLine("LINE");
                }
                else if (Command.Equals("square") == true)
                {
                    MyCanvass.DrawSquare(25);
                    if (Fill)
                    {
                        MyCanvass.FillSquare(25);
                    }
                    Console.WriteLine("SQUARE");
                }
                else if (Command.Equals("circle") == true)
                {
                    MyCanvass.DrawCircle(5);
                    if (Fill)
                    {
                        MyCanvass.FillCircle(5);
                    }
                    Console.WriteLine("CIRCLE");
                }
                else if (Command.Equals("triangle") == true)
                {
                    MyCanvass.DrawTriangle(25,25,0,25);
                    if (Fill)
                    {
                        MyCanvass.FillTriangle(25,25,0,25);
                    }
                    Console.WriteLine("TRIANGLE");
                }
                else if (Command.Equals("rectangle") == true)
                {
                    MyCanvass.DrawRectangle(25,50);
                    if (Fill)
                    {
                        MyCanvass.FillRectangle(25,50);
                    }
                    Console.WriteLine("SQUARE");
                }
                else if (Command.Equals("clear") == true)
                {
                    MyCanvass.clearArea(OutputWindow.BackColor);
                    Console.WriteLine("CLEAR");
                }
                else if (Command.Equals("reset") == true)
                {
                    MyCanvass.resetPenPosition();
                    Console.WriteLine("RESET PEN");
                }
                else if (Command.Equals("fill on") == true)
                {
                    Fill = true;
                    Console.WriteLine("FILL ON");
                }
                else if (Command.Equals("fill off") == true)
                {
                    Fill=false;
                    
                    Console.WriteLine("FILL OFF");
                }
                else if (Command.Equals("pen red") == true)
                {
                    MyCanvass.PenColour(Color.Red);
                    Console.WriteLine("PEN RED");
                }
                else if (Command.Equals("pen green") == true)
                {
                    MyCanvass.PenColour(Color.Green);
                    Console.WriteLine("PEN GREEN");
                }
                else if (Command.Equals("pen blue") == true)
                {
                    MyCanvass.PenColour(Color.Blue);
                    Console.WriteLine("PEN BLUE");
                }
                else if (Command.Equals("pen yellow") == true)
                {
                    MyCanvass.PenColour(Color.Yellow);
                    Console.WriteLine("PEN YELLOW");
                }
                else if (Command.Equals("pen white") == true)
                {
                    MyCanvass.PenColour(Color.White);
                    Console.WriteLine("PEN WHITE");
                }
                txtCommandLine.Text = "";
                Refresh();
            }
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitMap, 0, 0);
        }
    }
}
