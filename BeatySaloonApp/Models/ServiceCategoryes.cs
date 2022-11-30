using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatySaloonApp.Models
{
    public class ServiceCategoryes
    {
        [JsonProperty("categoryId")]
            public int CategoryId { get; set; }
        [JsonProperty("categoryTitle")]
        public string CategoryTitle { get; set; }
        [JsonProperty("categoryImage")]
        public byte[] CategoryImage { get; set; }
        


    }
}
