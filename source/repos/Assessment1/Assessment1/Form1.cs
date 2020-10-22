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
        public String[] ParameterSplit;
        public String[] ParameterCheck = new string[1];
        public int lineNumber = 0;
        public string ErrorList = "";
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
                txtCommandLine.Clear();
                txtErrors.Clear();
                Refresh();
                //Checks if the first value in the array is a valid command
                if (CommandSplit[0].Equals("run") == true)
                {
                    //This takes all the text in the input box
                    //Splits it into individual lines
                    using (StringReader reader = new StringReader(txtInput.Text))
                    {
                        //Loops through each line in the input box
                        string line;
                        lineNumber = 0;
                        ErrorList="";
                        while ((line = reader.ReadLine()) != null)
                        {
                            //Splits line and stores values in commandSplit Array
                            CommandSplit = line.Split(' ');
                            lineNumber++;
                            //Calls command method
                            command();
                        }
                        //Checks if there are any errors
                        if (ErrorList.Equals(""))
                        {
                            txtErrors.Text = ErrorList;
                            Refresh();
                        }
                        else
                        {
                            //Outputs errors to error textbox
                            txtCommandLine.Clear();
                            Refresh();
                            MyCanvass.clearArea(OutputWindow.BackColor);

                            txtErrors.Text = ErrorList;
                        }
                    }
                    Refresh();
                }
                else if (CommandSplit[0].Equals("save") == true)
                {
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
                    try
                    {
                        string text = System.IO.File.ReadAllText(path + CommandSplit[1]);
                        //Clears input box
                        txtInput.Clear();
                        //Fills input box with text from the file
                        txtInput.AppendText(text);
                    }
                    catch
                    {
                        string error = "ERROR FILE NOT FOUND";
                        txtErrors.Text = error;
                        throw new FileNotFoundException("FILE NOT FOUND");
                    }
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
            //Checks that parameters have been inputted

            try
            {
                //Splits parameters into seperate values and stores in array
                ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
            }
            catch (IndexOutOfRangeException ex1)
            {
                NoParameters();
                return;
            }
            //Checks for valid commands
            if (CommandSplit[0].Equals("moveto") == true)
            {
                //Recieves two inputs and stores as integers
                try
                {
                    //Tries to pass parameters
                    int x = int.Parse(ParameterSplit[0]);
                    int y = int.Parse(ParameterSplit[1]);
                    //Checks if the correct number of parameters have been inputted
                    if (ParameterSplit.Length != 2)
                    {
                        ParameterCheck[2] = ParameterSplit[2];
                     }
                    else
                    {
                        MyCanvass.MoveTo(x, y);
                     }
                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
                }

                //Passes the values as parameters to MyCanvass.MoveTo 

                //Writes message to console
                Console.WriteLine("MOVE TO");
            }
            else if (CommandSplit[0].Equals("drawto") == true)
            {
                //Recieves two inputs and stores as integers
                try
                {
                    //Checks if the correct number of paramters have been passed
                    int x = int.Parse(ParameterSplit[0]);
                    int y = int.Parse(ParameterSplit[1]);
                    if (ParameterSplit.Length != 2)
                    {
                        ParameterCheck[2] = ParameterSplit[2];
                    }
                    else
                    {
                        //Passes the values as parameters to MyCanvass.DrawTo
                        MyCanvass.DrawTo(x, y);
                    }
                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
                }
                //Writes to console
                Console.WriteLine("DRAW TO");
            }
            else if (CommandSplit[0].Equals("square") == true)
            {
                //Recieves input and strores as an integer
                try
                {
                    //Checks if the correct number of paramters have been passed
                    int length = int.Parse(ParameterSplit[0]);
                    if (ParameterSplit.Length != 1)
                    {
                        ParameterCheck[1] = ParameterSplit[1];
                    }
                    else
                    {
                        //Passes the value as a parameter to MyCanvass.DrawSquare
                        MyCanvass.DrawSquare(length);
                    }

                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
                }

                //Writes to console
                Console.WriteLine("SQUARE");
            }
            else if (CommandSplit[0].Equals("circle") == true)
            {
                //Recieves input and strores as an integer
                try
                {
                    //Checks if the correct number of paramters have been passed
                    int radius = int.Parse(ParameterSplit[0]);
                    if (ParameterSplit.Length != 1)
                    {
                        ParameterCheck[2] = ParameterSplit[2];
                    }
                    else
                    {
                        //Passes the value as a parameter to MyCanvass.DrawCircle
                        MyCanvass.DrawCircle(radius);
                    }
                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
                }

                //Writes to console
                Console.WriteLine("CIRCLE");
            }
            else if (CommandSplit[0].Equals("triangle") == true)
            {
                //Recieves two inputs and stores as integers
                try
                {
                        int width = int.Parse(ParameterSplit[0]);
                        int height = int.Parse(ParameterSplit[1]);
                    //Checks if the correct number of paramters have been passed
                    if (ParameterSplit.Length != 2)
                    {
                        ParameterCheck[2] = ParameterSplit[2];
                    }
                    else
                    {
                        //Passes the values as parameters to MyCanvass.DrawTriangle
                        MyCanvass.DrawTriangle(width, height);
                    }
                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
                }
                //Writes to console
                Console.WriteLine("TRIANGLE");
            }
            else if (CommandSplit[0].Equals("rectangle") == true)
            {
                //Recieves two inputs and stores as integers
                try
                {
                    //Checks if the correct number of paramters have been passed
                        int width = int.Parse(ParameterSplit[0]);
                        int height = int.Parse(ParameterSplit[1]);
                    if (ParameterSplit.Length != 2)
                    {
                        ParameterCheck[2] = ParameterSplit[2];
                    }
                    else
                    {
                        //Passes the values as parameters to MyCanvass.DrawRectangle
                        MyCanvass.DrawRectangle(width, height);
                    }
                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
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
                try
                {
                    //Checks if the correct number of paramters have been passed
                    String check = ParameterSplit[0];
                    if (ParameterSplit.Length != 1)
                    {
                        ParameterCheck[2] = ParameterSplit[2];
                    }
                    else
                    {
                        if (check.Equals("on"))
                        {
                            //Turns fill on by making boolean Fill true
                            MyCanvass.FillShape(true);
                            //Writes to console
                            Console.WriteLine("FILL ON");
                        }
                        else if (check.Equals("off") == true)
                        {
                            //Turns fill off by making boolean Fill false
                            MyCanvass.FillShape(false);
                            //Writes to console
                            Console.WriteLine("FILL OFF");
                        }
                        else
                        {
                            InvalidParameter();
                        }
                    }
                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
                }

            }
            else if (CommandSplit[0].Equals("pen"))
            {
                try
                {
                    //Checks if the correct number of paramters have been passed
                    String Check = ParameterSplit[0];
                    if (ParameterSplit.Length != 1)
                    {
                        ParameterCheck[2] = ParameterSplit[2];
                    }
                    else
                    {
                        if (ParameterSplit[0].Equals("red") == true)
                        {
                            //Passes the colour inputted as a parameter to MyCanvass.PenColour
                            MyCanvass.PenColour(Color.Red);
                            //Writes to console
                            Console.WriteLine("RED");
                        }
                        else if (ParameterSplit[0].Equals("green") == true)
                        {
                            //Passes the colour inputted as a parameter to MyCanvass.PenColour
                            MyCanvass.PenColour(Color.Green);
                            //Writes to console
                            Console.WriteLine("GREEN");
                        }
                        else if (ParameterSplit[0].Equals("blue") == true)
                        {
                            //Passes the colour inputted as a parameter to MyCanvass.PenColour
                            MyCanvass.PenColour(Color.Blue);
                            //Writes to console
                            Console.WriteLine("BLUE");
                        }
                        else if (ParameterSplit[0].Equals("yellow") == true)
                        {
                            //Passes the colour inputted as a parameter to MyCanvass.PenColour
                            MyCanvass.PenColour(Color.Yellow);
                            //Writes to console
                            Console.WriteLine("YELLOW");
                        }
                        else if (ParameterSplit[0].Equals("white") == true)
                        {
                            //Passes the colour inputted as a parameter to MyCanvass.PenColour
                            MyCanvass.PenColour(Color.White);
                            //Writes to console
                            Console.WriteLine("WHITE");
                        }
                        else
                        {
                            InvalidParameter();
                        }
                    }
                }
                catch (FormatException ex)
                {
                    InvalidParameter();
                    return;
                }
                catch (NullReferenceException ex1)
                {
                    NoParameters();
                    return;
                }
                catch (IndexOutOfRangeException ex1)
                {
                    IncorrectNumberOfParameters();
                    return;
                }
        }
            else
            {
                InvalidCommand();    
            }
            Refresh();

        }
        private void InvalidCommand()
        {
            string error = "ERROR INVALID COMMAND";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }
        private void InvalidParameter()
        {
            string error = "ERROR INVALID PARAMETERS";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }
        private void NoParameters()
        {
            string error = "ERROR NO PARAMETERS";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }

        private void IncorrectNumberOfParameters()
        {
            string error = "ERROR INCORRECT NUMBER OF PARAMETERS";
            txtErrors.Text = error ;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
            
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            //Initialises the graphics on the output window
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitMap, 0, 0);
        }


    }
}