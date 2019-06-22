using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using movie_api.Models;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json;
using System;

namespace movie_api.Data
{
    public class MovieSource : IMovieSource
    {
        private readonly IConfiguration _config;
        private const string URL = "http://www.omdbapi.com/?apikey=";
        private string _ApiKey;

        public MovieSource(IConfiguration config)
        {
           _config = config;
           _ApiKey = config.GetValue<String>("MySettings:MovieSource");
        }
        public  T GetMovie<T>(string id,string title)
        {
           var uri = string.Format("{0}{1}&i={2}&t={3}" , URL, _ApiKey, id, title);
           var client = new RestClient(uri);
           var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json }; 
           var result = GetResult<T>(client, request);
      
           return result;
        }
        private T GetResult<T>(RestClient client, RestRequest request)
        {
            //client üzerinden requesti servise yolla ve
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}