using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DiscordMissionPubTool
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Boolean warnMsg = false;

            if (String.IsNullOrEmpty(Properties.Settings.Default.DiscordChannelID))
                warnMsg = true;
            if (String.IsNullOrEmpty(Properties.Settings.Default.DiscordWebhookToken))
                warnMsg = true;
            if (String.IsNullOrEmpty(Properties.Settings.Default.ClanName))
                warnMsg = true;

            if (warnMsg)
            {
                MessageBox.Show("設定檔內必要填入的的值為空，請檢查是否填入！",
                    "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
