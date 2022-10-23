using DiscordMissionPubTool.Manager;
using System.Text.Json;
using System.Dynamic;
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
using DiscordMissionPubTool.Models;
using System.Text.Json.Serialization;

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

            DiscordWebhookReturnModel model = JsonSerializer.Deserialize<DiscordWebhookReturnModel>(readString);

            btnOK.Enabled = true;
        }
    }
}
