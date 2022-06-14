
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
            this.oscillator2 = new Basic_Synth.Oscillator();
            this.oscillator1 = new Basic_Synth.Oscillator();
            this.SuspendLayout();
            // 
            // oscillator2
            // 
            this.oscillator2.BackColor = System.Drawing.Color.Purple;
            this.oscillator2.Location = new System.Drawing.Point(13, 119);
            this.oscillator2.Name = "oscillator2";
            this.oscillator2.Size = new System.Drawing.Size(264, 100);
            this.oscillator2.TabIndex = 7;
            this.oscillator2.TabStop = false;
            this.oscillator2.Text = "oscillator2";
            // 
            // oscillator1
            // 
            this.oscillator1.BackColor = System.Drawing.Color.Purple;
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
            this.ClientSize = new System.Drawing.Size(607, 363);
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
        private Oscillator oscillator6;
        private Oscillator oscillator7;
        private Oscillator oscillator8;
    }
}

