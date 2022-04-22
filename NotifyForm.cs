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

namespace DiscordMissionPubTool
{
    public partial class NotifyForm : Form
    {
        public NotifyForm(string formName, string formMsg)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.Text = formName;
            lbNotifyMessage.Text = formMsg;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyForm_Load(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
        }
    }
}
