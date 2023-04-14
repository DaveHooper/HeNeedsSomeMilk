using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Soundboard
{
    public partial class Form1 : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public Form1()
        {
            InitializeComponent();
            
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("bepis");
            PlaySound("soundfiles/lego-yoda.wav");
            
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            SoundButton button = sender as SoundButton;
            Console.WriteLine(button.Text + " " + button.path);
            PlaySound(button.path);
        }

        private void PlaySound(string fileName)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(fileName);
                outputDevice.Init(audioFile);
            }

            outputDevice.Play();

            /**
             
                string fileType = Path.GetExtension(fileName);
                if (fileType == ".wav")
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = fileName;
                    player.Play();
                }

                else if (fileType == ".mp3")
                {
                
                }
            */
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            outputDevice?.Stop();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("bepis 3");
        }

        private void addButtonStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Console.WriteLine("bepis 2");
            DialogResult result = openFileDialog1.ShowDialog();
            Console.WriteLine(openFileDialog1.FileName);
            string filePath = openFileDialog1.FileName;
            string fileName = filePath.Split('\\').Last();
            Console.WriteLine(fileName);
            SoundButton newButton = new SoundButton(filePath);
            newButton.Text = mainBoard.Controls.Count.ToString();
            newButton.Click += ButtonClick;
            mainBoard.Controls.Add(newButton);



        }

        private void addMuttonStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("mepis");
            Button1.Text = "mepis";
            Button newButton = new Button();
            mainBoard.Controls.Add(newButton);
            mainBoard.Controls[mainBoard.Controls.Count - 1].Text = "mepis" + mainBoard.Controls.Count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
