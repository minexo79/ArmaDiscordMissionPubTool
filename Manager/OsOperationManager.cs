using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordMissionPubTool.Models;
using DiscordMissionPubTool.Services;

namespace DiscordMissionPubTool.Manager
{
    public class OsOperationManager
    {
        public static void PackageClanModel(ref ClanModel clanModel, ref Object sender)
        {
            OsOperationServices.PackageClanModel(ref clanModel, ref sender);
        }

        public static void OpenBrowser(string Url)
        {
            OsOperationServices.OpenBrowser(Url);
        }
    }
}
