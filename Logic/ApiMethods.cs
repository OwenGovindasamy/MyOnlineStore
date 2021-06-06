using Microsoft.Extensions.Configuration;
using MyOnlineStore.Interfaces;
using MyOnlineStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyOnlineStore.Logic
{
    public class ApiMethods : IApiMethods
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _mySettings;

        public ApiMethods(ApplicationDbContext context, IConfiguration mySettings)
        {
            _context = context;
            _mySettings = mySettings;
        }

        public async Task<List<StoreItems>> PostWithToken(string authorizeToken)
        {
            string responseObj = string.Empty;

            using (var client = new HttpClient())
            {

                string authorization = authorizeToken;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
                client.BaseAddress = new Uri("http://localhost:50632/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = await client.GetAsync("api/Store").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<StoreItems>>(result);

                }
                return new List<StoreItems>();
            }
        }

        public async Task<UserToken> GetToken()
        {
            string email = _mySettings.GetValue<string>("AppConfig:Email");
            string password = _mySettings.GetValue<string>("AppConfig:Password");

            try
            {
                string apiUrl = "http://localhost:5000/api/User/Login";

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Email", email);
                    client.DefaultRequestHeaders.Add("Password", password);
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<UserToken>(result);
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<UserToken>(response.StatusCode.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception("Unable to login to Api" + e);
            }
        }
    
    }
}
