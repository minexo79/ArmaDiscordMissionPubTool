using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordMissionPubTool.Manager;
using DiscordMissionPubTool.Services;

namespace DiscordMissionPubTool
{
    public partial class AboutView : Form
    {
        public AboutView(string text)
        {
            InitializeComponent();

            this.Text = text;
        }

        private void imgBlog_Click(object sender, EventArgs e)
        {
            OsOperationManager.OpenBrowser("https://blog.minexo79.club");
        }

        private void imgGithub_Click(object sender, EventArgs e)
        {
            OsOperationManager.OpenBrowser("https://github.com/minexo79");
        }
    }
}
