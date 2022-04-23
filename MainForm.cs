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

namespace DiscordMissionPubTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string packageWarningMessage()
        {
            // package empty message
            string warning = "";

            if (String.IsNullOrEmpty(tbReadyTime.Text))
                warning += "．整裝時間\n";
            if (String.IsNullOrEmpty(tbStartTime.Text))
                warning += "．作戰時間\n";
            if (String.IsNullOrEmpty(tbMissionCall.Text))
                warning += "．任務代號\n";
            if (String.IsNullOrEmpty(tbMissionCloth.Text))
                warning += "．任務服裝\n";
            if (String.IsNullOrEmpty(tbMissionWeapon.Text))
                warning += "．武器限制\n";
            if (String.IsNullOrEmpty(tbMissionSupply.Text))
                warning += "．任務補給\n";
            if (String.IsNullOrEmpty(tbMissionRevive.Text))
                warning += "．重生機制\n";
            if (!rbMorning.Checked && !rbDay.Checked && !rbAfternoon.Checked && !rbMidnight.Checked)
                warning += "．作戰模式\n";
            if (String.IsNullOrEmpty(tbMissionMap.Text))
                warning += "．任務地圖\n";
            if (String.IsNullOrEmpty(tbPlayer.Text))
                warning += "．我方資訊\n";
            if (String.IsNullOrEmpty(tbEnemy.Text))
                warning += "．敵方資訊\n";
            if (String.IsNullOrEmpty(tbMissionTarget.Text))
                warning += "．任務目標\n";
            if (String.IsNullOrEmpty(tbModList.Text))
                warning += "．模組清單\n";

            return warning;
        }

        private ClanData packageJsonData()
        {
            ClanData _clanJsonData = new ClanData();

            _clanJsonData.ClanMissionDate = dpDate.Value;
            _clanJsonData.ClanMissionReadyTime = tbReadyTime.Text;
            _clanJsonData.ClanMissionStartTime = tbStartTime.Text;
            _clanJsonData.ClanMissionCall = tbMissionCall.Text;
            _clanJsonData.ClanMissionCloth = tbMissionCloth.Text;
            _clanJsonData.ClanMissionWeapon = tbMissionWeapon.Text;
            _clanJsonData.ClanMissionSupply = tbMissionSupply.Text;
            _clanJsonData.ClanMissionRevive = tbMissionRevive.Text;
            _clanJsonData.ClanMissionMap = tbMissionMap.Text;

            if (rbMorning.Checked)
                _clanJsonData.ClanMissionTime = "早晨";
            else if (rbDay.Checked)
                _clanJsonData.ClanMissionTime = "中午";
            else if (rbAfternoon.Checked)
                _clanJsonData.ClanMissionTime = "傍晚";
            else if (rbMidnight.Checked)
                _clanJsonData.ClanMissionTime = "半夜";

            _clanJsonData.ClanMissionPlayer = tbPlayer.Text;
            _clanJsonData.ClanMissionEnemy = tbEnemy.Text;
            _clanJsonData.ClanMissionTarget = tbMissionTarget.Text;
            _clanJsonData.ClanMissionModList = tbModList.Text;

            if(!String.IsNullOrEmpty(tbCommit.Text))
                _clanJsonData.ClanMissionCommit = tbCommit.Text;

            return _clanJsonData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dpDate.Value = DateTime.Now;
        }

        private async void btnPublish_Click(object sender, EventArgs e)
        {
            string warning = packageWarningMessage();

            if (!String.IsNullOrEmpty(warning))
            {
                NotifyForm notifyForm = new NotifyForm
                    ("警告", "發現未填入或未選取的欄位：\n\n" + warning + "\n請再次檢查是否將資訊填入。");

                notifyForm.Show();
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    string webhookID = Properties.Settings.Default.DiscordWebhookID;
                    string webhookToken = Properties.Settings.Default.DiscordWebhookToken;
                    NotifyForm notifyForm;

                    ClanData data = packageJsonData();

                    WebhookBody webhookBody = new WebhookBody(data);

                    string body = JsonSerializer.Serialize(webhookBody);

                    client.BaseAddress = new Uri("https://discord.com/api/webhooks/");

                    StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                    HttpResponseMessage responseMessage = 
                        await client.PostAsync($"{webhookID}/{webhookToken}", content);

                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent ||
                        responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        notifyForm = new NotifyForm("提示", "已發佈至指定頻道！");
                    } else
                    {
                        notifyForm = new NotifyForm("提示", "發布失敗！\n請檢查網路是否連上，或資訊有無正確填入。\n" + 
                            $"Http Status Code：{responseMessage.StatusCode}");
                    }

                    notifyForm.Show();
                }
            }
        }

        private void btnAboutForm_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Text = "關於";
            aboutForm.Show();
        }
    }
}
