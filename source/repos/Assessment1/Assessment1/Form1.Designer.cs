namespace Assessment1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.lblnput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblCommandLine = new System.Windows.Forms.Label();
            this.OutputWindow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtOutput.Location = new System.Drawing.Point(936, 61);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(871, 548);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Visible = false;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtInput.Location = new System.Drawing.Point(12, 61);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(871, 548);
            this.txtInput.TabIndex = 1;
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtCommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandLine.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtCommandLine.Location = new System.Drawing.Point(12, 654);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(1795, 26);
            this.txtCommandLine.TabIndex = 2;
            this.txtCommandLine.TextChanged += new System.EventHandler(this.txtCommandLine_TextChanged);
            this.txtCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommandLine_KeyDown);
            // 
            // lblnput
            // 
            this.lblnput.AutoSize = true;
            this.lblnput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnput.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblnput.Location = new System.Drawing.Point(7, 4);
            this.lblnput.Name = "lblnput";
            this.lblnput.Size = new System.Drawing.Size(150, 25);
            this.lblnput.TabIndex = 3;
            this.lblnput.Text = "Program Code";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOutput.Location = new System.Drawing.Point(942, 4);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(91, 25);
            this.lblOutput.TabIndex = 4;
            this.lblOutput.Text = "Console";
            this.lblOutput.Visible = false;
            // 
            // lblCommandLine
            // 
            this.lblCommandLine.AutoSize = true;
            this.lblCommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommandLine.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCommandLine.Location = new System.Drawing.Point(12, 612);
            this.lblCommandLine.Name = "lblCommandLine";
            this.lblCommandLine.Size = new System.Drawing.Size(156, 25);
            this.lblCommandLine.TabIndex = 5;
            this.lblCommandLine.Text = "Command Line";
            // 
            // OutputWindow
            // 
            this.OutputWindow.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.OutputWindow.Location = new System.Drawing.Point(936, 61);
            this.OutputWindow.Name = "OutputWindow";
            this.OutputWindow.Size = new System.Drawing.Size(871, 548);
            this.OutputWindow.TabIndex = 6;
            this.OutputWindow.TabStop = false;
            this.OutputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.OutputWindow_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1827, 928);
            this.Controls.Add(this.OutputWindow);
            this.Controls.Add(this.lblCommandLine);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblnput);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Label lblnput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblCommandLine;
        private System.Windows.Forms.PictureBox OutputWindow;
    }
}




