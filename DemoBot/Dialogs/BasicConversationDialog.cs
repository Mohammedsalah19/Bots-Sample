using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Newtonsoft.Json.Linq;

namespace DemoBot.Dialogs
{
    [Serializable]
    public class BasicConversationDialog
    {

        public enum SandwichOptions
        {
            BLT, BlackForestHam, BuffaloChicken, ChickenAndBaconRanchMelt, ColdCutCombo, MeatballMarinara,
            OvenRoastedChicken, RoastBeef, RotisserieStyleChicken, SpicyItalian, SteakAndCheese, SweetOnionTeriyaki, Tuna,
            TurkeyBreast, Veggie
        };
        public enum LengthOptions { SixInch, FootLong };
        public enum BreadOptions { NineGrainWheat, NineGrainHoneyOat, Italian, ItalianHerbsAndCheese, Flatbread };
        public enum CheeseOptions { American, MontereyCheddar, Pepperjack };
        public enum ToppingOptions
        {
            Avocado, BananaPeppers, Cucumbers, GreenBellPeppers, Jalapenos,
            Lettuce, Olives, Pickles, RedOnion, Spinach, Tomatoes
        };
        public enum SauceOptions
        {
            ChipotleSouthwest, HoneyMustard, LightMayonnaise, RegularMayonnaise,
            Mustard, Oil, Pepper, Ranch, SweetOnion, Vinegar
        };

        [Serializable]
        public class SandwichOrder
        {
            public SandwichOptions? Sandwich;
            public LengthOptions? Length;
            public BreadOptions? Bread;
            public CheeseOptions? Cheese;
            public List<ToppingOptions> Toppings;
            public List<SauceOptions> Sauce;

            public static IForm<BasicConversationDialog> BuildForm()
            {

                return new FormBuilder<BasicConversationDialog>().Message("Welcome to Bot, Kown Your Size Shirt").Build();
            }
 



        }
    }
}