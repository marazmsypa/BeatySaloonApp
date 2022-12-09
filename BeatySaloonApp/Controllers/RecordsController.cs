using BeatySaloonApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BeatySaloonApp.Controllers
{
    public class RecordsController
    {
         /// <summary>
        /// получить пользлвателей
        /// </summary>
        

        /// <returns></returns>
        public Records GetRecord(string date, string time)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = Manager.RootUrl + "ClientRecords/" + date + "/" + time;
                HttpResponseMessage response = client.GetAsync($"{url}").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<Records>(content.Result);
                return answer;
            }
        }
       
        /// <summary>
        /// регистрация
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddRecord(Records record)
        {
            string jsonStr = JsonConvert.SerializeObject(record);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                string query = $"{Manager.RootUrl}ClientRecords";               
                HttpResponseMessage response = client.PostAsync(query, byteContent).Result;
                return response.IsSuccessStatusCode;
            }
        }
        /// <summary>
        /// нахождение всех записей
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Records> GetAllRecords()
        {           
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}ClientRecords").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Records>>(content.Result);
                return answer;

            }

        }
    }
}
