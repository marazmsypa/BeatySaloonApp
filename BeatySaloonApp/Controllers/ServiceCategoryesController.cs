using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using BeatySaloonApp.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BeatySaloonApp.Controllers
{
    public class ServiceCategoryesController
    {
        /// <summary>
        /// выводит информацию об категориях
        /// </summary>
        /// <returns>
        /// коллекция ServiceCategoryes
        /// </returns>
        public List<ServiceCategoryes> GetCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}ServiceCategoryes").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<ServiceCategoryes>>(content.Result);
                return answer;

            }

        }
        /// <summary>
        /// Добавление категории 
        /// </summary>
        /// <param name="serviceCategoryes"></param>
        /// <returns></returns>
        public bool AddCaterogy(ServiceCategoryes serviceCategoryes)
        {
            string jsonStr = JsonConvert.SerializeObject(serviceCategoryes);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                string query = $"{Manager.RootUrl}ServiceCategoryes";
                HttpResponseMessage response = client.PostAsync(query, byteContent).Result;
                return response.IsSuccessStatusCode;
            }
        }

    }
}
