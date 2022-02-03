using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryMobileApp.Utils
{
    internal static class RestService
    {
        private static HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("http://laboratoryapi.somee.com/api/")
        };
        public static async Task<T> GetAsync<T>(string uri)
        {
            var message = await _client.GetAsync(uri);

            var json = await message.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }


        public static async Task<T> DeleteAsync<T>(string uri)
        {
            var message = await _client.DeleteAsync(uri);
            var json = await message.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static async Task DeleteAsync(string uri)
        {
            var message = await _client.DeleteAsync(uri);
            message.EnsureSuccessStatusCode();
        }


        public static async Task<T> PostAsync<T>(string uri, object data)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.Default, "application/json");
            var message = await _client.PostAsync(uri, content);

            var json = await message.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static async Task PostAsync(string uri, object data)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.Default, "application/json");
            var message = await _client.PostAsync(uri, content);
            message.EnsureSuccessStatusCode();

        }

        public static async Task<T> PutAsync<T>(string uri, object data)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.Default, "application/json");
            var message = await _client.PutAsync(uri, content);
            var json = await message.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        
    }
}
