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
        //Initialises bitmap with set size
        Bitmap OutputBitMap = new Bitmap(640, 480);
        //Makes an instance of the Canvass class
        Canvass MyCanvass;
        //Initialises variables
        Boolean Fill = false;
        String[] CommandSplit;
        public Form1()
        {
            //Sets graphics up on bitmap
            InitializeComponent();
            MyCanvass = new Canvass(Graphics.FromImage(OutputBitMap));
        }




        private void txtCommandLine_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            //Checks if enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                //Stores the input in a string
                //Removes whitespace and converts letters to lower case
                String Command = txtCommandLine.Text.Trim().ToLower();
                //Splits the string and stores values in commandSplit Array
                CommandSplit = Command.Split(' ');

                //Checks if the first value in the array is a valid command
                if (CommandSplit[0].Equals("run") == true)
                {
                    //This takes all the text in the input box
                    //Splits it into individual lines
                    using (StringReader reader = new StringReader(txtInput.Text))
                    {
                        //Loops through each line in the input box
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            //Splits line and stores values in commandSplit Array
                            CommandSplit = line.Split(' ');
                            //Calls command method
                            command();
                        }
                    }
                    Refresh();
                }
                else if (CommandSplit[0].Equals("save") == true)
                {
                    //splits string and stores values in commandSplit Array
                    CommandSplit = Command.Split(' ');
                    //Sets folder for file to be saved into
                    string path = @"C:\Users\robbi\source\repos\Assessment1\Assessment1\";
                    //Checks if the folder already exists
                    if (Directory.Exists(path))
                    {
                        //Adds file with the name inputted to the folder
                        File.AppendAllText(path + CommandSplit[1], txtInput.Text);
                    }

                    else
                    {
                        //Creates the folder set above
                        Directory.CreateDirectory(path);
                        // Adds file with the name inputted to the folder
                        File.AppendAllText(path + CommandSplit[1], txtInput.Text);
                    }




                }
                else if (CommandSplit[0].Equals("load") == true)
                {
                    //Sets target file to load in
                    string path = @"C:\Users\robbi\source\repos\Assessment1\Assessment1\";
                    //Gets all the text from the file
                    string text = System.IO.File.ReadAllText(path + CommandSplit[1]);
                    //Clears input box
                    txtInput.Clear();
                    //Fills input box with text from the file
                    txtInput.AppendText(text);
                }
                else
                //This means that they aren't using the input box so will only look for commands from  the command line
                {
                    //Splits strings and stores values in CommandSplit array
                    CommandSplit = Command.Split(' ');
                    //Calls command method
                    command();
                }
                //Clears command line
                txtCommandLine.Text = "";
                Refresh();
            }
        }

        private void command()
        {
            //Checks for valid commands
            if (CommandSplit[0].Equals("position") == true)
            {
                if (CommandSplit[1].Equals("pen") == true)
                {
                    //Recieves two inputs and stores as integers
                    int x = int.Parse(CommandSplit[2]);
                    int y = int.Parse(CommandSplit[3]);
                    //Passes the values as parameters to MyCanvass.MoveTo 
                    MyCanvass.MoveTo(x, y);
                    //Writes message to console
                    Console.WriteLine("POSITION PEN");
                }
            }

            else if (CommandSplit[0].Equals("square") == true)
            {
                //Recieves input and strores as an integer
                int length = int.Parse(CommandSplit[1]);
                //Passes the value as a parameter to MyCanvass.DrawSquare
                MyCanvass.DrawSquare(length);
                //Checks if fill is on
                if (Fill)
                {
                    //Fills shape
                    MyCanvass.FillSquare(length);
                }
                //Writes to console
                Console.WriteLine("SQUARE");
            }
            else if (CommandSplit[0].Equals("circle") == true)
            {
                //Recieves input and strores as an integer
                int radius = int.Parse(CommandSplit[1]);
                //Passes the value as a parameter to MyCanvass.DrawCircle
                MyCanvass.DrawCircle(radius);
                //Checks if fill is on
                if (Fill)
                {
                    //Fills shape
                    MyCanvass.FillCircle(radius);
                }
                //Writes to console
                Console.WriteLine("CIRCLE");
            }
            else if (CommandSplit[0].Equals("triangle") == true)
            {
                //Recieves two inputs and stores as integers
                int width = int.Parse(CommandSplit[1]);
                int height = int.Parse(CommandSplit[2]);
                //Passes the values as parameters to MyCanvass.DrawTriangle
                MyCanvass.DrawTriangle(width, height);
                //Checks if fill is on
                if (Fill)
                {
                    //Fills shape
                    MyCanvass.FillTriangle(width, height);
                }
                //Writes to console
                Console.WriteLine("TRIANGLE");
            }
            else if (CommandSplit[0].Equals("rectangle") == true)
            {
                //Recieves two inputs and stores as integers
                int width = int.Parse(CommandSplit[1]);
                int height = int.Parse(CommandSplit[2]);
                //Passes the values as parameters to MyCanvass.DrawRectangle
                MyCanvass.DrawRectangle(width, height);
                //Checks if fill is on
                if (Fill)
                {
                    //Fills shape
                    MyCanvass.FillRectangle(width, height);
                }
                //Writes to console
                Console.WriteLine("SQUARE");
            }
            else if (CommandSplit[0].Equals("clear") == true)
            {
                //Passes the colour of the output window as a parameter to MyCanvass.clearArea
                MyCanvass.clearArea(OutputWindow.BackColor);
                //Writes to console
                Console.WriteLine("CLEAR");
            }
            else if (CommandSplit[0].Equals("reset") == true)
            {
                //Calls MyCanvass,resetPenPosition to put starting drawing position back to (0,0)
                MyCanvass.resetPenPosition();
                //Writes to console
                Console.WriteLine("RESET PEN");
            }
            else if (CommandSplit[0].Equals("fill") == true)
            {
                if (CommandSplit[1].Equals("on") == true)
                {
                    //Turns fill on by making boolean Fill true
                    Fill = true;
                    //Writes to console
                    Console.WriteLine("FILL ON");
                }

                else if (CommandSplit[1].Equals("off") == true)
                {
                    //Turns fill off by making boolean Fill false
                    Fill = false;
                    //Writes to console
                    Console.WriteLine("FILL OFF");
                }
            }
            else if (CommandSplit[0].Equals("pen") == true)
            {
                if (CommandSplit[1].Equals("red") == true)
                {
                    //Passes the colour inputted as a parameter to MyCanvass.PenColour
                    MyCanvass.PenColour(Color.Red);
                    //Writes to console
                    Console.WriteLine("PEN RED");
                }
                else if (CommandSplit[1].Equals("green") == true)
                {
                    //Passes the colour inputted as a parameter to MyCanvass.PenColour
                    MyCanvass.PenColour(Color.Green);
                    //Writes to console
                    Console.WriteLine("PEN GREEN");
                }
                else if (CommandSplit[1].Equals("blue") == true)
                {
                    //Passes the colour inputted as a parameter to MyCanvass.PenColour
                    MyCanvass.PenColour(Color.Blue);
                    //Writes to console
                    Console.WriteLine("PEN BLUE");
                }
                else if (CommandSplit[1].Equals("yellow") == true)
                {
                    //Passes the colour inputted as a parameter to MyCanvass.PenColour
                    MyCanvass.PenColour(Color.Yellow);
                    //Writes to console
                    Console.WriteLine("PEN YELLOW");
                }
                else if (CommandSplit[1].Equals("white") == true)
                {
                    //Passes the colour inputted as a parameter to MyCanvass.PenColour
                    MyCanvass.PenColour(Color.White);
                    //Writes to console
                    Console.WriteLine("PEN WHITE");
                }
                else if (CommandSplit[1].Equals("draw") == true)
                {
                    //Recieves two inputs and stores as integers
                    int x = int.Parse(CommandSplit[2]);
                    int y = int.Parse(CommandSplit[3]);
                    //Passes the values as parameters to MyCanvass.DrawTo
                    MyCanvass.DrawTo(x, y);
                    //Writes to console
                    Console.WriteLine("PEN DRAW");
                }
            }
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            //Initialises the graphics on the output window
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitMap, 0, 0);
        }


    }
}