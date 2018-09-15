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
using static DemoBot.Dialogs.BickYourShirt;
using Microsoft.Bot.Builder.FormFlow;

namespace DemoBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        /// 

            internal static IDialog<PickShirt> MakeRootDialog()
             {
          
            return Chain.From(() => FormDialog.FromForm(PickShirt.BuildForm)).Do(async (context, order) =>
             {


 
                 var comprl = await order;
              await context.PostAsync("Just take order");

             });
        }
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.GetActivityType() == ActivityTypes.Message)
            {
                    var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                var ss = activity.Text;



                await Conversation.SendAsync(activity, MakeRootDialog);
 

              var r =  res(int.Parse(ss));
               var replyActivity = activity.CreateReply(r);

                Activity rep2 = activity.CreateReply();
                rep2.Text = res(int.Parse(ss));


                Activity rep = activity.CreateReply();
                rep.Attachments.Add(new Attachment()

                {
                    ContentUrl = "https://lh3.googleusercontent.com/Cj5ZQ8e6RmeVN3QQ4XyLbRuVp4z66jzPWTid-6z-CXtkExvuCuTDYmYYWVJnZCOhIT_ZMsdzadjjuxiy0AMhPS4jPOqlQVG600PzULmja5LMOIhunHA4UdomEsEzyxJB6O3DWD_Nw-HyCPK8iUEIeturq9e-HTEl8xkqSqig1XScqMP349ekdroOKUXA9fvbZlGfKJjuaRJoUpQE4nmfl_-JtIRI1KbNKq8FJKQFw2fbEmDr8iDn0UJNqb-O2BulZasOLCAkV31zkcOBmtjNGtLe0ZBeBVYHxPSTUz8fkL5dPsF2wpI4l7EUXqNMSxukHwHuBXo2IXcZZw8NW9yCnP6-2o_ca1qcXYoAxxokr7sNQ1PeNQ32-XM8uF7HwOLdwSSr6uJg4GjVg8sqOY93sCRmieNpmDMQPXys37wgQp9KR3tN_uQ2kfgIknSMhwgFYCjXiWe_etL0WcLZWk3owTX6upoEw7J1MAiMeZ9WN3WNKUGPkcPxfZ6FE4aItm0jhDEyvSTVF7AO2EbiQAeLa7dKgl6SKhYBXtFT7kXwRsX6ORIqby8qf0bPngMV0U-y_VYGHSaWmI0lUnAPNYnvjjwc0gkPjbvAiKum5k00dJ78tafMXmgzRdGToiaR4UY=w989-h603-no",
                    ContentType = "image/jpg",
                    Name = "fb img"

                }
                 );
                await connector.Conversations.ReplyToActivityAsync(rep);
                await connector.Conversations.ReplyToActivityAsync(rep2);



                //Activity rep = activity.CreateReply("My Social Media Pofiles");
                //rep.AttachmentLayout = AttachmentLayoutTypes.List;

                //rep.Attachments = new List<Attachment>();



                #region github and twitter Card

                /*
                                  //twitter
                                CardAction twitter = new CardAction("openurl", "Twitter account", null, "https://twitter.com/mhammedsalah19");
                                CardImage twitterImg = new CardImage("https://logos-download.com/169-twitter-logo-download.html");

                                ThumbnailCard twicard = new ThumbnailCard();
                                twicard.Buttons = new List<CardAction>();
                                twicard.Images = new List<CardImage>();

                                twicard.Buttons.Add(twitter);
                                twicard.Images.Add(twitterImg);
                                twicard.Title = "My Twitter Account";
                               // twicard.Subtitle = "ar";
                                // twicard.Text = "this is text";
                                 rep.Attachments.Add(twicard.ToAttachment());

                                // github
                                CardAction github = new CardAction("openurl", "github account", null, "https://github.com/Mohammedsalah19/");
                                CardImage githunImg = new CardImage("https://assets-cdn.github.com/images/modules/logos_page/Octocat.png");

                                 HeroCard gitcard = new HeroCard();
                                gitcard.Buttons = new List<CardAction>();
                                gitcard.Images = new List<CardImage>();

                                gitcard.Buttons.Add(github);
                                gitcard.Images.Add(githunImg);
                                gitcard.Title = "My GitHub Account";

                                rep.Attachments.Add(gitcard.ToAttachment());




                                CardAction fb = new CardAction("opnurl", "Facebook Acc", null, "www.facebook.com/mhammedsalah19");
                                CardImage fbImg = new CardImage("https://scontent-cai1-1.xx.fbcdn.net/v/t1.0-9/fr/cp0/e15/q65/37964473_1126179950867410_1131265845708718080_n.jpg?_nc_cat=0&efg=eyJpIjoiYiJ9&oh=c3edacdc0b29b3e75a8701d399a15997&oe=5BF44F2C");

                                HeroCard fbCard = new HeroCard();
                                fbCard.Buttons = new List<CardAction>();
                                fbCard.Images = new List<CardImage>();

                                fbCard.Buttons.Add(fb);
                                fbCard.Images.Add(fbImg);
                                fbCard.Title = "My FaceBook Account";

                                rep.Attachments.Add(fbCard.ToAttachment());


                    */

                #endregion


                #region Attachment
                //rep.Attachments.Add(new Attachment()

                //{
                //    ContentUrl = "https://scontent-cai1-1.xx.fbcdn.net/v/t1.0-9/fr/cp0/e15/q65/37964473_1126179950867410_1131265845708718080_n.jpg?_nc_cat=0&efg=eyJpIjoiYiJ9&oh=c3edacdc0b29b3e75a8701d399a15997&oe=5BF44F2C",
                //    ContentType = "image/jpg",
                //    Name = "fb img"

                //}
                // );
                #endregion

                #region natiga search

                //var res = sreach(Convert.ToInt32( ss));
                //var reAct = activity.CreateReply(res.ToString());


                #endregion


                #region text analuzer
                //  var responses = await TestAnalyzerHelper.analyze(mess);

                //  var responsrMess = replyMessege(responses.Documents.First().Score);
                // var replyActivity = activity.CreateReply(responsrMess);
                #endregion


                //         await connector.Conversations.ReplyToActivityAsync(rep);
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


        public static string res(int ss)
        {
            string v = "";
            if (ss == 1)
            {
                v = "your size is ' Small '";
            }
            else if (ss == 2)
            {
                v = "your size is ' Large '";
            }
            else if (ss == 3)
            {
                v = "your size is ' XLarge '";
            }
            else if (ss == 4)
            {
                v = "your size is ' XXLarge '";
            }
            else if (ss == 5)
            {
                v = "your size is ' XXXLarge '";
            }
            else if (ss == 6)

            {
                v = "your size is ' XXXXLarge '";
            }
            else
            {
                v = "Your Chooice is Wrong '";
            }
            return v;
        }

            #region Natiga
        //public string sreach(int id)
        //{
        //     StreamReader r = new StreamReader(@"C:\Users\M-Salah\Documents\Visual Studio 2017\Projects\DemoBot\DemoBot\Models\natega100000.json");

        //    var json = r.ReadToEnd();
        //    List<Nitem> items = JsonConvert.DeserializeObject<List<Nitem>>(json);
        //    var array = JsonConvert.DeserializeObject<List<Nitem>>(json);
        //    Nitem sss=new Nitem() ;

        //    var res = array.Find(s => s.SeatNumber == id);
        //    if (res==null)
        //    {
        //        return "";
        //    }
        //    double ss = res.TotalDegree;
        //    double final = Math.Round((ss / 410) *100,4);
        //    string sa =  final + "%:  " + "النتيجه هى  ";
        //    return sa ;

        //}

               #endregion


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