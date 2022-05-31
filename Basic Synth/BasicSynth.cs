using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Basic_Synth
{
    public partial class BasicSynth : Form
    {
        private const int SAMPLE_RATE = 44100;
        private const short BITS_PER_SAMPLE = 16;
        public BasicSynth()
        {
            InitializeComponent();
        }


        private void BasicSynth_KeyDown(object sender, KeyEventArgs e)
        {
            
            IEnumerable<Oscillator> oscillators = this.Controls.OfType<Oscillator>();
            Random rnd = new Random();
            short[] wave = new short[SAMPLE_RATE];
            byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
            float frequency;
            //float frequency2 = 440.00f;
            float[] frequencies = new float[50] { 123.47f, 130.8f, 138.6f, 146.8f, 155.6f, 164.8f, 174.6f, 185.0f, 196.0f, 207.7f, 220.0f, 233.1f, 246.9f, 261.6f, 277.2f, 293.7f, 311.1f, 329.6f, 349.2f, 370.0f, 392.0f, 415.3f, 440.0f, 466.2f, 493.9f, 523.3f, 554.4f, 587.3f, 622.3f, 659.3f, 698.5f, 740.0f, 784.0f, 830.6f, 880.0f, 932.3f, 987.8f, 1047.50f, 1109f, 1175f, 1245f, 1319f, 1397f, 1480f, 1568f, 1661f, 1760f, 1865f, 1976f, 2093f };
            string[] keys = new string[25] { "z", "s", "x", "d", "c", "v", "g", "b", "h", "n", "j", "m", "q", "d2", "w", "d3", "e", "r", "d5", "t", "d6", "y", "d7", "u", "i" };
            int oscillatorsCount = oscillators.Count();
            //MessageBox.Show(e.KeyCode.ToString().ToLower() + " " + Array.IndexOf(keys , e.KeyCode.ToString().ToLower()));
            //MessageBox.Show(e.KeyCode.ToString().ToLower());
            //frequency = frequencies[Array.IndexOf(keys, e.KeyCode.ToString().ToLower()) + 12];
            //switch (e.KeyCode)
            //{
            //    case Keys.Z:
            //        frequency = 261.63f;     //C4
            //        frequency2 = 392.00f;
            //        break;
            //    case Keys.S:
            //        frequency = 277.18f;     //C#4
            //        frequency2 = 415.30f;
            //        break;
            //    case Keys.X:
            //        frequency = 293.66f;     //D4
            //        break;
            //    case Keys.D:
            //        frequency = 311.13f;     //Eb4
            //        break;
            //    case Keys.C:
            //        frequency = 329.63f;     //E4
            //        break;
            //    case Keys.V:
            //        frequency = 349.23f;     //F4
            //        break;
            //    case Keys.G:
            //        frequency = 369.99f;     //F#4
            //        break;
            //    case Keys.B:
            //        frequency = 392.00f;     //G4
            //        break;
            //    case Keys.H:
            //        frequency = 415.30f;     //Ab4
            //        break;
            //    case Keys.N:
            //        frequency = 440.00f;     //A4
            //        break;
            //    case Keys.J:
            //        frequency = 466.16f;     //Bb4
            //        break;
            //    case Keys.M:
            //        frequency = 493.88f;     //B4
            //        break;
            //    case Keys.Oemcomma:
            //    case Keys.Q:
            //        frequency = 523.25f;     //C5
            //        break;
            //    case Keys.L:
            //    case Keys.D2:
            //        frequency = 554.37f;     //C#5
            //        break;
            //    case Keys.OemPeriod:
            //    case Keys.W:
            //        frequency = 587.33f;     //D5
            //        break;
            //    case Keys.OemSemicolon:
            //    case Keys.D3:
            //        frequency = 622.25f;     //Eb5
            //        break;
            //    case Keys.OemQuestion:
            //    case Keys.E:
            //        frequency = 659.25f;     //E5
            //        break;
            //    case Keys.R:
            //        frequency = 698.46f;     //F5
            //        break;
            //    case Keys.D5:
            //        frequency = 739.99f;     //F#5
            //        break;
            //    case Keys.T:
            //        frequency = 783.99f;     //G5
            //        break;
            //    case Keys.D6:
            //        frequency = 830.61f;     //Ab5
            //        break;
            //    case Keys.Y:
            //        frequency = 880.00f;     //A5
            //        break;
            //    case Keys.D7:
            //        frequency = 932.33f;     //Bb5
            //        break;
            //    case Keys.U:
            //        frequency = 987.77f;     //B5
            //        break;
            //    case Keys.I:
            //        frequency = 1046.50f;     //C5
            //        break;
            //    default:
            //        return;
            //}


            
            int k = 0;
            foreach (Oscillator oscillator in this.Controls.OfType<Oscillator>())
            {
                //if (k == 1)
                //    frequency = frequency2;
                frequency = frequencies[Array.IndexOf(keys, e.KeyCode.ToString().ToLower()) + 13 + oscillator.PitchShift];
                int samplesPerWavelength = (int)(SAMPLE_RATE / frequency);
                short ampStep = (short)((short.MaxValue * 2) / samplesPerWavelength);
                short tempSample;
                switch (oscillator.WaveForm)
                {
                    case WaveForm.Sine:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i) / oscillatorsCount * oscillator.Volume);

                        }
                        break;
                    case WaveForm.Square:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * frequency) / SAMPLE_RATE * i)) / oscillatorsCount * oscillator.Volume);
                        }
                        break;
                    case WaveForm.Saw:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            tempSample = -short.MaxValue;
                            for (int j = 0; j < samplesPerWavelength && i < SAMPLE_RATE; j++)
                            {
                                tempSample += ampStep;
                                wave[i++] += Convert.ToInt16(tempSample / oscillatorsCount * oscillator.Volume);
                            }
                            i--;
                        }
                        break;
                    case WaveForm.Triangle:
                        tempSample = -short.MaxValue;
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            if(Math.Abs(tempSample + ampStep) > short.MaxValue)
                            {
                                ampStep = (short)-ampStep;
                            }
                            tempSample += ampStep;
                            wave[i] += Convert.ToInt16(tempSample / oscillatorsCount * oscillator.Volume);
                        }
                        break;
                    case WaveForm.Noise:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(rnd.Next(-short.MaxValue, short.MaxValue) / oscillatorsCount * oscillator.Volume);
                        }
                        break;
                }
                k++;
            }
            Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
            using (MemoryStream memoryStream = new MemoryStream())
            using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
            {
                short blockAlign = BITS_PER_SAMPLE / 8;
                int subChunkTwoSize = SAMPLE_RATE * blockAlign;
                binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
                binaryWriter.Write(36 + subChunkTwoSize);
                binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                binaryWriter.Write(16);
                binaryWriter.Write((short)1);
                binaryWriter.Write((short)1);
                binaryWriter.Write(SAMPLE_RATE);
                binaryWriter.Write(SAMPLE_RATE * blockAlign);
                binaryWriter.Write(blockAlign);
                binaryWriter.Write(BITS_PER_SAMPLE);
                binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
                binaryWriter.Write(subChunkTwoSize);
                binaryWriter.Write(binaryWave);
                memoryStream.Position = 0;
                new SoundPlayer(memoryStream).Play();
            }
        }
    }

    public enum WaveForm
    {
        Sine, Square, Saw, Triangle, Noise
    }
}
