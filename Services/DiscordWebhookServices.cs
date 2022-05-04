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
        public int Get()
        {
            return 0;
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
