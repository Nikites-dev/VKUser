using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestUser.Models
{
    public class WebClientManager
    {
        private static HttpClient client = new HttpClient();
        
        
        

       public async void Start()
       {
           client.BaseAddress = new Uri("https://localhost:7196/");
           HttpResponseMessage response = await client.GetAsync($"users/get/{1}");

           String responseJson = await response.Content.ReadAsStringAsync();
           
           
           User myObj = JsonConvert.DeserializeObject<User>(responseJson);
           
           

           String str = myObj.Login;
       }
    }
}