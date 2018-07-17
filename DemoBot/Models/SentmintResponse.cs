using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBot.Models
{
    public class SentmintResponse
    {

        [JsonProperty(PropertyName = "documents")]
        public IEnumerable<DocumentResponse> Documents { get; set; }
    }
}