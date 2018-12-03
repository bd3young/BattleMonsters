using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleMonsters
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runApp = true;

            DisplayOpeningScreen();
            while (runApp)
            {
                runApp = DisplayMainMenu(runApp);
            }
            DisplayClosingScreen();
        }

        static bool DisplayMainMenu(bool runApp)
        {
            bool runMenu = true;

            string userMenuChoice;

            //
            // instantiate battle monsters
            //


            BattleMonster kitten;
            kitten = InstantiateBattleMonsterKitten();

            BattleMonster gilroy;
            gilroy = InstantiateBattleMonsterGilroy();

            BattleMonster gargle;
            gargle = InstantiateBattleMonsterGargle();

            BattleMonster stump;
            stump = InstantiateBattleMonsterStump();

            BattleMonster fury;
            fury = InstantiateBattleMonsterFury();

            List<BattleMonster> enemyBattleMonsters = new List<BattleMonster>();
            enemyBattleMonsters.Add(kitten);
            enemyBattleMonsters.Add(gilroy);
            enemyBattleMonsters.Add(gargle);
            enemyBattleMonsters.Add(stump);
            enemyBattleMonsters.Add(fury);

            List<BattleMonster> yourBattleMonsters = new List<BattleMonster>();
            BattleMonster equippedMonster = null;

            while (runMenu)
            {           
                DisplayHeader("Main Menu");
                Console.WriteLine();
                Console.WriteLine("A) Display enemy Battle Monsters.");
                Console.WriteLine("B) Create your own Battle Monsters.");
                Console.WriteLine("C) Display and Equip your Battle Monsters");
                Console.WriteLine("D) Battle enemy Battle Monster.");
                Console.WriteLine("E) Show Battle Tree");
                Console.WriteLine("F) ");
                Console.WriteLine("Q) Quit");
                Console.WriteLine();
                Console.Write("Enter Menu Choice: ");
                userMenuChoice = Console.ReadLine().ToUpper();

                switch (userMenuChoice)
                {
                    case "A":
                        DisplayEnemyBattleMonsters(enemyBattleMonsters);
                        break;
                    case "B":
                        DisplayCreateYourOwnBattleMonster(yourBattleMonsters);
                        break;
                    case "C":
                        DisplayAndEquipYourBattleMonster(yourBattleMonsters, equippedMonster);
                        break;
                    case "Q":
                        runMenu = false;
                        runApp = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please type a valid menu option [A, B, C, Q]");
                        DisplayContinuePrompt();
                        break;
                }
            }

            return runApp;
        }

        static void DisplayAndEquipYourBattleMonster(List<BattleMonster> yourBattleMonsters, BattleMonster equippedMonster)
        {
            
        }

        static void DisplayCreateYourOwnBattleMonster(List<BattleMonster> yourBattleMonsters)
        {
            bool loop = true;

            BattleMonster newBattleMonster = new BattleMonster();

            DisplayHeader("\tCreate your own Battle Monster");

            Console.Write("Enter Name: ");
            newBattleMonster.Name = Console.ReadLine();

            while (loop)
            {
                Console.Clear();
                DisplayHeader("\tCreate your own Battle Monster");
                Console.Write("Enter Element Type: ");
                if (Enum.TryParse(Console.ReadLine().ToUpper(), out BattleMonster.Element elementType))
                {
                    newBattleMonster.monsterElement = elementType;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid element. [GRASS, WATER, FIRE, LIGHT, DARK]");
                    Console.ReadKey();
                }
            }

            while (!loop)
            {
                Console.Clear();
                DisplayHeader("\tCreate your own Battle Monster");
                Console.Write("Enter Size of Monster: ");
                if (Enum.TryParse(Console.ReadLine().ToUpper(), out BattleMonster.Size sizeOfMonster))
                {
                    newBattleMonster.monsterSize = sizeOfMonster;
                    loop = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid size. [SMALL, MEDIUM, LARGE]");
                    Console.ReadKey();
                }
            }

            yourBattleMonsters.Add(newBattleMonster);

            DisplayContinuePrompt();
        }

        static void DisplayEnemyBattleMonsters(List<BattleMonster> enemyBattleMonsters)
        {
            DisplayHeader("\tEnemy Battle Monsters");

            foreach (BattleMonster enemyBattleMonster in enemyBattleMonsters)
            {
                Console.WriteLine();
                Console.WriteLine(enemyBattleMonster.EnemyBattleMonsters());
            }

            DisplayContinuePrompt();
        }

        static BattleMonster InstantiateBattleMonsterFury()
        {
            BattleMonster fury = new BattleMonster();

            fury.Name = "Fury";
            fury.monsterElement = BattleMonster.Element.FIRE;
            fury.monsterSize = BattleMonster.Size.LARGE;

            return fury;
        }

        static BattleMonster InstantiateBattleMonsterStump()
        {
            BattleMonster stump = new BattleMonster();

            stump.Name = "Stump";
            stump.monsterElement = BattleMonster.Element.GRASS;
            stump.monsterSize = BattleMonster.Size.MEDIUM;

            return stump;
        }
   
        static BattleMonster InstantiateBattleMonsterGargle()
        {
            BattleMonster gargle = new BattleMonster();

            gargle.Name = "Gargle";
            gargle.monsterElement = BattleMonster.Element.WATER;
            gargle.monsterSize = BattleMonster.Size.SMALL;

            return gargle;
        }

        static BattleMonster InstantiateBattleMonsterGilroy()
        {
            BattleMonster gilroy = new BattleMonster();

            gilroy.Name = "Gilroy";
            gilroy.monsterElement = BattleMonster.Element.LIGHT;
            gilroy.monsterSize = BattleMonster.Size.LARGE;

            return gilroy;
        }

        static BattleMonster InstantiateBattleMonsterKitten()
        {
            BattleMonster kitten = new BattleMonster();

            kitten.Name = "Kitten";
            kitten.monsterElement = BattleMonster.Element.DARK;
            kitten.monsterSize = BattleMonster.Size.SMALL;

            return kitten;
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine("\n\nBattle Monsters!!!!!!\n\n");
            
            DisplayContinuePrompt();
        }

        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine();
        }

        static void DisplayClosingScreen()
        {
            DisplayHeader("Closing Screen");
            Console.WriteLine();
            Console.WriteLine("Its been great.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }


    }
}