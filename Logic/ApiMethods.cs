using MyOnlineStore.Interfaces;
using MyOnlineStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyOnlineStore.Logic
{
    public class ApiMethods : IApiMethods
    {
        private readonly ApplicationDbContext _context;

        public ApiMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StoreItems>> GetStoreItems()
        {
            string apiUrl = "http://localhost:50632/api/Store";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<StoreItems>>(result);

                }
                return new List<StoreItems>();
            }
        }

    }
}
