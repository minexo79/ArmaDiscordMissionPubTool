using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordMissionPubTool
{
    public partial class MainForm : Form
    {
        private ClanJsonData _clanJsonData;

        public MainForm()
        {
            InitializeComponent();

            _clanJsonData = new ClanJsonData();
        }

        private string packageWarningMessage()
        {
            // package empty message
            string warning = "";

            if (String.IsNullOrEmpty(tbBeginTime.Text))
                warning += "．整裝開始時間\n";
            if (String.IsNullOrEmpty(tbEndTime.Text))
                warning += "．整裝結束時間\n";
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
            if (!rbMorning.IsDisposed && !rbDay.IsDisposed && !rbAfternoon.IsDisposed && !rbMidnight.IsDisposed)
                warning += "．作戰模式\n";
            if (String.IsNullOrEmpty(tbMissionMap.Text))
                warning += "．任務地圖\n";
            if (String.IsNullOrEmpty(tbPlayer.Text))
                warning += "．我方資訊\n";
            if (String.IsNullOrEmpty(tbEnemy.Text))
                warning += "．敵方資訊\n";
            if (String.IsNullOrEmpty(tbMissionTarget.Text))
                warning += "．任務目標\n";
            if (String.IsNullOrEmpty(tbCommit.Text))
                warning += "．備註\n";
            if (String.IsNullOrEmpty(tbModList.Text))
                warning += "．模組清單\n";

            return warning;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dpDate.Value = DateTime.Now;
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            string warning = packageWarningMessage();

            if (!String.IsNullOrEmpty(warning))
            {
                NotifyForm notifyForm = new NotifyForm
                    ("提醒",
                    "發現未填入或者未選取的必要資訊：\n\n" +
                    warning +
                    "\n請再次檢查是否填入。");

                notifyForm.Text = "警告";

                notifyForm.Show();
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
