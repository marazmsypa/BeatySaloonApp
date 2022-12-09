using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatySaloonApp.Models
{
    public class Services
    {  
            public int id { get; set; }
            public string title { get; set; }
            public double cost { get; set; }
            public int durationInSeconds { get; set; }
            public string description { get; set; }
            public int discount { get; set; }
            public string mainImagePath { get; set; }
            public int categoryId { get; set; }
                  
    }
}
