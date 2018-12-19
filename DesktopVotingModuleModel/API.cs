using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                Content = new StringContent(content)
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            String responseString = await response.Content.ReadAsStringAsync();
            //String responseString =
            //    "{\"token\": \"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOjIsImlhdCI6MTU0NDk3NDQzNywiZXhwIjoxNTQ0OTc2MjM3fQ.tIZhxcjDw5WMFfCL-VHtXNVHejpVpUjjrqhhOOJv3E0\"}";
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
            if (values["token"].Length != 0)
            {
                user.Token = values["token"];
                return true;
            }
            return false;
        }

        public static async Task<Ballot> GetBallots(User user)
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
            //String responseString = "[{ \"state\": true,\"candidatesSize\": \"2\",\"id\": 0}]";
            List<Ballot> ballots = JsonConvert.DeserializeObject<List<Ballot>>(responseString);
            //Zakładam, że mamy jedno głosowanie w tym samym czasie, później można to poprawić dodając wybór głosowaia w panelu głosowania
            return ballots[0];
        }

        public static async Task<ObservableCollection<Candidate>> GetCandidateNamesForBallot(Ballot ballot, User user)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(server + "/ballot/" + ballot.id),
                Headers =
                {
                    {HttpRequestHeader.Authorization.ToString(),"Bearer " + user.Token}
                }
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            String responseString = await response.Content.ReadAsStringAsync();
            //String responseString = "[{\"name\": \"A\",\"id\": 0},{\"name\": \"B\",\"id\": 1}]";
            ObservableCollection<Candidate> values = JsonConvert.DeserializeObject<ObservableCollection<Candidate>>(responseString);
            return values;
        }

        public static async Task Vote(Ballot ballot, Candidate candidate, User user)
        {
            //Content - czy potrzebne voterId
            string content =
                "{"
                + "\"ballotId\": " + ballot.id + ","
                + "\"candidateId\": " +  candidate.Id +
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
                Content = new StringContent(content)
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}