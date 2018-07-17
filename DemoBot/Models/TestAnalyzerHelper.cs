using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DemoBot.Models
{
    public class TestAnalyzerHelper
    {
        public static async Task<SentmintResponse>analyze (string text)
        {

            // constant for api
            const string endpointUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
            const string apiKey = "f79861a34f1f4f488529a45e40bcdfb2";

            // client format 
            var client = new HttpClient
            {
                DefaultRequestHeaders =
                {
                    {"Ocp-Apim-Subscription-Key", apiKey},
                    {"Accept","application/json" }
                }

            };
            // object of sentmint
            var sentmintReqObj = new SentmintRequest
            {
                Documents = new List<DocumentRequest>
                {
                    new DocumentRequest {ID=1,Text=text}
                }

            };

            //serialization (messege) from string to json 
            var serializion = JsonConvert.SerializeObject(sentmintReqObj);
            var postrequest = await client.PostAsync(endpointUrl, new StringContent(serializion, Encoding.UTF8, "Application/json"));

            //deserializtion json(messege) to string
            return JsonConvert.DeserializeObject<SentmintResponse>(await postrequest.Content.ReadAsStringAsync());

        }

    }
}