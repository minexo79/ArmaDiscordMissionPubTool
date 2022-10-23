using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscordMissionPubTool.Models;
using DiscordMissionPubTool.Services;

namespace DiscordMissionPubTool.Manager
{
    public class DiscordWebhookManager
    {
        private DiscordWebhookModel PackageBodyPayload(ref ClanModel clanModel, 
                                                        string clanName, 
                                                        string clanColor, 
                                                        string clanPictureUrl, 
                                                        string TagRoleID,
                                                        string missionAuthor)
        {
            return new DiscordWebhookModel(ref clanModel,
                                            clanName,
                                            clanColor,
                                            clanPictureUrl,
                                            TagRoleID,
                                            missionAuthor);
        }

        public HttpContent Get(string WebhookUrl, string MessageID)
        {
            return new DiscordWebhookServices().Get(WebhookUrl, MessageID);
        }

        public HttpStatusCode Push(ref ClanModel clanModel,
                                    string WebhookUrl,
                                    string clanName,
                                    string clanColor,
                                    string clanPictureUrl,
                                    string TagRoleID,
                                    string missionAuthor)
        {
            DiscordWebhookModel webhookBodyPayload = PackageBodyPayload(ref clanModel,
                                                        clanName, clanColor, clanPictureUrl, TagRoleID, missionAuthor);

            return new DiscordWebhookServices().Push(webhookBodyPayload, WebhookUrl);
        }
    }
}
