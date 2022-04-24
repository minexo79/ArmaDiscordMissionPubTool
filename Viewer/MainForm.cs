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
using System.Text.Json.Serialization;
using DiscordMissionPubTool.Services;
using DiscordMissionPubTool.Models;
using System.Threading;

namespace DiscordMissionPubTool
{
    public partial class MainForm : Form
    {
        ClanModel clanModel = new ClanModel();

        public MainForm()
        {
            InitializeComponent();

            dpDate.Value = DateTime.Now;
        }

        private void MainFormControl_ValueChanged(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch(controlName)
            {
                case "dpDate":
                    clanModel.ClanMissionDate = ((DateTimePicker)sender).Value;
                    break;

                case "tbReadyTime":
                    clanModel.ClanMissionReadyTime = ((TextBox)sender).Text;
                    break;

                case "tbStartTime":
                    clanModel.ClanMissionStartTime = ((TextBox)sender).Text;
                    break;

                case "tbMissionCall":
                    clanModel.ClanMissionCall = ((TextBox)sender).Text;
                    break;

                case "tbMissionCloth":
                    clanModel.ClanMissionCloth = ((TextBox)sender).Text;
                    break;

                case "tbMissionWeapon":
                    clanModel.ClanMissionWeapon = ((TextBox)sender).Text;
                    break;

                case "tbMissionSupply":
                    clanModel.ClanMissionSupply = ((TextBox)sender).Text;
                    break;

                case "tbMissionRevive":
                    clanModel.ClanMissionRevive = ((TextBox)sender).Text;
                    break;

                case "rbMorning":
                case "rbDay":
                case "rbAfternoon":
                case "rbMidnight":
                    clanModel.ClanMissionTime = ((RadioButton)sender).Text;
                    break;

                case "tbMissionMap":
                    clanModel.ClanMissionMap = ((TextBox)sender).Text;
                    break;

                case "tbPlayer":
                    clanModel.ClanMissionPlayer = ((TextBox)sender).Text;
                    break;

                case "tbEnemy":
                    clanModel.ClanMissionEnemy = ((TextBox)sender).Text;
                    break;

                case "tbTarget":
                    clanModel.ClanMissionTarget = ((TextBox)sender).Text;
                    break;

                case "tbModList":
                    clanModel.ClanMissionModList = ((TextBox)sender).Text;
                    break;

                case "tbCommit":
                    clanModel.ClanMissionCommit = ((TextBox)sender).Text;
                    break;
            }
        }

        private async void btnPublish_Click(object sender, EventArgs e)
        {
            string warning = EmptyCheck.InputBoxEmptyCheck(ref clanModel);

            if (!String.IsNullOrEmpty(warning))
            {
                new NotifyForm("警告", "發現未填入或未選取的欄位：\n\n" + warning + "\n請再次檢查是否將資訊填入。").Show();
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    string webhookID = Properties.Settings.Default.DiscordWebhookID;
                    string webhookToken = Properties.Settings.Default.DiscordWebhookToken;
                    string clanName = Properties.Settings.Default.ClanName;
                    string clanColor = Properties.Settings.Default.ClanColor;
                    string clanPictureUrl = Properties.Settings.Default.ClanPictureUrl;
                    string discordTagRoleID = Properties.Settings.Default.DiscordTagRoleID;

                    WebhookModel webhookBody = new WebhookModel(ref clanModel,
                                                                clanName,
                                                                clanColor,
                                                                clanPictureUrl,
                                                                discordTagRoleID);

                    string body = JsonSerializer.Serialize(webhookBody);

                    client.BaseAddress = new Uri("https://discord.com/api/webhooks/");

                    StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                    HttpResponseMessage responseMessage = 
                        await client.PostAsync($"{webhookID}/{webhookToken}", content);

                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent ||
                        responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        new NotifyForm("提示", "已發佈至指定頻道！").Show();
                    } 
                    else
                    {
                        new NotifyForm("提示", 
                            "發布失敗！\n請檢查網路是否連上，或資訊有無正確填入。\n" + $"Status Code：{responseMessage.StatusCode}")
                            .Show();
                    }
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutForm("關於").Show();
        }
    }
}
