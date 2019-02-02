using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r
{
    public partial class PopUpForm : MetroFramework.Forms.MetroForm
    {

        public bool enabled = false;
        public PopUpForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            txtDestination.Text = MainForm.passingText;
            Show();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            enabled = false;

            SoundPlayer player = new SoundPlayer();

            player.Stop();
        }

        private void PopUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            enabled = false;

            SoundPlayer player = new SoundPlayer();

            player.Stop();
        }

    }
}
