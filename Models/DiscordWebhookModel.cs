using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMissionPubTool.Models
{
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

    public class DiscordWebhookModel
    {
        public string username { get; set; }
        public string avatar_url { get; set; }
        public string content { get; set; }
        public Embed[] embeds { get; set; }

        public DiscordWebhookModel(ref ClanModel model,
                                        string clanName,
                                        string clanColor,
                                        string clanPictureUrl,
                                        string roleID,
                                        string missionAuthor)
        {
            this.username = "任務發佈";

            this.avatar_url = "https://cdn.icon-icons.com/icons2/3433/PNG/512/war_army_soldier_icon_218816.png";

            if(!String.IsNullOrEmpty(roleID))
            {
                // more than one role
                if (roleID.IndexOf(',') > -1)
                {
                    string[] role = roleID.Split(',');

                    foreach(string _role in role)
                    {
                        this.content += $"<@&{_role}>";
                    }
                }
                else
                    this.content = $"<@&{roleID}>";
            }

            this.embeds = new Embed[1];
            this.embeds[0] = new Embed();

            this.embeds[0].title = $"任務代號：{model.ClanMissionCall}";

            this.embeds[0].color = Int32.Parse(clanColor, NumberStyles.HexNumber);

            if (!String.IsNullOrEmpty(missionAuthor))
            {
                this.embeds[0].author.name = "任務作者：" + missionAuthor;
            }

            this.embeds[0].thumbnail.url = (!String.IsNullOrEmpty(clanPictureUrl)) ? clanPictureUrl : "";

            this.embeds[0].footer.text = clanName;

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務日期",
                value = model.ClanMissionDate.ToShortDateString(),
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "整裝開放時間",
                value = model.ClanMissionReadyTime,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "開始作戰時間",
                value = model.ClanMissionStartTime,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務服裝",
                value = model.ClanMissionCloth,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "武器限制",
                value = model.ClanMissionWeapon,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "重生機制",
                value = model.ClanMissionRevive,
                inline = false
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "作戰時間",
                value = model.ClanMissionTime,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "我方資訊",
                value = model.ClanMissionPlayer,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "敵方資訊",
                value = model.ClanMissionEnemy,
                inline = true
            });

            this.embeds[0].fields.Add(new Fields()
            {
                name = "任務目標",
                value = model.ClanMissionTarget,
                inline = false
            });

            if (!String.IsNullOrEmpty(model.ClanMissionMap))
            {
                this.embeds[0].fields.Add(new Fields()
                {
                    name = "任務地圖",
                    value = model.ClanMissionMap,
                    inline = false
                });
            }

            if (!String.IsNullOrEmpty(model.ClanMissionSupply))
            {
                this.embeds[0].fields.Add(new Fields()
                {
                    name = "任務補給",
                    value = model.ClanMissionSupply,
                    inline = false
                });
            }

            if (!String.IsNullOrEmpty(model.ClanMissionCommit))
            {
                this.embeds[0].fields.Add(new Fields()
                {
                    name = "備註",
                    value = model.ClanMissionCommit,
                    inline = false
                });
            }

            this.embeds[0].fields.Add(new Fields()
            {
                name = "模組清單",
                value = (!String.IsNullOrEmpty(model.ClanMissionModList)) ? model.ClanMissionModList : "無",
                inline = false
            });
        }
    }
}
