using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;


namespace RussianRoulette
{
    public partial class Form1 : Form
    {
        // a 16ms timer for smooth animations
        Timer myTimer = new Timer();

        // timer for flashing "dot" on text and bool to help.
        Timer SecondsTimer = new Timer();
        bool isOddSecond = true;

        Timer textTimer = new Timer();

        // count dinger in through animation
        private int dingerTimerCounter;

        // some place to store text as it fills text prompt.
        private string remainingText = "";

        // control when to reset scrolling text
        private bool newText = false;

        public Form1()
        {
            InitializeComponent();
            dingerTimerCounter = picDinger.Location.Y;
            myTimer.Tick += animateDinger;
            myTimer.Interval = 16;
            myTimer.Start();

            textTimer.Tick += animateTextGo;
            textTimer.Interval = 100;
            textTimer.Start();
            
            SecondsTimer.Tick += oddEven;
            SecondsTimer.Interval = 1000;
            SecondsTimer.Start();

            PrivateFontCollection Player2Font = new PrivateFontCollection();
            Player2Font.AddFontFile("Resources/PressStart2P.ttf");
            btnGO.Font = new Font(Player2Font.Families[0], btnGO.Font.Size);

            picPusheen1.Enabled = false;
            picPusheen1.Image.SelectActiveFrame(new FrameDimension(picPusheen1.Image.FrameDimensionsList[0]), 1);
        }

        private void animateDinger(Object Timer, EventArgs e)
        {
            if (dingerTimerCounter == 0)
            {
                myTimer.Tick -= animateDinger;
                animateText("A wild Schrödinger appears!");
            }

            else
            {
                dingerTimerCounter += 4;

                var loc = picDinger.Location;
                loc.Y = dingerTimerCounter;
                picDinger.Location = loc;
            }
        }

        private void oddEven(Object sender, EventArgs e)
        {
            isOddSecond = !isOddSecond;
        }
        private void animateText(string text)
        {
            newText = true;
            remainingText = text;
        }

        private void animateTextGo(Object sender, EventArgs e)
        {
            var text = newText ? "" : btnGO.Text;
            newText = false;
            var dot = isOddSecond ? "." : " ";
            var length = text.Length == 0 ? 0 : text.Length - 1;

            var remaining = remainingText.Length == 0 ? "" : remainingText.Substring(0, 1);

            btnGO.Text = text.Substring(0, length) + remaining + dot;

            remainingText = remainingText.Length == 0 ? "" : remainingText.Substring(1, remainingText.Length - 1);
        }
    }
}
