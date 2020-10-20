using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Assessment1
{
    public partial class Form1 : Form
    {
        //Initialises bitmap with set size
        Bitmap OutputBitMap = new Bitmap(871, 548);
        //Makes an instance of the Canvass class
        Canvass MyCanvass;
        public String[] CommandSplit;
        public String[] CommandSplit1;
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
                CommandSplit1 = Command.Split(' ');
                //Checks if the first value in the array is a valid command
                if (CommandSplit1[0].Equals("run") == true)
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
                else if (CommandSplit1[0].Equals("save") == true)
                {
                    //Sets folder for file to be saved into
                    string path = @"C:\Users\robbi\source\repos\Assessment1\Assessment1\";
                    //Checks if the folder already exists
                    if (Directory.Exists(path))
                    {
                        //Adds file with the name inputted to the folder
                        File.AppendAllText(path + CommandSplit1[1], txtInput.Text);
                    }

                    else
                    {
                        //Creates the folder set above
                        Directory.CreateDirectory(path);
                        // Adds file with the name inputted to the folder
                        File.AppendAllText(path + CommandSplit1[1], txtInput.Text);
                    }
                }
                else if (CommandSplit1[0].Equals("load") == true)
                {
                    //Sets target file to load in
                    string path = @"C:\Users\robbi\source\repos\Assessment1\Assessment1\";
                    //Gets all the text from the file
                    string text = System.IO.File.ReadAllText(path + CommandSplit1[1]);
                    //Clears input box
                    txtInput.Clear();
                    //Fills input box with text from the file
                    txtInput.AppendText(text);
                }
                else
                //This means that they aren't using the input box so will only look for commands from  the command line
                {
                    CommandSplit = Command.Split(' ');
                    //Calls command method
                    command();
                }

            }
        }

        private void command()
        {
            txtCommandLine.Clear();
            Refresh();
            //Checks for valid commands
            if (CommandSplit[0].Equals("move") == true)
            {
                if (CommandSplit[1].Equals("to") == true)
                {
                    //Recieves two inputs and stores as integers
                    try
                    {
                        int x = int.Parse(CommandSplit[2]);
                        int y = int.Parse(CommandSplit[3]);
                        MyCanvass.MoveTo(x, y);
                    }
                    catch
                    {
                        validParameter(false);
                        //throw new IOException("Inputs are invalid");
                    }

                    //Passes the values as parameters to MyCanvass.MoveTo 

                    //Writes message to console
                    Console.WriteLine("MOVE TO");
                }
            }
            else if (CommandSplit[0].Equals("draw") == true)
            {
                if (CommandSplit[1].Equals("to") == true)
                {
                    //Recieves two inputs and stores as integers
                    try
                    {
                        int x = int.Parse(CommandSplit[2]);
                        int y = int.Parse(CommandSplit[3]);
                        //Passes the values as parameters to MyCanvass.DrawTo
                        MyCanvass.DrawTo(x, y);
                    }
                    catch
                    {
                        validParameter(false);
                        //throw new IOException("Inputs are invalid");

                    }
                    //Writes to console
                    Console.WriteLine("PEN DRAW");
                }
            }
            else if (CommandSplit[0].Equals("square") == true)
            {
                //Recieves input and strores as an integer
                try
                {
                    int length = int.Parse(CommandSplit[1]);
                    //Passes the value as a parameter to MyCanvass.DrawSquare
                    MyCanvass.DrawSquare(length);
                }
                catch
                {
                    validParameter(false);
                    //throw new IOException("Inputs are invalid");
                }

                //Writes to console
                Console.WriteLine("SQUARE");
            }
            else if (CommandSplit[0].Equals("circle") == true)
            {
                //Recieves input and strores as an integer
                try
                {
                    int radius = int.Parse(CommandSplit[1]);
                    //Passes the value as a parameter to MyCanvass.DrawCircle
                    MyCanvass.DrawCircle(radius);
                }
                catch
                {
                    validParameter(false);
                    //throw new IOException("Inputs are invalid");
                }

                //Writes to console
                Console.WriteLine("CIRCLE");
            }
            else if (CommandSplit[0].Equals("triangle") == true)
            {
                //Recieves two inputs and stores as integers
                try
                {
                    int width = int.Parse(CommandSplit[1]);
                    int height = int.Parse(CommandSplit[2]);
                    //Passes the values as parameters to MyCanvass.DrawTriangle
                    MyCanvass.DrawTriangle(width, height);
                }
                catch
                {
                    validParameter(false);
                    //throw new IOException("Inputs are invalid");
                }
                //Writes to console
                Console.WriteLine("TRIANGLE");
            }
            else if (CommandSplit[0].Equals("rectangle") == true)
            {
                //Recieves two inputs and stores as integers
                try
                {
                    int width = int.Parse(CommandSplit[1]);
                    int height = int.Parse(CommandSplit[2]);
                    //Passes the values as parameters to MyCanvass.DrawRectangle
                    MyCanvass.DrawRectangle(width, height);
                }
                catch
                {
                    validParameter(false);
                    //throw new IOException("Inputs are invalid");
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
                    MyCanvass.FillShape(true);
                    //Writes to console
                    Console.WriteLine("FILL ON");
                }

                else if (CommandSplit[1].Equals("off") == true)
                {
                    //Turns fill off by making boolean Fill false
                    MyCanvass.FillShape(false);
                    //Writes to console
                    Console.WriteLine("FILL OFF");
                }
                else
                {
                    validParameter(false);
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
                else
                {
                    validParameter(false);
                }
            }
            else
            {
                txtCommandLine.Text = "ERROR INVALID COMMAND";
                Refresh();
            }
            Refresh();

        }
    
        private void validParameter(Boolean valid)
        {
            if (valid.Equals(false))
                {
                txtCommandLine.Text = "ERROR INVALID PARAMETERS";
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