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

namespace DiscordMissionPubTool
{
    public partial class SettingView : Form
    {
        public SettingView()
        {
            InitializeComponent();
        }

        private void imgBlog_Click(object sender, EventArgs e)
        {
            OsOperationManager.OpenBrowser("https://blog.minexo79.club");
        }

        private void imgGithub_Click(object sender, EventArgs e)
        {
            OsOperationManager.OpenBrowser("https://github.com/minexo79");
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            tbName.Text             = Properties.Settings.Default.ClanName;
            tbColor.Text            = Properties.Settings.Default.ClanColor;
            tbLogo.Text             = Properties.Settings.Default.ClanPictureUrl;
            tbWebhookUrl.Text       = Properties.Settings.Default.DiscordWebhookUrl;
            tbRoleID.Text           = Properties.Settings.Default.DiscordTagRoleID;
            tbMissionAuthor.Text    = Properties.Settings.Default.MissionAuthor;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ClanName            = tbName.Text;
            Properties.Settings.Default.ClanColor           = tbColor.Text;
            Properties.Settings.Default.ClanPictureUrl      = tbLogo.Text;
            Properties.Settings.Default.DiscordWebhookUrl   = tbWebhookUrl.Text;
            Properties.Settings.Default.DiscordTagRoleID    = tbRoleID.Text;
            Properties.Settings.Default.ClanName            = tbMissionAuthor.Text;

            Properties.Settings.Default.Save();
            MainView.reloadProperties();

            new NotifyView("提示", "參數已更改。").Show();
        }
    }
}