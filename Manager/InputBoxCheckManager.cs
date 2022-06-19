using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordMissionPubTool.Models;

namespace DiscordMissionPubTool.Manager
{
    public static class InputBoxCheckManager
    {
        public static string InputBoxEmptyCheck(ref ClanModel clanModel)
        {
            // package empty message
            string warning = "";

            if (String.IsNullOrEmpty(clanModel.ClanMissionAuthor))
                warning += "．任務作者\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionReadyTime))
                warning += "．整裝時間\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionStartTime))
                warning += "．作戰時間\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionCall))
                warning += "．任務代號\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionCloth))
                warning += "．任務服裝\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionWeapon))
                warning += "．武器限制\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionSupply))
                warning += "．任務補給\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionRevive))
                warning += "．重生機制\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionTime))
                warning += "．作戰模式\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionMap))
                warning += "．任務地圖\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionPlayer))
                warning += "．我方資訊\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionEnemy))
                warning += "．敵方資訊\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionTarget))
                warning += "．任務目標\n";
            if (String.IsNullOrEmpty(clanModel.ClanMissionModList))
                warning += "．模組清單\n";

            return warning;
        }
    }
}
