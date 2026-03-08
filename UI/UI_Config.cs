using System;
using TamagochiConsole.Models.Items;

namespace TamagochiConsole.UI
{
    public class UI_Config
    {
        public class OwnerInventori
        {
            private static Food Carrot = new Food("Carrot", 7, FoodType.Vegetable);
            private static Food Leek = new Food("Leek", 2, FoodType.Vegetable);
            private static Food Baguette = new Food("Baguette", 10, FoodType.Bread);

            public static AItem[] GetInventori()
            {
                return new AItem[]
                {
                    Carrot, Leek, Baguette //Food
                };
            }
        }

        public class InventoriMenus
        {
            /// <summary>
            /// Need a value to be passed which is used to select nothing from the list, like a "I don't want to do any of this options".
            /// </summary>
            public const string MenuTitle = """
                Select an option:
                    [{0}] - Select nothing
                """;
            public const string SelectItem = "Select the number of the item to use:";
            /// <summary>
            /// Need two values:
            /// <list type="number">
            /// <item>The key or number you must press to use that option</item>
            /// <item>The name or definition of the option</item>
            /// </list>
            /// </summary>
            public const string MenuOption = "    [{0}] - {1}";
            public const string MenuWaitForInput = "    << {0} >>";
            public const string OptionNoRecognized = "The selected option does not exist or is not foud";
        }
        public class PetMenu
        {
            /// <summary>
            /// Used to display the key that the user presses
            /// </summary>
            public const string ExpectingKeyToBePressed = "    << {0} >>";


            public const ConsoleKey playOption = ConsoleKey.P;
            public const ConsoleKey feedOption = ConsoleKey.F;
            public const ConsoleKey inventoriOption = ConsoleKey.I;
            public const ConsoleKey restOption = ConsoleKey.R;
            public const ConsoleKey petsDataOption = ConsoleKey.D;
            public const ConsoleKey medicDataOption = ConsoleKey.M;
            public const ConsoleKey exitOption = ConsoleKey.E;
            public const ConsoleKey savePetOption = ConsoleKey.S;
            public const ConsoleKey getLastSavedPet = ConsoleKey.G;
            public const ConsoleKey changeMyPetOption = ConsoleKey.C;
            public const string NoPet = "You don't have a pet";

            private static string PetOptions = $"""
                ____________________________________________________
                |                                                  |
                |     [Press {playOption}] - Play      [Press {feedOption}] - Feed       |
                |                                                  |
                |   [Press {inventoriOption}] - Inventroi    [Press {restOption}] - Rest      |
                |                                                  |
                |  [Press {petsDataOption}] - Pet data    [Press {medicDataOption}] - Medic data  |
                |                                                  |
                |            [Press {savePetOption}] - Save Pet data             |
                |          [Press {getLastSavedPet}] - Get last saved pet          |
                |            [Press {changeMyPetOption}] - Change my pet             |
                |                                                  |
                |                 [Press {exitOption}] - Exit                 |
                |__________________________________________________|
                """;
            public static string Get_PetMenuOptions() => PetOptions;

            //Pet Resting
            public const string Msg_PetResting = "Your pet is resting";
            public const string Msg_PetStealTired = "Your pet is steal tired";
            public const string Msg_PetRecoveredEnergy = "Your pet recovered it's energy";

            //Create Pets Name
            public const int PetsName_MinSize = 6;
            public const int PetsName_MaxSize = 12;
            private static string Msg_AskPetName = $"Which will be your pets name?\nYour pets name must have a size bettwen {PetsName_MinSize} and {PetsName_MaxSize}";
            public static string GetMsg_AskPetName() => Msg_AskPetName;

            //Pet Type Selector
            public const ConsoleKey livingBeingOption = ConsoleKey.L;
            private static string Msg_AskPetType = $"""
                What kind of pet do you want it to be?
                    [Press {livingBeingOption}] - Living being 
                """;
            public static string GetMsg_AskPetType() => Msg_AskPetType;

            //Living being Pet Type Selector
            public const ConsoleKey dogPetOption = ConsoleKey.D;
            public const ConsoleKey catPetOption = ConsoleKey.C;
            public const ConsoleKey chickenOption = ConsoleKey.H;
            private static string Msg_AskPetType_LivingBeing = $"""
                What living being pet would you like?
                    [Press {dogPetOption}] - Dog
                    [Press {catPetOption}] - Cat
                    [Press {chickenOption}] - Chicken
                """;
            public static string GetMsg_AskPetType_LivingBeing() => Msg_AskPetType_LivingBeing;
        }
        
        public class PetTypesAndEmotions
        {
            public const string Dog = "Dog - 🐺";
            public const string Emoji_Dog = "🐺";
            public const string Cat = "Cat - 🐱";
            public const string Emoji_Cat = "🐱";
            public const string Chicken = "Chicken - 🐣";
            public const string Emoji_Chicken = "🐣";
            public const string Sad = "Sad - 😢";
            public const string Tired = "Tired - 😪";
            public const string Sick = "Sick - 😷";
            public const string Angry = "Angry - 😤";
            public const string Happy = "Happy - 😄";
            public const string NoRecognised = "No recognised - ?";
        }
    }
}
