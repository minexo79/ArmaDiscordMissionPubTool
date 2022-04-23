using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DiscordMissionPubTool
{
    /// <summary>
    /// Clan Data
    /// </summary>
    /// 
    public class ClanData
    {
        public DateTime ClanMissionDate { get; set; }
        public string ClanMissionReadyTime { get; set; }
        public string ClanMissionStartTime { get; set; }
        public string ClanMissionCall { get; set; }
        public string ClanMissionCloth { get; set; }
        public string ClanMissionWeapon { get; set; }
        public string ClanMissionSupply { get; set; }
        public string ClanMissionRevive { get; set; }
        public string ClanMissionTime { get; set; }
        public string ClanMissionMap { get; set; }
        public string ClanMissionPlayer { get; set; }
        public string ClanMissionEnemy { get; set; }
        public string ClanMissionTarget { get; set; }
        public string ClanMissionCommit { get; set; }
        public string ClanMissionModList { get; set; }
    }

    /// <summary>
    /// Discord WebHook Json
    /// </summary>

    public class Fields
    {
        public string name { get; set; }
        public string value { get; set; }
        public Boolean inline { get; set; }
    }
    public class Thumbnail
    {
        public string url { get; set; }
    }
    public class Footer
    {
        public string text { get; set; }
    }
    public class Author
    {
        public string name { get; set; }
    }
    public class Embed
    {
        public string title { get; set; }
        public int color { get; set; }
        public Author author { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Footer footer { get; set; }
        public List<Fields> fields { get; set; }

        public Embed()
        {
            thumbnail = new Thumbnail();
            footer = new Footer();
            fields = new List<Fields>();
            author = new Author();
        }
    }
    public class WebhookBody
    {
        public string username { get; set; }
        public string avatar_url { get; set; }
        public List<Embed> embeds { get; set; }

        public WebhookBody(ClanData data)
        {
            this.username = "任務發佈";

            this.avatar_url = 
                "https://cdn.icon-icons.com/icons2/3433/PNG/512/war_army_soldier_icon_218816.png";

            this.embeds = new List<Embed>();
            this.embeds.Add(new Embed());

            this.embeds[0].title = $"任務代號：{data.ClanMissionCall}";
            this.embeds[0].color = Int32.Parse(Properties.Settings.Default.ClanColor, NumberStyles.HexNumber);
            this.embeds[0].author.name = Properties.Settings.Default.ClanName + "任務";
            this.embeds[0].thumbnail.url
                = (!String.IsNullOrEmpty(Properties.Settings.Default.ClanPictureUrl)) 
                ? Properties.Settings.Default.ClanPictureUrl : "";
            this.embeds[0].footer.text = Properties.Settings.Default.ClanName;

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務日期",
                value = data.ClanMissionDate.ToShortDateString(),
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "整裝開放時間",
                value = data.ClanMissionReadyTime,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "開始作戰時間",
                value = data.ClanMissionStartTime,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務服裝",
                value = data.ClanMissionCloth,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "武器限制",
                value = data.ClanMissionWeapon,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務補給",
                value = data.ClanMissionSupply,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "重生機制",
                value = data.ClanMissionRevive,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "作戰時間",
                value = data.ClanMissionTime,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務地圖",
                value = data.ClanMissionMap,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "我方資訊",
                value = data.ClanMissionPlayer,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "敵方資訊",
                value = data.ClanMissionEnemy,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務目標",
                value = data.ClanMissionTarget,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "備註",
                value = (String.IsNullOrEmpty(data.ClanMissionCommit)) ? "無" : data.ClanMissionCommit,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "模組清單",
                value = data.ClanMissionModList,
                inline = false
            });
        }
    }
}
