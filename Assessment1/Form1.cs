using System;
using System.Collections;
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
        public IDictionary<string, int> VariableDictionary = new Dictionary<string, int>();
        public IDictionary<string, int> MethodVariableDictionary = new Dictionary<string, int>();
        public Dictionary<string,List <string>> MethodDictionary = new Dictionary<string,List <string>>();
        public Boolean ifStatement= true;
        public Boolean LoopStatement = true;
        public int LoopStart;
        public int LoopEnd;
        public string line;
        public List<String> LoopArray = new List<string>();
        public List<string> methodParameters = new List<string>();
        public ArrayList LinesArray= new ArrayList();
        public int methodStart;
        public int methodEnd;
        public string methodName;
        public string LoopVariable;
        public int LoopVariableValue;
        public string LoopComparator;
        public int LoopValue;
        public string error;
        public string variable;
        public string comparator;
        public string value;
        public int VariableValue=0;
        Boolean isAVariable = false;
        Factory factory = new Factory();

        /// <summary>
        /// Initialises the graphics on the bitmap by inheriting the canvass from Canvass.cs
        /// </summary>
        public Form1()
        {
            //Sets graphics up on bitmap
            InitializeComponent();
            MyCanvass = new Canvass(Graphics.FromImage(OutputBitMap));
        }
        private void txtCommandLine_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// If the user presses enter in the commandLine the method is run
        /// checks value typed and processes command accordingly
        /// Checks if the user wants to use the programme box if they typed save,load or run
        /// If they did not, just pass the single command through to command()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            //Checks if enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                LinesArray = new ArrayList();
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
                    pictureBox1.Visible = true;
                    OutputWindow.Visible = false;
                    //This takes all the text in the input box
                    //Splits it into individual lines
                    using (StringReader reader = new StringReader(txtInput.Text))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            LinesArray.Add(line);
                        }
                        //Loops through each line in the input box

                        lineNumber = 0;
                        ErrorList="";
                        for (int i=0; i<LinesArray.Count;i++ )
                        {
                             line= LinesArray[i].ToString();
                            //Splits line and stores values in commandSplit Array
                            CommandSplit = line.Split(' ');
                            lineNumber=i;
                            //Calls command method
                            command();
                        }
                        //Checks if there are any errors
                        if (ErrorList.Equals(""))
                        {
                            pictureBox1.Visible = false;
                            OutputWindow.Visible = true;
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
                    try
                    {


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
                    catch (IndexOutOfRangeException ex1)
                    {
                        IncorrectNumberOfParameters();
                        return;
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
                    catch (IndexOutOfRangeException ex1)
                    {
                        IncorrectNumberOfParameters();
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
        /// <summary>
        /// Uses the commandSplit that is populated for every new line
        /// Checks which command has been typed on that line
        /// Proccesses the command accordingly
        /// </summary>
        public void command()
        {
            txtCommandLine.Clear();
            Refresh();
            if (ifStatement)
            {
                if (LoopStatement)
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
                            int width = int.Parse(ParameterSplit[0]);
                            if (ParameterSplit.Length != 1)
                            {
                                ParameterCheck[1] = ParameterSplit[1];
                            }
                            else
                            {
                                Shape shape;
                                shape = factory.getShape("square");
                                shape.set(MyCanvass.Pen.Color, MyCanvass.xPos, MyCanvass.yPos, width);
                                if (MyCanvass.Fill == 1)
                                {
                                    shape.fill(MyCanvass.g);
                                }
                                else
                                {
                                    shape.draw(MyCanvass.g);
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
							Shape shape;
							shape = factory.getShape("circle");
                            shape.set(MyCanvass.Pen.Color, MyCanvass.xPos, MyCanvass.yPos, radius);
                                if (MyCanvass.Fill == 1)
                                {
                                    shape.fill(MyCanvass.g);
                                }
                                else { 
                                    shape.draw(MyCanvass.g); 
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
                                Shape shape;
                                shape = factory.getShape("triangle");
                                shape.set(MyCanvass.Pen.Color, MyCanvass.xPos, MyCanvass.yPos, width, height);
                                if (MyCanvass.Fill == 1)
                                {
                                    shape.fill(MyCanvass.g);
                                }
                                else
                                {
                                    shape.draw(MyCanvass.g);
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
                                Shape shape;
                                shape = factory.getShape("rectangle");
                                shape.set(MyCanvass.Pen.Color, MyCanvass.xPos, MyCanvass.yPos, width, height);
                                if (MyCanvass.Fill == 1)
                                {
                                    shape.fill(MyCanvass.g);
                                }
                                else
                                {
                                    shape.draw(MyCanvass.g);
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
                        //Writes to console
                        Console.WriteLine("RECTANGLE");
                    }
                    else if (CommandSplit[0].Equals("arc") == true)
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
                                Shape shape;
                                shape = factory.getShape("arc");
                                shape.set(MyCanvass.Pen.Color, MyCanvass.xPos, MyCanvass.yPos, width, height);
                                if (MyCanvass.Fill == 1)
                                {
                                    shape.fill(MyCanvass.g);
                                }
                                else
                                {
                                    shape.draw(MyCanvass.g);
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
                        //Writes to console
                        Console.WriteLine("ARC");
                    }
                    else if (CommandSplit[0].Equals("hexagon") == true)
                    {
                        //Recieves input and strores as an integer
                        try

                        {
                            //Splits parameters into seperate values and stores in array
                            ParameterSplit = CommandSplit[1].Split(",".ToCharArray());
                            //Checks if the parameters inputted are variables
                            CheckForVariable();
                            //Checks if the correct number of paramters have been passed
                            int width = int.Parse(ParameterSplit[0]);
                            if (ParameterSplit.Length != 1)
                            {
                                ParameterCheck[1] = ParameterSplit[1];
                            }
                            else
                            {
                                Shape shape;
                                shape = factory.getShape("hexagon");
                                shape.set(MyCanvass.Pen.Color, MyCanvass.xPos, MyCanvass.yPos, width);
                                if (MyCanvass.Fill == 1)
                                {
                                    shape.fill(MyCanvass.g);
                                }
                                else
                                {
                                    shape.draw(MyCanvass.g);
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

                        //Writes to console
                        Console.WriteLine("HEXAGON");
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
                    else if (CommandSplit[0].Equals("if"))
                    {
                        //Splits the inputs into 3
                        variable = CommandSplit[1];
                        comparator = CommandSplit[2];
                        value = CommandSplit[3];
                        isAVariable = false;
                        //Loops through the MethodVariableDictionary to find the variable name inputted
                        foreach (KeyValuePair<string, int> variable1 in MethodVariableDictionary)
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
                                    VariableValue = variable1.Value;
                                    checkIf();
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
                                        VariableValue = variable1.Value;
                                        checkIf();
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    //Throws exception because the value inputted was not an integer
                                    InvalidParameter();
                                    return;
                                }

                            }
                        }
                        if (isAVariable == false)
                        {
                            //Throws error because the variable inputted does not exist
                            notAVariable();
                        }
                    }
                    else if (CommandSplit[0].Equals("endif"))
                    {
                        //Sets boolean to true to end branching
                        ifStatement = true;
                    }
                    else if (CommandSplit[0].Equals("while"))
                    {
                        //Splits the inputs into 3
                        variable = CommandSplit[1];
                        comparator = CommandSplit[2];
                        value = CommandSplit[3];
                        Boolean isAVariable = false;
                        foreach (KeyValuePair<string, int> variable1 in MethodVariableDictionary)
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
                                    VariableValue = variable1.Value;
                                    CheckLoop();
                                }
                                if (LoopStatement)
                                {
                                    LoopVariable = variable1.Key;
                                }
                            }
                            catch (FormatException ex)
                            {
                                LoopStatement = false;
                                //Throws exception because the value inputted was not an integer
                                InvalidParameter();
                                return;
                            }

                        }
                        if (isAVariable == false)
                        {
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
                                        VariableValue = variable1.Value;
                                        CheckLoop();
                                    }
                                    if (LoopStatement)
                                    {
                                        LoopVariable = variable1.Key;
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    LoopStatement = false;
                                    //Throws exception because the value inputted was not an integer
                                    InvalidParameter();
                                    return;
                                }

                            }
                        }

                        if (isAVariable == false)
                        {
                            LoopStatement = false;
                            //Throws error because the variable inputted does not exist
                            notAVariable();
                        }
                    }
                    else if (CommandSplit[0].Equals("endwhile"))
                    {
                        LoopStart = LoopStart + 1;
                        LoopEnd = lineNumber;
                        
                        foreach (KeyValuePair<string, int> variable in VariableDictionary)
                        {
                            if (variable.Key.Equals(LoopVariable))
                            {
                                //if it is then assign the parameter the integer value of the variable
                                LoopVariableValue = variable.Value;
                            }
                        }
                        foreach (KeyValuePair<string, int> variable in MethodVariableDictionary)
                        {
                            if (variable.Key.Equals(LoopVariable))
                            {
                                //if it is then assign the parameter the integer value of the variable
                                LoopVariableValue = variable.Value;
                            }
                        }
                        if (LoopComparator.Equals("=="))
                        {
                            while (LoopVariableValue == LoopValue){
                                StartLoop();
                            }
                        }
                        else if (LoopComparator.Equals(">"))
                        {
                            while (LoopVariableValue > LoopValue)
                            {
                                StartLoop();
                            }
                        }
                        else if (LoopComparator.Equals("<"))
                        {
                            while (LoopVariableValue < LoopValue)
                            {
                                StartLoop();
                            }
                        }
                        else if (LoopComparator.Equals("<="))
                        {
                            while (LoopVariableValue <= LoopValue)
                            {
                                StartLoop();
                            }
                        }
                        else if (LoopComparator.Equals(">="))
                        {
                            while (LoopVariableValue >= LoopValue)
                            {
                                StartLoop();
                            }
                        }



                    }
                    else if (CommandSplit[0].Equals("method"))
                    {
                        methodName = CommandSplit[1];
                        methodStart = lineNumber;
                        ifStatement = false;
                        String parameters;
                        parameters = CommandSplit[2].Replace("(","");
                        parameters = parameters.Replace(")", "");
                        ParameterSplit = parameters.Split(',');
                        methodParameters.Clear();
                        foreach(string variable in ParameterSplit)
                        {
                            try
                            {
                                methodParameters.Add((variable));
                            }
                            catch (FormatException ex)
                            {
                                //Throws exception because the value inputted was not an integer
                                InvalidParameter();
                                return;
                            }
                        }
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
                        Boolean checkMethod = false;
                        foreach (KeyValuePair<string, List<string>> method in MethodDictionary)
                        {
                            if (method.Key.Equals(CommandSplit[0]))
                            {
                                String parameters;
                                parameters = CommandSplit[1].Replace("(", "");
                                parameters = parameters.Replace(")", "");
                                ParameterSplit = parameters.Split(',');
                                CheckForVariable();
                                int startPoint = int.Parse(method.Value[0])+1;
                                int endPoint = int.Parse(method.Value[1]);
                                MethodVariableDictionary.Clear();
                                if ((ParameterSplit.Length) == (method.Value.Count() - 2))
                                {
                                    for (int i = 2; i < method.Value.Count(); i++)
                                    {
                                        try
                                        {
                                            MethodVariableDictionary.Add(method.Value[i], int.Parse(ParameterSplit[i - 2]));
                                        }
                                        catch (IndexOutOfRangeException ex1)
                                        {
                                            IncorrectNumberOfParameters();
                                            return;
                                        }
                                    }
                                    for (int start = startPoint; start < endPoint; start++)
                                    {
                                        line = LinesArray[start].ToString();
                                        //Splits line and stores values in commandSplit Array
                                        CommandSplit = line.Split(' ');
                                        lineNumber = start;
                                        //Calls command method
                                        command();
                                    }
                                    MethodVariableDictionary.Clear();
                                    checkMethod = true;
                                }
                                else
                                {
                                    checkMethod = true;
                                    IncorrectNumberOfParameters();
                                }
                                MethodVariableDictionary.Clear();
                            }
                        }
                        if (checkMethod.Equals(false)){
                            //Throws error because the command inputted was invalid
                            InvalidCommand();
                        }
                        
                    }

                    Refresh();
                }
                else
                {
                    if (CommandSplit[0].Equals("endwhile"))
                    {
                        //Sets boolean to true to end branching
                        LoopStatement = true;
                    }
                }
            }
            else
                {
                    if (CommandSplit[0].Equals("endif"))
                    {
                        //Sets boolean to true to end branching
                        ifStatement = true;
                    }
                    if (CommandSplit[0].Equals("endmethod"))
                    {
                    Boolean AlreadyInArray = false;
                    methodEnd = lineNumber;

                    List <string> Method = new List<string>();
                    Method.Add(methodStart.ToString());
                    Method.Add(methodEnd.ToString());
                    foreach(string variable in methodParameters)
                    {
                        Method.Add(variable);
                    }
                    foreach (KeyValuePair<string, List<string>> method in MethodDictionary)
                    {
                        if (method.Key.Equals(methodName))
                        {
                            //If it is sets boolean value to true
                            AlreadyInArray = true;
                        }
                    }
                    if (AlreadyInArray)
                    {
                        MethodDictionary.Remove(methodName);
                    }
                    MethodDictionary.Add(methodName,Method);
                        //Sets boolean to true to end branching
                        ifStatement = true;
                    }
            }
            

        }
        /// <summary>
        /// This method is called when the command typed is not a recognised command
        /// Errors are outputted to the error box and also added to ErrorList so that they can be outputted once all the lines in the program box have been processed.
        /// </summary>
       public void InvalidCommand()
        {
            //Method is called when user tries to input an invalid command
            error = "ERROR INVALID COMMAND";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + (lineNumber+1);
        }
        /// <summary>
        /// This method is called when the parameters typed are not of the correct format
        /// Errors are outputted to the error box and also added to ErrorList so that they can be outputted once all the lines in the program box have been processed.
        /// </summary>
        public void InvalidParameter()
        {
            //Method is called when user tries to input an invalid parameter
            error = "ERROR INVALID PARAMETERS";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + (lineNumber + 1);
        }

        /// <summary>
        /// This method is called when there is an incorrect number of parameters for the command typed
        /// Errors are outputted to the error box and also added to ErrorList so that they can be outputted once all the lines in the program box have been processed.
        /// </summary>
        public void IncorrectNumberOfParameters()
        {
            //Method is called when user tries to input an incorrect number of parameters
             error = "ERROR INCORRECT NUMBER OF PARAMETERS";
            txtErrors.Text = error ;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + (lineNumber + 1);
            
        }

        /// <summary>
        /// Initialises the graphics to go on the output window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            //Initialises the graphics on the output window
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitMap, 0, 0);
        }

        /// <summary>
        /// Takes the variable name from CommandSplit[0]
        /// Takes value from CommandSplit[2]
        /// If the value is being changed then the value at CommandSplit[4] is also stored
        /// It checks which operator has been used and changes the value accordingly e.g width = width + 100 will change the value to be stored by 100
        /// The method checks if there is already a variable in the dictionary with the same name
        /// If there is, it will delete this variable
        /// It then adds the variable using the varible name as the key and the variable value as the value
        /// </summary>
        public void NewVariable()
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
        /// <summary>
        /// Loops for each parameter that is passed into the ParameterSplit array
        /// checks if the paramater is an integer or a string
        /// If it is a string it will check if the string is a variable name in the variable dictionary
        /// If it is then put the value of the variable into the parameters array.
        /// </summary>
        public void CheckForVariable()
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
                    Boolean foundVariable =false;
                    foreach (KeyValuePair<string, int> variable in MethodVariableDictionary)
                    {
                        if (variable.Key.Equals(ParameterSplit[i]))
                        {
                            //if it is then assign the parameter the integer value of the variable
                            ParameterSplit[i] = variable.Value.ToString();
                            //ErrorList = ErrorList + variable.Key + ParameterSplit[i] + Environment.NewLine; ;
                            foundVariable = true;
                        }
                    }
                    if (foundVariable == false)
                    {
                        //if it is not then loop through the VariableDictionary to check if the parameter is a variable name
                        foreach (KeyValuePair<string, int> variable in VariableDictionary)
                        {
                            if (variable.Key.Equals(ParameterSplit[i]))
                            {
                                //if it is then assign the parameter the integer value of the variable
                                ParameterSplit[i] = variable.Value.ToString();
                            }
                        }
                    }
                    
                }
            }

        }



        /// <summary>
        /// Checks that the if statement is true or false
        /// Checks which operator has been used and checks the value against the variable value
        /// Changes ifStatement to true if the statement is true
        /// Changes ifStatement to false if the statement is false
        /// If an incorrect comparator is used then an error is thrown
        /// </summary>
        public void checkIf()
        {
            //Checks what comparator is used
            if (comparator.Equals("=="))
            {
                //Checks if the statement inputted is true
                if (int.Parse(value).Equals(VariableValue))
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
                if ((VariableValue > int.Parse(value)))
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
                if ((VariableValue < int.Parse(value)))
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
            else if (comparator.Equals("<="))
            {
                //Checks if the statement inputted is true
                if ((VariableValue <= int.Parse(value)))
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
            else if (comparator.Equals(">="))
            {
                //Checks if the statement inputted is true
                if ((VariableValue >= int.Parse(value)))
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


        /// <summary>
        /// Checks that the while statement is true or false
        /// Checks which operator has been used and checks the value against the variable value
        /// Changes LoopStatement to true if the statement is true, gets the line numebr of the start of the loop,
        /// initialises the variable LoopValue to equal the value being compared with the variable value and
        /// initialises the variable LoopComparator to equal the comparator being used in the while statement.
        /// Changes LooStatement to false if the statement is false
        /// If an incorrect comparator is used then an error is thrown
        /// </summary>
        public void CheckLoop()
        {
            //Checks what comparator is used
            if (comparator.Equals("=="))
            {
                //Checks if the statement inputted is true
                if (int.Parse(value).Equals(VariableValue))
                {
                    //sets the boolean to check whether to read the following lines
                    LoopStatement = true;
                    LoopStart = lineNumber;
                    
                    LoopValue = int.Parse(value);
                    LoopComparator = comparator;
                }
                else
                {
                    //sets the boolean to not read the following lines until Endif is typed
                    LoopStatement = false;
                }
            }
            //Checks what comparator is used
            else if (comparator.Equals(">"))
            {
                //Checks if the statement inputted is true
                if ((VariableValue > int.Parse(value)))
                {
                    //sets the boolean to check whether to read the following lines
                    LoopStatement = true;
                    LoopStart = lineNumber;
                    LoopValue = int.Parse(value);
                    LoopComparator = comparator;
                }
                else
                {
                    //sets the boolean to not read the following lines until Endif is typed
                    LoopStatement = false;
                }
            }
            //Checks what comparator is used
            else if (comparator.Equals("<"))
            {
                //Checks if the statement inputted is true
                if ((VariableValue < int.Parse(value)))
                {
                    //sets the boolean to check whether to read the following lines
                    LoopStatement = true;
                    LoopStart = lineNumber;
                    LoopValue = int.Parse(value);
                    LoopComparator = comparator;
                }
                else
                {
                    //sets the boolean to not read the following lines until Endif is typed
                    LoopStatement = false;
                }
            }
            //Checks what comparator is used
            else if (comparator.Equals("<="))
            {
                //Checks if the statement inputted is true
                if ((VariableValue <= int.Parse(value)))
                {
                    //sets the boolean to check whether to read the following lines
                    LoopStatement = true;
                    LoopStart = lineNumber;
                    LoopValue = int.Parse(value);
                    LoopComparator = comparator;
                }
                else
                {
                    //sets the boolean to not read the following lines until Endif is typed
                    LoopStatement = false;
                }
            }
            //Checks what comparator is used
            else if (comparator.Equals(">="))
            {
                //Checks if the statement inputted is true
                if ((VariableValue >= int.Parse(value)))
                {
                    //sets the boolean to check whether to read the following lines
                    LoopStatement = true;
                    LoopStart = lineNumber;
                    LoopValue = int.Parse(value);
                    LoopComparator = comparator;
                }
                else
                {
                    //sets the boolean to not read the following lines until Endif is typed
                    LoopStatement = false;
                }
            }
            else
            {
                LoopStatement = false;
                //Throws error because an invalid Comparator was inputted
                InvalidComparator();
            }
        }

        /// <summary>
        /// Loops from the startline to the endline by getting the lines from the LinesArray
        /// Splits the line and updates the line number
        /// Calls the command() method to process the command
        /// It will also update the variable being compared in the while statement 
        /// If the value has been changed during the loop
        /// </summary>
        public void StartLoop()
        {
            for (int start = LoopStart; start < LoopEnd; start++)
            {
                line = LinesArray[start].ToString();
                //Splits line and stores values in commandSplit Array
                CommandSplit = line.Split(' ');
                lineNumber = start;
                //Calls command method
                command();
            }
            foreach (KeyValuePair<string, int> variable in VariableDictionary)
            {
                if (variable.Key.Equals(LoopVariable))
                {
                    //if it is then assign the parameter the integer value of the variable
                    LoopVariableValue = variable.Value;
                }
            }
        }
        /// <summary>
        /// This method is called when the parameter being used to change the value of a variable is not an integer
        /// Errors are outputted to the error box and also added to ErrorList so that they can be outputted once all the lines in the program box have been processed.
        /// </summary>
        public void ValueIsIncorrect()
        {
            //Method is called when user tries to store a non integer value
            string error = "ERROR VALUE MUST BE AN INTEGER";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + (lineNumber + 1);
        }
        /// <summary>
        /// This method is called when the comparator being used in while and if statements is invalid 
        /// Errors are outputted to the error box and also added to ErrorList so that they can be outputted once all the lines in the program box have been processed.
        /// </summary>
        public void InvalidComparator()
        {
            //Method is called when user tries to store a non integer value
            string error = "ERROR Comparator must be '==' or '>' or '<'";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + (lineNumber + 1);
        }
        /// <summary>
        /// This method is called when the variable they have tried to use in a if or while statement is not a variable stored in the dictionary.
        /// Errors are outputted to the error box and also added to ErrorList so that they can be outputted once all the lines in the program box have been processed.
        /// </summary>
        public void notAVariable()
        {
            //Method is called when user tries to store a non integer value
            string error = "Variable you have tried to compare is not a variable";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + (lineNumber + 1);
        }
        /// <summary>
        /// This method is called when the operator used to change the value of the variable inputted is invalid
        /// Errors are outputted to the error box and also added to ErrorList so that they can be outputted once all the lines in the program box have been processed.
        /// </summary>
        public void InvalidOperator()
        {
            //Method is called when user tries to store a non integer value
            string error = "ERROR Operator must be '+' or '-' ";
            txtErrors.Text = error;
            ErrorList = ErrorList + Environment.NewLine;
            ErrorList = ErrorList + error + " AT LINE " + (lineNumber + 1);
        }

    }
}
