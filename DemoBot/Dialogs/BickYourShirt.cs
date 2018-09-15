using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace DemoBot.Dialogs
{
    public class BickYourShirt
    {
 



        public  enum Width  { btween50to53=5 , btween53to56, btween56to59, btween59to62, btween62to56, btweento53to56 };
        public enum lenght { btween68to70, btween70to72, btween72to74, btween74to76, btween76to78, btween78to80, btween80to82, btween82to84 };
 
        [Serializable]
        public class PickShirt
        {

 
         //   public int? color ;
           // public int? size;
            public List<Width> Width;
            

            public static IForm<PickShirt>BuildForm()
            {



                return new FormBuilder<PickShirt>().Message("Welcome to Bot, send your choose number").Build();
            }

       


        }
             


    }
}