using System;
using TamagochiConsole.Models;
using TamagochiConsole.Models.Pet;
using TamagochiConsole.Models.Pet.Animals;

namespace TamagochiConsole.UI
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Owner owner = new Owner();
            ConsoleKey userResponse;
            bool exit = false;

            owner.RecoverSavedPet();

            do
            {
                if (owner.GetPet() == null)
                {
                    string newPetName = "";
                    bool askAgain = false;

                    do
                    {
                        Console.WriteLine(UI_Config.PetMenu.GetMsg_AskPetName());
                        newPetName = Console.ReadLine();
                        Console.Clear();
                    } while (newPetName.Length > UI_Config.PetMenu.PetsName_MaxSize || newPetName.Length < UI_Config.PetMenu.PetsName_MinSize);

                    do
                    {
                        if (askAgain) Console.WriteLine($"Something wrong happened while creating {newPetName}");
                        askAgain = false;
                        Console.WriteLine(UI_Config.PetMenu.GetMsg_AskPetType());
                        Console.WriteLine(UI_Config.PetMenu.ExpectingKeyToBePressed, (userResponse = Console.ReadKey(true).Key));
                        Thread.Sleep(2000);
                        Console.Clear();

                        switch (userResponse)//This cases are the APet heiresses classes
                        {
                            case UI_Config.PetMenu.livingBeingOption://This cases are the ALivePet heiresses classes
                                Console.WriteLine(UI_Config.PetMenu.GetMsg_AskPetType_LivingBeing());
                                Console.WriteLine(UI_Config.PetMenu.ExpectingKeyToBePressed, (userResponse = Console.ReadKey(true).Key));
                                Thread.Sleep(2000);
                                Console.Clear();
                                switch (userResponse)
                                {
                                    case UI_Config.PetMenu.dogPetOption:
                                        owner.SetPet(new Dog(newPetName, Race.Dalmata));
                                        break;

                                    case UI_Config.PetMenu.catPetOption:
                                        owner.SetPet(new Cat(newPetName, new FurColor[] { FurColor.White, FurColor.TigerOrange }));
                                        break;

                                    case UI_Config.PetMenu.chickenOption:
                                        owner.SetPet(new Chicken(newPetName));
                                        break;

                                    default:
                                        askAgain = true;
                                        break;
                                }
                                break;

                            default:
                                askAgain = true;
                                break;
                        }
                    } while (askAgain);
                }

                Console.WriteLine(owner.GetPet().ToString());
                Console.WriteLine(UI_Config.PetMenu.Get_PetMenuOptions());
                Console.WriteLine(UI_Config.PetMenu.ExpectingKeyToBePressed, (userResponse = Console.ReadKey(true).Key));
                switch (userResponse)
                {
                    case UI_Config.PetMenu.playOption:
                        break;

                    case UI_Config.PetMenu.feedOption:
                        break;

                    case UI_Config.PetMenu.inventoriOption:
                        owner.Inventori();
                        break;

                    case UI_Config.PetMenu.restOption:
                        owner.GetPet().Rest();
                        break;

                    case UI_Config.PetMenu.petsDataOption:
                        owner.GetPet().PrintPetsData();
                        break;

                    case UI_Config.PetMenu.medicDataOption:
                        if (owner.GetPet() is ALivePet lPet) Console.WriteLine(lPet.GetMedicData());
                        break;

                    case UI_Config.PetMenu.exitOption:
                        exit = true;
                        break;

                    case UI_Config.PetMenu.savePetOption:
                        owner.SavePet();
                        break;

                    case UI_Config.PetMenu.getLastSavedPet:
                        owner.RecoverSavedPet();
                        break;

                    case UI_Config.PetMenu.changeMyPetOption:
                        owner.SetPet(null);
                        Console.WriteLine(UI_Config.PetMenu.NoPet);
                        break;

                    default:
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            } while (!exit);
        }
    }
}