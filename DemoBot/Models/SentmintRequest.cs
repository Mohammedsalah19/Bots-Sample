using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBot.Models
{
    public class SentmintRequest
    {
        [JsonProperty(PropertyName = "documents")]
        public IEnumerable<DocumentRequest> Documents { get; set; }



    }
}