using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestUser
{
    public class NetManager
    {
        private static HttpClient client = new HttpClient();

     
        public static async Task<T> Get<T>(String controller)
        {
            client.BaseAddress = new Uri("https://localhost:7196/");
            HttpResponseMessage response = await client.GetAsync(controller);
            var data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            
            return data;
        }
        
        public static async Task<List<T>> GetAll<T>(String controller)
        {
            client.BaseAddress = new Uri("https://localhost:7196/");
            HttpResponseMessage response = await client.GetAsync(controller);
            List<T> data = JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync()).ToList();
            
            return data;
        }

        public static async Task<HttpResponseMessage> Post<T>(String controller, T data)
        {
            client.BaseAddress = new Uri("https://localhost:7196/");
            var jsonData = JsonConvert.SerializeObject(data);
            var response = await client.PostAsync(controller, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }
        
        public static async Task<HttpResponseMessage> Delete<T>(String controller)
        {
            client.BaseAddress = new Uri("https://localhost:7196/");
            var response = await client.DeleteAsync(controller);
            return response;
        }
    }
}