using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaLTaiizor.Controls;
using DiscordMissionPubTool.Models;
using System.Windows.Forms;

namespace DiscordMissionPubTool.Services
{
    public class OsOperationServices
    {
        public static void PackageClanModel(ref ClanModel clanModel, ref Object sender)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {
                case "dpDate":
                    clanModel.ClanMissionDate = ((PoisonDateTime)sender).Value;
                    break;

                case "tbReadyTime":
                    clanModel.ClanMissionReadyTime = ((DungeonTextBox)sender).Text;
                    break;

                case "tbStartTime":
                    clanModel.ClanMissionStartTime = ((DungeonTextBox)sender).Text;
                    break;

                case "tbMissionCall":
                    clanModel.ClanMissionCall = ((DungeonTextBox)sender).Text;
                    break;

                case "tbMissionCloth":
                    clanModel.ClanMissionCloth = ((DungeonTextBox)sender).Text;
                    break;

                case "tbMissionWeapon":
                    clanModel.ClanMissionWeapon = ((DungeonTextBox)sender).Text;
                    break;

                case "tbMissionSupply":
                    clanModel.ClanMissionSupply = ((DungeonTextBox)sender).Text;
                    break;

                case "tbMissionRevive":
                    clanModel.ClanMissionRevive = ((DungeonTextBox)sender).Text;
                    break;

                case "rbMorning":
                case "rbDay":
                case "rbAfternoon":
                case "rbMidnight":
                    clanModel.ClanMissionTime = ((RibbonRadioButton)sender).Text;
                    break;

                case "tbMissionMap":
                    clanModel.ClanMissionMap = ((DungeonTextBox)sender).Text;
                    break;

                case "tbPlayer":
                    clanModel.ClanMissionPlayer = ((DungeonTextBox)sender).Text;
                    break;

                case "tbEnemy":
                    clanModel.ClanMissionEnemy = ((DungeonTextBox)sender).Text;
                    break;

                case "tbTarget":
                    clanModel.ClanMissionTarget = ((DungeonTextBox)sender).Text;
                    break;

                case "tbCommit":
                    clanModel.ClanMissionCommit = ((DungeonTextBox)sender).Text;
                    break;

                case "tbModList":
                    clanModel.ClanMissionModList = ((DungeonTextBox)sender).Text;
                    break;
            }
        }

        public static void OpenBrowser(string Url)
        {
            System.Diagnostics.Process.Start(Url);
        }
    }
}
