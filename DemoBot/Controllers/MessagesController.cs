using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using DemoBot.Models;
using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.GetActivityType() == ActivityTypes.Message)
            {
                var mess = activity.Text;

                var connector = new ConnectorClient(new Uri(activity.ServiceUrl)); 
                

              //  var responses = await TestAnalyzerHelper.analyze(mess);

                var res = sreach(Convert.ToInt32( mess));
                var reAct = activity.CreateReply(res.ToString());

                //  var responsrMess = replyMessege(responses.Documents.First().Score);
                // var replyActivity = activity.CreateReply(responsrMess);
                 
                await connector.Conversations.ReplyToActivityAsync(reAct);
             }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private string replyMessege (double score )
        {

            if (score >.8)
      
                return "U R Happy";
                return score < .4 ? "U R Sad" : "Alright";
             
        }

        public string sreach(int id)
        {
             StreamReader r = new StreamReader(@"C:\Users\M-Salah\Documents\Visual Studio 2017\Projects\DemoBot\DemoBot\Models\natega100000.json");

            var json = r.ReadToEnd();
            List<Nitem> items = JsonConvert.DeserializeObject<List<Nitem>>(json);
            var array = JsonConvert.DeserializeObject<List<Nitem>>(json);
            Nitem sss=new Nitem() ;

            var res = array.Find(s => s.SeatNumber == id);
            if (res==null)
            {
                return "";
            }
            double ss = res.TotalDegree;
            double final = Math.Round((ss / 410) *100,4);
            string sa =  final + "%:  " + "النتيجه هى  ";
            return sa ;

        }
        private Activity HandleSystemMessage(Activity message)
        {
            string messageType = message.GetActivityType();
            if (messageType == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (messageType == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (messageType == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (messageType == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (messageType == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}