using BeatySaloonApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeatySaloonApp.Controllers
{
    public class UsersController
    {
        /// <summary>
        /// получить пользлвателей
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Users GetUser(string login, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = Manager.RootUrl + "Users/" + login + "/" + password;
                HttpResponseMessage response = client.GetAsync($"{url}").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<Users>(content.Result);
                return answer;
            }
        }
        /// <summary>
        /// регистрация
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(Users user)
        {
            using (HttpClient client = new HttpClient())
            {
                string query = $"{Manager.RootUrl}Users"; 
                Console.WriteLine(query);
                HttpResponseMessage response = client.PostAsync(query, null).Result;
                return response.IsSuccessStatusCode;
            }
        }
    }
}
