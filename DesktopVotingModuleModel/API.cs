﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        //private static readonly string server = "https://204412ff-e052-4d36-aae4-4f3488ac1cc1.mock.pstmn.io";
        private static readonly string server = "https://19dc8421-2b25-4aeb-ab85-18cd233ef2a2.mock.pstmn.io";
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
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }
            String responseString = await response.Content.ReadAsStringAsync();
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
                RequestUri = new Uri(server + "/ballot/" + ballot.id),
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

        public static async Task Vote(Ballot ballot, Candidate candidate, User user)
        {
            string content =
                "{"
                + "\"ballotId\": " + ballot.id + ","
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
                Content = new StringContent(content)
            };
            HttpResponseMessage response = client.SendAsync(httpRequestMessage).Result;
            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}