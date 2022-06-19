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
        static ClanModel clanModel = new ClanModel();

        static string webhookUrl;
        static string clanName;
        static string clanColor;
        static string clanPictureUrl;
        static string discordTagroleID;

        public MainView()
        {
            InitializeComponent();

            dpDate.Value = DateTime.Now;

            reloadProperties();
        }

        public static void reloadProperties()
        {
            webhookUrl          = Properties.Settings.Default.DiscordWebhookUrl;
            clanName            = Properties.Settings.Default.ClanName;
            clanColor           = Properties.Settings.Default.ClanColor;
            clanPictureUrl      = Properties.Settings.Default.ClanPictureUrl;
            discordTagroleID    = Properties.Settings.Default.DiscordTagRoleID;
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
                                                                                webhookUrl,
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

        private void btnSetting_Click(object sender, EventArgs e)
        {
            new SettingView().Show();
        }

        private void btnPullMessage_Click(object sender, EventArgs e)
        {
            new PullView(webhookUrl).Show();
        }
    }
}
