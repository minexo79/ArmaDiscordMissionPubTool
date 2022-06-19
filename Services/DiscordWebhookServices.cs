using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using DiscordMissionPubTool.Models;
using System.Net;

namespace DiscordMissionPubTool.Services
{
    public class DiscordWebhookServices
    {
        public HttpContent Get(string webhookUrl, string MessageID)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(webhookUrl + "/messages/" + MessageID);

                HttpResponseMessage responseMessage =
                                    client.GetAsync("").GetAwaiter().GetResult();

                return responseMessage.Content;
            }
        }

        public HttpStatusCode Push(DiscordWebhookModel webhookBody, string webhookUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string body = JsonSerializer.Serialize(webhookBody);

                client.BaseAddress = new Uri(webhookUrl);

                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage =
                    client.PostAsync("", content).GetAwaiter().GetResult();

                return responseMessage.StatusCode;
            }
        }
    }
}
