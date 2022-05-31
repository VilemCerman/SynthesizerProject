
namespace Basic_Synth
{
    partial class BasicSynth
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
            this.oscillator5 = new Basic_Synth.Oscillator();
            this.oscillator4 = new Basic_Synth.Oscillator();
            this.oscillator3 = new Basic_Synth.Oscillator();
            this.oscillator2 = new Basic_Synth.Oscillator();
            this.oscillator1 = new Basic_Synth.Oscillator();
            this.SuspendLayout();
            // 
            // oscillator5
            // 
            this.oscillator5.BackColor = System.Drawing.Color.Purple;
            this.oscillator5.Location = new System.Drawing.Point(283, 13);
            this.oscillator5.Name = "oscillator5";
            this.oscillator5.Size = new System.Drawing.Size(264, 100);
            this.oscillator5.TabIndex = 8;
            this.oscillator5.TabStop = false;
            this.oscillator5.Text = "oscillator5";
            // 
            // oscillator4
            // 
            this.oscillator4.Location = new System.Drawing.Point(13, 331);
            this.oscillator4.Name = "oscillator4";
            this.oscillator4.Size = new System.Drawing.Size(264, 100);
            this.oscillator4.TabIndex = 8;
            this.oscillator4.TabStop = false;
            this.oscillator4.Text = "oscillator4";
            // 
            // oscillator3
            // 
            this.oscillator3.Location = new System.Drawing.Point(12, 225);
            this.oscillator3.Name = "oscillator3";
            this.oscillator3.Size = new System.Drawing.Size(264, 100);
            this.oscillator3.TabIndex = 8;
            this.oscillator3.TabStop = false;
            this.oscillator3.Text = "oscillator3";
            // 
            // oscillator2
            // 
            this.oscillator2.Location = new System.Drawing.Point(13, 119);
            this.oscillator2.Name = "oscillator2";
            this.oscillator2.Size = new System.Drawing.Size(264, 100);
            this.oscillator2.TabIndex = 7;
            this.oscillator2.TabStop = false;
            this.oscillator2.Text = "oscillator2";
            // 
            // oscillator1
            // 
            this.oscillator1.Location = new System.Drawing.Point(13, 13);
            this.oscillator1.Name = "oscillator1";
            this.oscillator1.Size = new System.Drawing.Size(264, 100);
            this.oscillator1.TabIndex = 0;
            this.oscillator1.TabStop = false;
            this.oscillator1.Text = "oscillator1";
            // 
            // BasicSynth
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(607, 486);
            this.Controls.Add(this.oscillator5);
            this.Controls.Add(this.oscillator4);
            this.Controls.Add(this.oscillator3);
            this.Controls.Add(this.oscillator2);
            this.Controls.Add(this.oscillator1);
            this.KeyPreview = true;
            this.Name = "BasicSynth";
            this.Text = "Synth";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasicSynth_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Oscillator oscillator1;
        private Oscillator oscillator2;
        private Oscillator oscillator3;
        private Oscillator oscillator4;
        private Oscillator oscillator5;
    }
}

