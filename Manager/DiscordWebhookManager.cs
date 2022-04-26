using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DiscordMissionPubTool.Models;
using DiscordMissionPubTool.Services;

namespace DiscordMissionPubTool.Manager
{
    public class DiscordWebhookManager
    {
        private DiscordWebhookModel PackageBodyPayload(ref ClanModel clanModel, string clanName, string clanColor, string clanPictureUrl, string TagRoleID)
        {
            return new DiscordWebhookModel(ref clanModel, clanName, clanColor, clanPictureUrl, TagRoleID);
        }

        public int Get()
        {
            return new DiscordWebhookServices().Get();
        }

        public HttpStatusCode Push(ref ClanModel clanModel, string WebhookID, string WebhookToken, string clanName, string clanColor, string clanPictureUrl, string TagRoleID)
        {
            DiscordWebhookModel webhookBodyPayload = PackageBodyPayload(ref clanModel, clanName, clanColor, clanPictureUrl, TagRoleID);

            return new DiscordWebhookServices().Push(webhookBodyPayload, WebhookID, WebhookToken);
        }
    }
}
