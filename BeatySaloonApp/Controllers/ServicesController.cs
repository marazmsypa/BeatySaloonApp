using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using BeatySaloonApp.Models;
using System.Net.Http.Headers;

namespace BeatySaloonApp.Controllers
{
    public class ServicesController
    {
        /// <summary>
        /// выбор сервисов по категории
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Services> GetServices(int categoryId)

        {
            string category = categoryId.ToString();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}Services/{category}").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Services>>(content.Result);
                return answer;

            }

        }
        public bool AddService(Services services)
        {
            string jsonStr = JsonConvert.SerializeObject(services);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                string query = $"{Manager.RootUrl}Services";
                HttpResponseMessage response = client.PostAsync(query, byteContent).Result;
                return response.IsSuccessStatusCode;
            }
        }
    }
}
