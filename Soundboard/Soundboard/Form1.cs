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

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
