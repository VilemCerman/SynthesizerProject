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

            TrackBar PitchShift_TrB = new TrackBar
            {
                Name = "PitchShift",
                Location = new Point(175, 8),
                Size = new Size(56, 90),
                Orientation = Orientation.Vertical,
                TickStyle = TickStyle.TopLeft,
                Maximum = 12,
                Minimum = -12,
                TickFrequency = 2,
                Parent = this
            };
            PitchShift_TrB.Scroll += PitchShiftTrB_Scroll;

            TrackBar Volume_TrB = new TrackBar()
            {
                Name = "Volume",
                Location = new Point(220, 8),
                Size = new Size(56, 90),
                Orientation = Orientation.Vertical,
                TickStyle = TickStyle.TopLeft,
                Maximum = 10,
                Minimum = 0,
                TickFrequency = 1,
                Value = 10,
                Parent = this
            };
            Volume_TrB.Scroll += VolumeTrB_Scroll;

            foreach (Control control in this.Controls.OfType<Button>())
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Microsoft Sans Serif", 6.5f);
                control.Click += WaveButton_Click;
            }
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
    }
}
