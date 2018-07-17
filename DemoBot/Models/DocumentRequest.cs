using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace DemoBot.Models
{
    public class DocumentRequest
    {
        [JsonProperty(PropertyName ="id")]            
         public int ID { get; set; }
        [JsonProperty(PropertyName = "text")]

        public string Text { get; set; }

    }
}