using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using ReaLTaiizor.Controls;
using DiscordMissionPubTool.Manager;
using DiscordMissionPubTool.Models;
using System.Net;

namespace DiscordMissionPubTool
{
    public partial class MainView : Form
    {
        ClanModel clanModel     = new ClanModel();
        string webhookID        = Properties.Settings.Default.DiscordWebhookID;
        string webhookToken     = Properties.Settings.Default.DiscordWebhookToken;
        string clanName         = Properties.Settings.Default.ClanName;
        string clanColor        = Properties.Settings.Default.ClanColor;
        string clanPictureUrl   = Properties.Settings.Default.ClanPictureUrl;
        string discordTagroleID = Properties.Settings.Default.DiscordTagRoleID;

        public MainView()
        {
            InitializeComponent();

            dpDate.Value = DateTime.Now;
        }

        private void MainFormControl_ValueChanged(object sender, EventArgs e)
        {
            OsOperationManager.PackageClanModel(ref clanModel, ref sender);
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            btnSavePublish.Enabled = false;

            string warning = InputBoxCheckManager.InputBoxEmptyCheck(ref clanModel);

            if (!String.IsNullOrEmpty(warning))
            {
                new NotifyView("警告", "發現未填入或未選取的欄位：\n\n" + warning + "\n請再次檢查是否將資訊填入。").Show();
            }
            else
            {
                HttpStatusCode statusCode = new DiscordWebhookManager().Push(ref clanModel,
                                                                                webhookID,
                                                                                webhookToken,
                                                                                clanName,
                                                                                clanColor,
                                                                                clanPictureUrl,
                                                                                discordTagroleID);
                
                if (statusCode == HttpStatusCode.NoContent || statusCode == HttpStatusCode.OK)
                {
                    new NotifyView("提示", "已發佈至指定頻道！").Show();
                }
                else
                {
                    new NotifyView("提示",
                        "發布失敗！\n請檢查網路是否連上，或資訊有無正確填入。\n" + $"Status Code: {statusCode}")
                        .Show();
                }
            }

            btnSavePublish.Enabled = true;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutView("關於").Show();
        }
    }
}
