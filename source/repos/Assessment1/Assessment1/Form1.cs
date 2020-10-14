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
                    Console.WriteLine("SQUARE");
                }
                else if (Command.Equals("clear") == true)
                {
                    MyCanvass.clearArea(txtCommandLine.BackColor);
                    Console.WriteLine("CLEAR");
                }
                else if (Command.Equals("reset") == true)
                {
                    MyCanvass.resetPenPosition();
                    Console.WriteLine("RESET PEN");
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
