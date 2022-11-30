using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using BeatySaloonApp.Models;
using Newtonsoft.Json;

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
                HttpResponseMessage response = client.GetAsync($"http://127.0.0.1:50710/api/ServiceCategoryes").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<ServiceCategoryes>>(content.Result);
                return answer;

            }

        }
    }
}
