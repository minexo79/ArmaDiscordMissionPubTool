using DiscordMissionPubTool.Manager;
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

namespace DiscordMissionPubTool
{
    public partial class PullView : Form
    {
        private string WebhookUrl { get; set; }

        public PullView(string webhookUrl)
        {
            InitializeComponent();

            this.WebhookUrl = webhookUrl;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;

            HttpContent content = new DiscordWebhookManager().Get(WebhookUrl, tbMessageID.Text);

            string readString = content.ReadAsStringAsync().GetAwaiter().GetResult();

            new NotifyView("提示", readString).Show();

            btnOK.Enabled = true;
        }
    }
}
