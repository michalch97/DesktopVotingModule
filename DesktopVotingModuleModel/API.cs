using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

//https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request
//https://stackoverflow.com/questions/35907642/custom-header-to-httpclient-request/35910012
//https://stackoverflow.com/questions/5725430/http-test-server-accepting-get-post-requests
namespace DesktopVotingModuleModel
{
    public static class API
    {
        private static readonly string server = "server";
        private static readonly HttpClient client = new HttpClient();
        public static async System.Threading.Tasks.Task<bool> LoginAsync(User user)
        {
            string content =
                "{"
                + "\"login\": " + "\"" + user.Login + "\","
                + "\"password\": " + "\"" + user.Password + "\"" +
                "}";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(server + "/login"),
                Headers =
                {
                    {HttpRequestHeader.ContentType.ToString(),"application/json"}
                },
                Content = new StringContent(content)
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            String responseString = await response.Content.ReadAsStringAsync();
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
            if (values["token"].Length != 0)
            {
                user.Token = values["token"];
                return true;
            }
            return false;
        }
    }
}