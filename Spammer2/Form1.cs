using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spammer {
    public partial class Form1 : Form {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;

        public Form1() {
            InitializeComponent();
        }
        bool on = false;
        private void startButton_Click(object sender, EventArgs e) {
            if (on) {
                timer1.Stop();
                startButton.Text = "Start";
            } else {
                timer1.Start();
                startButton.Text = "Stop";
            }
            on = !on;
            label2.Focus();
        }
        private void trackBar1_Scroll(object sender, EventArgs e) {
            label3.Text = "(" + trackBar1.Value + " ms)";
            timer1.Interval = trackBar1.Value;
        }
        private void timer1_Tick(object sender, EventArgs e) {
            SendKeys.Send(messageText.Text);
            SendKeys.Send("{ENTER}");
        }

        private void trackBar2_Scroll(object sender, EventArgs e) {
            timer2.Interval = 1000 / trackBar2.Value;
            label7.Text = "(" + trackBar2.Value + " CPS)";
        }

        private void timer2_Tick(object sender, EventArgs e) {
            mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
        }

        bool autoclickerOn = false;
        private void button1_Click(object sender, EventArgs e) {
            if (autoclickerOn) {
                timer2.Stop();
                button1.Text = "Start";
            } else {
                timer2.Start();
                button1.Text = "Stop";
            }
            autoclickerOn = !autoclickerOn;
            label2.Focus();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '*') {
                button1_Click(sender, e);
            }
            if (e.KeyChar == '/') {
                startButton_Click(sender, e);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
