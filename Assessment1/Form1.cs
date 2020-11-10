using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        IDictionary<string, int> VariableDictionary = new Dictionary<string, int>();
        public Boolean ifStatement=true;
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
                        File.WriteAllText(path + CommandSplit[1], String.Empty);
                        File.AppendAllText(path + CommandSplit[1], txtInput.Text);
                    }

                    else
                    {
                        //Creates the folder set above
                        Directory.CreateDirectory(path);
                        // Adds file with the name inputted to the folder
                        File.WriteAllText(path + CommandSplit[1], String.Empty);
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
                    catch(FileNotFoundException)
                    {
                        string error = "ERROR FILE NOT FOUND";
                        txtErrors.Text = error;
                        return;
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

        public void command()
        {
            txtCommandLine.Clear();
            Refresh();
            if (ifStatement)
            {
                //Checks for valid commands
                if (CommandSplit[0].Equals("moveto") == true)
                {
                    //Recieves two inputs and stores as integers
                    try
                    {
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
                        //Checks if the parameters inputted are variables
                        CheckForVariable();
                        //Tries to pass parameters
                        int x = int.Parse(ParameterSplit[0]);
                        int y = int.Parse(ParameterSplit[1]);
                        //Checks if the correct number of parameters have been inputted
                        if (ParameterSplit.Length != 2)
                        {
                            //Forces IndexOutOfRangeException
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
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
                        //Checks if the parameters inputted are variables
                        CheckForVariable();
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
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
                        //Checks if the parameters inputted are variables
                        CheckForVariable();
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
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
                        //Checks if the parameters inputted are variables
                        CheckForVariable();
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
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
                        //Checks if the parameters inputted are variables
                        CheckForVariable();
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
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
                        //Checks if the parameters inputted are variables
                        CheckForVariable();
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
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
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
                        //Splits parameters into seperate values and stores in array
                        ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
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
                        }
                    }
                    catch (FormatException ex)
                    {
                        InvalidParameter();
                        return;
                    }
                    catch (IndexOutOfRangeException ex1)
                    {
                        IncorrectNumberOfParameters();
                        return;
                    }
                }
                else if (CommandSplit[0].Equals("If"))
                {
                    //Splits the inputs into 3
                    string variable = CommandSplit[1];
                    string comparator = CommandSplit[2];
                    string value = CommandSplit[3];
                    Boolean isAVariable = false;
                    //Loops through the VariableDictionary to find the variable name inputted
                    foreach (KeyValuePair<string, int> variable1 in VariableDictionary)
                    {
                        try
                        {
                            //Checks if the value inputted is an integer
                            int width = int.Parse(value);
                            //checks if the variable is the current element in VariableDictionary
                            if (variable1.Key.Equals(variable))
                            {
                                //Sets check boolean to true
                                isAVariable = true;
                                //Checks what comparator is used
                                if (comparator.Equals("=="))
                                {
                                    //Checks if the statement inputted is true
                                    if (value.Equals(variable1.Value.ToString()))
                                    {
                                        //sets the boolean to check whether to read the following lines
                                        ifStatement = true;
                                    }
                                    else
                                    {
                                        //sets the boolean to not read the following lines until Endif is typed
                                        ifStatement = false;
                                    }
                                }
                                //Checks what comparator is used
                                else if (comparator.Equals(">"))
                                {
                                    //Checks if the statement inputted is true
                                    if ((variable1.Value > int.Parse(value)))
                                    {
                                        //sets the boolean to check whether to read the following lines
                                        ifStatement = true;
                                    }
                                    else
                                    {
                                        //sets the boolean to not read the following lines until Endif is typed
                                        ifStatement = false;
                                    }
                                }
                                //Checks what comparator is used
                                else if (comparator.Equals("<"))
                                {
                                    //Checks if the statement inputted is true
                                    if ((variable1.Value < int.Parse(value)))
                                    {
                                        //sets the boolean to check whether to read the following lines
                                        ifStatement = true;
                                    }
                                    else
                                    {
                                        //sets the boolean to not read the following lines until Endif is typed
                                        ifStatement = false;
                                    }
                                }
                                else
                                {
                                    //Throws error because an invalid Comparator was inputted
                                    InvalidComparator();
                                }
                            }
                        }
                        catch (FormatException ex)
                        {
                            //Throws exception because the value inputted was not an integer
                            InvalidParameter();
                            return;
                        }

                    }
                    if (isAVariable == false)
                    {
                        //Throws error because the variable inputted does not exist
                        notAVariable();
                    }
                }
                else if (CommandSplit[0].Equals("Endif"))
                {
                    //Sets boolean to true to end branching
                    ifStatement = true;
                }
                
                else if (CommandSplit.Length > 2)
                {
                    //Checks if the middle element is a "="
                    if (CommandSplit[1].Equals("="))
                    {
                        //Calls NewVariable()
                        NewVariable();
                    }
                    else
                    {
                        //Throws error because the command inputted was invalid
                        InvalidCommand();
                    }
                }
                else
                {
                    //Throws error because the command inputted was invalid
                    InvalidCommand();
                }

                Refresh();
            }
            else
            {
                if (CommandSplit[0].Equals("Endif"))
                {
                    //Sets boolean to true to end branching
                    ifStatement = true;
                }
            }

        }
        private void InvalidCommand()
        {
            //Method is called when user tries to input an invalid command
            string error = "ERROR INVALID COMMAND";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }
        private void InvalidParameter()
        {
            //Method is called when user tries to input an invalid parameter
            string error = "ERROR INVALID PARAMETERS";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }

        private void IncorrectNumberOfParameters()
        {
            //Method is called when user tries to input an incorrect number of parameters
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
        private void NewVariable()
        {
            Boolean AlreadyInArray = false;
            Boolean Value1IsVariable = false;
            Boolean Value2IsVariable = false;
            int value = 0;
            int value1= 0;
            int value2 = 0;
            //Loops through the VariableDictionary to check if the variable is already stored
            foreach (KeyValuePair<string, int> variable in VariableDictionary)
            {
                if (variable.Key.Equals(CommandSplit[0]))
                {
                    //If it is sets boolean value to true
                     AlreadyInArray = true;
                }
            }
            foreach (KeyValuePair<string, int> variable in VariableDictionary)
            {
                if (variable.Key.Equals(CommandSplit[2]))
                {
                    value1 = variable.Value;
                    Value1IsVariable = true;
                }
            }
            if (CommandSplit.Length.Equals(5))
            {
                foreach (KeyValuePair<string, int> variable in VariableDictionary)
                {
                    if (variable.Key.Equals(CommandSplit[4]))
                    {
                        value2 = variable.Value;
                        Value2IsVariable = true;
                    }
                }
            }
            if (AlreadyInArray)
            {
                //Removes the variable from the array
                VariableDictionary.Remove(CommandSplit[0]);
            }
            try
            {
                if (Value1IsVariable.Equals(false))
                {
                    value1 = int.Parse(CommandSplit[2]);
                }
                if (Value2IsVariable.Equals(false))
                {
                    if (CommandSplit.Length.Equals(5))
                    {
                        value2 = int.Parse(CommandSplit[4]);
                    }
                }
                if (CommandSplit.Length > 3) { 
                    if (CommandSplit[3].Equals("+"))
                    {
                        value = value1 + value2;
                    }
                    else if (CommandSplit[3].Equals("-"))
                    {
                        value = value1 - value2;
                    }
                    else
                    {
                        InvalidOperator();
                    }
                }
                else
                {
                    try
                    {
                        value = int.Parse(CommandSplit[2]);
                    }
                    catch (FormatException ex)
                    {
                        //If it is not an integer throw an error
                        ValueIsIncorrect();
                        return;
                    }

                }
                
                //Adds the variable with the inputted value if it is an integer
                VariableDictionary.Add(CommandSplit[0],value);
            }
            catch (FormatException ex)
            {
                //If it is not an integer throw an error
                ValueIsIncorrect();
                return;
            }

        }
        private void CheckForVariable()
        {
            //Loops through all the parameters
            for (int i=0;ParameterSplit.Length>i; i++)
            {

            
            try
            {
                    //Checks if the parameter is an int
                int test = int.Parse(ParameterSplit[i]);
            }
            catch
            {
                    //if it is not then loop through the VariableDictionary to check if the parameter is a variable name
                foreach (KeyValuePair<string, int> variable in VariableDictionary)
                {
                    if(variable.Key.Equals(ParameterSplit[i]))
                    {
                            //if it is then assign the parameter the integer value of the variable
                        ParameterSplit[i] = variable.Value.ToString();
                    }
                }
            }
            }

        }
        private void ValueIsIncorrect()
        {
            //Method is called when user tries to store a non integer value
            string error = "ERROR VALUE MUST BE AN INTEGER";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }
        private void InvalidComparator()
        {
            //Method is called when user tries to store a non integer value
            string error = "ERROR Comparator must be '==' or '>' or '<'";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }
        private void notAVariable()
        {
            //Method is called when user tries to store a non integer value
            string error = "Variable you have tried to compare is not a variable";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }
        private void InvalidOperator()
        {
            //Method is called when user tries to store a non integer value
            string error = "ERROR Operator must be '+' or '-' ";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + lineNumber;
        }

    }
}
