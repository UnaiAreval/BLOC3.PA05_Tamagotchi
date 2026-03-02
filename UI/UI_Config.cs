using System;
using TamagochiConsole.Models.Items;

namespace TamagochiConsole.UI
{
    public class UI_Config
    {
        public class ProgramFoods
        {
            public Food Carrot = new Food("Carrot", 7, FoodType.Vegetable);
            public Food Leek = new Food("Leek", 2, FoodType.Vegetable);
            public Food Baguette = new Food("Baguette", 10, FoodType.Bread);
        }

        public class EnglishMenus
        {
            /// <summary>
            /// Need a value to be passed which is used to select nothing from the list, like a "I don't want to do any of this options".
            /// </summary>
            public const string MenuTitle = """
                Select an option:
                    [{0}] - Select nothing
                """;
            public const string SelectItem = "Select the number of the item to use";
            /// <summary>
            /// Need two values:
            /// <list type="number">
            /// <item>The key or number you must press to use that option</item>
            /// <item>The name or definition of the option</item>
            /// </list>
            /// </summary>
            public const string MenuOption = "    [{0}] - {1}";
            public const string MenuWaitForInput = "  -> ";
            public const string OptionNoRecognized = "The selected option does not exist or is not foud";
        }

        public class Pet_LivePet_Dog_Sprites
        {
            public const string NaturalPosition = """

                """;
            public const string Happy = "";
            public const string Angry = "";
            public const string Sick = "";
            public const string Sad = "";
            public const string Tired = "";
        }
    }
}
