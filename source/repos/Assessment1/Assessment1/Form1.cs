using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        String[] CommandSplit;
        public Form1()
        {
            InitializeComponent();
            MyCanvass = new Canvass(Graphics.FromImage(OutputBitMap));
        }




        private void txtCommandLine_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                String Command = txtCommandLine.Text.Trim().ToLower();
                CommandSplit = Command.Split(' ');

                if (CommandSplit[0].Equals("run") == true)
                {
                    using (StringReader reader = new StringReader(txtInput.Text))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            CommandSplit = line.Split(' ');
                            command();
                        }
                    }
                    Refresh();
                }
                else if (CommandSplit[0].Equals("save") == true)
                {
                    CommandSplit = Command.Split(' ');
                    string path = @"C:\Users\robbi\source\repos\Assessment1\Assessment1\";

                    if (Directory.Exists(path))
                    {
                        File.AppendAllText(path + CommandSplit[1], txtInput.Text);
                    }

                    else
                    {
                        Directory.CreateDirectory(path);
                        File.AppendAllText(path + CommandSplit[1], "The first line");
                    }




                }
                else if (CommandSplit[0].Equals("load") == true)
                {
                    string path = @"C:\Users\robbi\source\repos\Assessment1\Assessment1\";
                    string text = System.IO.File.ReadAllText(path + CommandSplit[1]);
                    txtInput.Clear();
                    txtInput.AppendText(text);
                }
                else
                {
                    CommandSplit = Command.Split(' ');
                    command();
                }
                txtCommandLine.Text = "";
                Refresh();
            }
        }

        private void command()
        {
            if (CommandSplit[0].Equals("position") == true)
            {
                if (CommandSplit[1].Equals("pen") == true)
                {
                    int x = int.Parse(CommandSplit[2]);
                    int y = int.Parse(CommandSplit[3]);
                    MyCanvass.MoveTo(x, y);
                    Console.WriteLine("POSITION PEN");
                }
            }

            else if (CommandSplit[0].Equals("square") == true)
            {
                int length = int.Parse(CommandSplit[1]);
                MyCanvass.DrawSquare(length);
                if (Fill)
                {
                    MyCanvass.FillSquare(length);
                }
                Console.WriteLine("SQUARE");
            }
            else if (CommandSplit[0].Equals("circle") == true)
            {
                int radius = int.Parse(CommandSplit[1]);
                MyCanvass.DrawCircle(radius);
                if (Fill)
                {
                    MyCanvass.FillCircle(radius);
                }
                Console.WriteLine("CIRCLE");
            }
            else if (CommandSplit[0].Equals("triangle") == true)
            {
                int width = int.Parse(CommandSplit[1]);
                int height = int.Parse(CommandSplit[2]);
                MyCanvass.DrawTriangle(width, height);
                if (Fill)
                {

                    MyCanvass.FillTriangle(width, height);
                }
                Console.WriteLine("TRIANGLE");
            }
            else if (CommandSplit[0].Equals("rectangle") == true)
            {
                int width = int.Parse(CommandSplit[1]);
                int height = int.Parse(CommandSplit[2]);
                MyCanvass.DrawRectangle(width, height);
                if (Fill)
                {
                    MyCanvass.FillRectangle(width, height);
                }
                Console.WriteLine("SQUARE");
            }
            else if (CommandSplit[0].Equals("clear") == true)
            {
                MyCanvass.clearArea(OutputWindow.BackColor);
                Console.WriteLine("CLEAR");
            }
            else if (CommandSplit[0].Equals("reset") == true)
            {
                MyCanvass.resetPenPosition();
                Console.WriteLine("RESET PEN");
            }
            else if (CommandSplit[0].Equals("fill") == true)
            {
                if (CommandSplit[1].Equals("on") == true)
                {
                    Fill = true;
                    Console.WriteLine("FILL ON");
                }

                else if (CommandSplit[1].Equals("off") == true)
                {
                    Fill = false;
                    Console.WriteLine("FILL OFF");
                }
            }
            else if (CommandSplit[0].Equals("pen") == true)
            {
                if (CommandSplit[1].Equals("red") == true)
                {
                    MyCanvass.PenColour(Color.Red);
                    Console.WriteLine("PEN RED");
                }
                else if (CommandSplit[1].Equals("green") == true)
                {
                    MyCanvass.PenColour(Color.Green);
                    Console.WriteLine("PEN GREEN");
                }
                else if (CommandSplit[1].Equals("blue") == true)
                {
                    MyCanvass.PenColour(Color.Blue);
                    Console.WriteLine("PEN BLUE");
                }
                else if (CommandSplit[1].Equals("yellow") == true)
                {
                    MyCanvass.PenColour(Color.Yellow);
                    Console.WriteLine("PEN YELLOW");
                }
                else if (CommandSplit[1].Equals("white") == true)
                {
                    MyCanvass.PenColour(Color.White);
                    Console.WriteLine("PEN WHITE");
                }
                else if (CommandSplit[1].Equals("draw") == true)
                {
                    int x = int.Parse(CommandSplit[2]);
                    int y = int.Parse(CommandSplit[3]);
                    MyCanvass.DrawTo(x, y);
                    Console.WriteLine("PEN DRAW");
                }
            }
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitMap, 0, 0);
        }


    }
}