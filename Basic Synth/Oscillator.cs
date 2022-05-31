using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Synth
{
    class Oscillator : GroupBox
    {
        public Oscillator()
        {
            this.BackColor = Color.Purple;
            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new Point(10, 15),
                Text = "Sine",
                BackColor = Color.MediumPurple
            });
            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(65, 15),
                Text = "Square",
                UseVisualStyleBackColor = true
        });
            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(120, 15),
                Text = "Saw",
                UseVisualStyleBackColor = true
            });
            this.Controls.Add(new Button()
            {
                Name = "Tringle",
                Location = new Point(10, 50),
                Text = "Triangle",
                UseVisualStyleBackColor = true
            });
            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(65, 50),
                Text = "Noise",
                UseVisualStyleBackColor = true

            });
            //this.Controls.Add(new TextBox()
            //{
            //    Name = "Pitch",
            //    Location = new Point(120, 50),
            //    Text = "1"
            //});

            TrackBar PitchShift_TrB = new TrackBar();
            PitchShift_TrB.Name = "PitchShift";
            
            PitchShift_TrB.Location = new Point(175, 8);
            PitchShift_TrB.Size = new Size(56, 90);
            PitchShift_TrB.Orientation = Orientation.Vertical;
            PitchShift_TrB.TickStyle = TickStyle.TopLeft;
            PitchShift_TrB.Maximum = 12;
            PitchShift_TrB.Minimum = -12;
            PitchShift_TrB.TickFrequency = 2;
            PitchShift_TrB.Scroll += PitchShiftTrB_Scroll;
            PitchShift_TrB.Parent = this;

            TrackBar Volume_TrB = new TrackBar();
            Volume_TrB.Name = "Volume";
            Volume_TrB.Location = new Point(220, 8);
            Volume_TrB.Size = new Size(56, 90);
            Volume_TrB.Orientation = Orientation.Vertical;
            Volume_TrB.TickStyle = TickStyle.TopLeft;
            Volume_TrB.Maximum = 10;
            Volume_TrB.Minimum = 0;
            Volume_TrB.TickFrequency = 1;
            Volume_TrB.Value = 10;
            Volume_TrB.Scroll += VolumeTrB_Scroll;
            Volume_TrB.Parent = this;

            foreach (Control control in this.Controls.OfType<Button>())
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Microsoft Sans Serif", 6.5f);
                control.Click += WaveButton_Click;
            }

            
            //foreach (Control control in this.Controls.OfType<TextBox>())
            //{
            //    control.Size = new Size(50, 30);
            //    control.Font = new Font("Microsoft Sans Serif", 6.5f);
            //    control.KeyDown += PitchTb_KeyDown;
            //}

        }

        public WaveForm WaveForm { get; private set; }
        public int PitchShift { get; private set; }
        public double Volume { get; private set; } = 1;

        private void WaveButton_Click(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Button button = (Button)sender;
                this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);
                foreach(Button otherButtons in this.Controls.OfType<Button>())
                {
                    otherButtons.UseVisualStyleBackColor = true;
                }
                button.BackColor = Color.MediumPurple;
            }
        }

        private void PitchShiftTrB_Scroll(object sender, EventArgs e)
        {
            TrackBar TrB = (TrackBar)sender;
            PitchShift = TrB.Value;
        }

        private void VolumeTrB_Scroll(object sender, EventArgs e)
        {
            TrackBar TrB = (TrackBar)sender;
            Volume = TrB.Value / (double)10;
        }

        //private void PitchTb_KeyDown(object sender, KeyEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    if (int.TryParse(textBox.Text, out int result) && Convert.ToInt32(textBox.Text) >= -12 && Convert.ToInt32(textBox.Text) <= 12)
        //    {
        //        PitchShift = result;
        //    }
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        foreach (TextBox TB in this.Controls.OfType<TextBox>())
        //        {

        //        }
        //    }
        //    //this.Controls.OfType<TextBox>() = null;
        //    //this.ActiveControl = null;
        //}
    }
}
