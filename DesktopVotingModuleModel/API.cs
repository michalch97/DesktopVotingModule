using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

//https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request
//https://stackoverflow.com/questions/35907642/custom-header-to-httpclient-request/35910012
//https://stackoverflow.com/questions/5725430/http-test-server-accepting-get-post-requests
//https://github.com/kpilcicki/io-passthrough-api
namespace DesktopVotingModuleModel
{
    public static class API
    {
        private static readonly string server = "http://85.89.190.151:3010";
        private static readonly string resultsServer = "http://85.89.190.151:5905";
        private static readonly HttpClient client = new HttpClient();
        public static async Task<bool> LoginAsync(User user)
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
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            String responseString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
            user.Token = values["token"];
            return true;
        }

        public static async Task<ObservableCollection<Ballot>> GetBallots(User user)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(server + "/ballot"),
                Headers =
                {
                    {HttpRequestHeader.Authorization.ToString(),"Bearer " + user.Token}
                }
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            String responseString = await response.Content.ReadAsStringAsync();
            ObservableCollection<Ballot> ballots = JsonConvert.DeserializeObject<ObservableCollection<Ballot>>(responseString);

            return ballots;
        }

        public static async Task<ObservableCollection<Candidate>> GetCandidateNamesForBallot(Ballot ballot, User user)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(server + "/ballot/" + ballot.Id),
                Headers =
                {
                    {HttpRequestHeader.Authorization.ToString(),"Bearer " + user.Token}
                }
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            String responseString = await response.Content.ReadAsStringAsync();
            ObservableCollection<Candidate> values = JsonConvert.DeserializeObject<ObservableCollection<Candidate>>(responseString);
            return values;
        }

        public static async Task<bool> Vote(Ballot ballot, Candidate candidate, User user)
        {
            string content =
                "{"
                + "\"ballotId\": " + ballot.Id + ","
                + "\"candidateId\": " + candidate.Id +
                "}";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(server + "/vote"),
                Headers =
                {
                    {HttpRequestHeader.ContentType.ToString(),"application/json"},
                    {HttpRequestHeader.Authorization.ToString(),"Bearer " + user.Token}
                },
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.Created)
            {
                return false;
            }

            return true;
        }

        public static async Task GetResultsImage(Ballot ballot, string pathToSave)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(resultsServer + "/datavisualization/ballotGraph/" + ballot.Id)
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();
            using (Image image = Image.FromStream(new MemoryStream(responseBytes)))
            {
                image.Save(pathToSave + "resultsID" + ballot.Id + ".png", ImageFormat.Png);
            }
        }
    }
}