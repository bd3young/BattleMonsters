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
			//BattleMonster equippedMonster = null;
			//BattleMonster enemyEquippedMonster = null;

			DisplayOpeningScreen();
            while (runApp)
            {
                runApp = DisplayMainMenu(runApp, enemyBattleMonsters, yourBattleMonsters);
            }
            DisplayClosingScreen();
        }

        static bool DisplayMainMenu(bool runApp, List<BattleMonster> enemyBattleMonsters, List<BattleMonster> yourBattleMonsters)
        {
            bool runMenu = true;

            string userMenuChoice;



            while (runMenu)
            {           
                DisplayHeader("Main Menu");
                Console.WriteLine();
                Console.WriteLine("A) Display All Battle Monsters.");
                Console.WriteLine("B) Create your own Battle Monsters.");
                Console.WriteLine("C) ");
                Console.WriteLine("D) Battle Enemy Battle Monster.");
                Console.WriteLine("E) Show Battle Tree");
                Console.WriteLine("F) ");
                Console.WriteLine("Q) Quit");
                Console.WriteLine();
                Console.Write("Enter Menu Choice: ");
                userMenuChoice = Console.ReadLine().ToUpper();

                switch (userMenuChoice)
                {
                    case "A":
                        DisplayAllBattleMonsters(enemyBattleMonsters, yourBattleMonsters);
                        break;
                    case "B":
                        DisplayCreateYourOwnBattleMonster(yourBattleMonsters);
                        break;
                    case "C":
						
						break;
                    case "D":
						DisplayBattleBothBattleMonsters(enemyBattleMonsters, yourBattleMonsters);
						break;
                    case "E":
                        
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

		static void DisplayBattleBothBattleMonsters(List<BattleMonster> enemyBattleMonsters, List<BattleMonster> yourBattleMonsters)
		{

			BattleMonster enemyEquippedMonster = null;
			BattleMonster equippedMonster = null;

			equippedMonster = DisplayAndEquipYourBattleMonster(yourBattleMonsters, equippedMonster);

			enemyEquippedMonster = DisplayAndEquipEnemyBattleMonster(enemyBattleMonsters, enemyEquippedMonster);


			//
			// begin the battle
			//

			Console.Clear();
			Console.WriteLine();
			Console.WriteLine($" The battle between {equippedMonster.Name} and {enemyEquippedMonster.Name} is about to begin.");

			DisplayContinuePrompt();

			DisplayCompareElements(enemyEquippedMonster, equippedMonster);
		}

		static void DisplayCompareElements(BattleMonster enemyEquippedMonster, BattleMonster equippedMonster)
		{
			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.GRASS && equippedMonster.monsterElement == BattleMonster.Element.GRASS)
			{
				DisplayHeader("\t Battle Has Begun");

				Console.WriteLine($"It seems that {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element and {equippedMonster.Name}'s {equippedMonster.monsterElement} element have the two in a stailmate!");
				Console.WriteLine();
				Console.WriteLine("\t Press any key to continue the battle.");
				Console.ReadKey();

				DisplayCompareSize(enemyEquippedMonster, equippedMonster);
			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.GRASS && equippedMonster.monsterElement == BattleMonster.Element.WATER)
			{

			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.GRASS && equippedMonster.monsterElement == BattleMonster.Element.FIRE)
			{

			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.WATER && equippedMonster.monsterElement == BattleMonster.Element.GRASS)
			{

			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.WATER && equippedMonster.monsterElement == BattleMonster.Element.WATER)
			{

			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.WATER && equippedMonster.monsterElement == BattleMonster.Element.FIRE)
			{

			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.FIRE && equippedMonster.monsterElement == BattleMonster.Element.GRASS)
			{

			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.FIRE && equippedMonster.monsterElement == BattleMonster.Element.WATER)
			{

			}

			if (enemyEquippedMonster.monsterElement == BattleMonster.Element.FIRE && equippedMonster.monsterElement == BattleMonster.Element.FIRE)
			{

			}
			
		}

		static void DisplayCompareSize(BattleMonster enemyEquippedMonster, BattleMonster equippedMonster)
		{
			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.SMALL && equippedMonster.monsterSize == BattleMonster.Size.SMALL)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.SMALL && equippedMonster.monsterSize == BattleMonster.Size.MEDIUM)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.SMALL && equippedMonster.monsterSize == BattleMonster.Size.LARGE)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.MEDIUM && equippedMonster.monsterSize == BattleMonster.Size.SMALL)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.MEDIUM && equippedMonster.monsterSize == BattleMonster.Size.MEDIUM)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.MEDIUM && equippedMonster.monsterSize == BattleMonster.Size.LARGE)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.LARGE && equippedMonster.monsterSize == BattleMonster.Size.SMALL)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.LARGE && equippedMonster.monsterSize == BattleMonster.Size.MEDIUM)
			{

			}

			if (enemyEquippedMonster.monsterSize == BattleMonster.Size.LARGE && equippedMonster.monsterSize == BattleMonster.Size.LARGE)
			{

			}
		}

		static BattleMonster DisplayAndEquipEnemyBattleMonster(List<BattleMonster> enemyBattleMonsters, BattleMonster enemyEquippedMonster)
		{
			bool monsterNotFound = true;
			string monsterChoice;

			while (monsterNotFound)
			{
				Console.Clear();
				DisplayHeader("\tEnemy Battle Monsters");

				foreach (BattleMonster enemyBattleMonster in enemyBattleMonsters)
				{
					Console.WriteLine();
					Console.WriteLine(enemyBattleMonster.AllBattleMonsters());
				}

				//
				// pick enemy battle monster
				//

				Console.WriteLine();
				Console.Write("Pick a monster to battle: ");
				monsterChoice = Console.ReadLine();

				foreach (BattleMonster enemyBattleMonster in enemyBattleMonsters)
				{
					if (enemyBattleMonster.Name == monsterChoice)
					{
						enemyEquippedMonster = enemyBattleMonster;

						monsterNotFound = false;
						break;
					}
				}
				if (monsterNotFound)
				{
					Console.WriteLine("Unable to locate enemy battle monster.");
					Console.WriteLine();
					Console.WriteLine("Press any key to enter another battle monster.");
					Console.ReadKey();
				}
			}
			return enemyEquippedMonster;
		}

		static BattleMonster DisplayAndEquipYourBattleMonster(List<BattleMonster> yourBattleMonsters, BattleMonster equippedMonster)
        {
			bool monsterNotFound = true;
			string monsterChoice;

			while (monsterNotFound)
			{
				Console.Clear();
				DisplayHeader("\tYour Battle Monsters");

				foreach (BattleMonster yourBattleMonster in yourBattleMonsters)
				{
					Console.WriteLine();
					Console.WriteLine(yourBattleMonster.AllBattleMonsters());
				}

				//
				// equip a monster
				//

				Console.WriteLine();
				Console.Write("Pick a monster to equip: ");
				monsterChoice = Console.ReadLine();

				foreach (BattleMonster yourBattleMonster in yourBattleMonsters)
				{
					if (yourBattleMonster.Name == monsterChoice)
					{
						equippedMonster = yourBattleMonster;
						
						monsterNotFound = false;
						break;
					}
				}
				if (monsterNotFound)
				{
					Console.WriteLine("Unable to locate your battle monster.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to enter another battle monster.");
                    Console.ReadKey();						
				}
			}
			return equippedMonster;
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

        static void DisplayAllBattleMonsters(List<BattleMonster> enemyBattleMonsters, List<BattleMonster> yourBattleMonsters)
        {
			//
			// enemy monsters
			//
            DisplayHeader("\tEnemy Battle Monsters");
			Console.WriteLine("---------------------------------------------------");

            foreach (BattleMonster enemyBattleMonster in enemyBattleMonsters)
            {

                Console.WriteLine(enemyBattleMonster.AllBattleMonsters());

            }
			Console.WriteLine("---------------------------------------------------");

			Console.WriteLine();
			Console.WriteLine("\tYour Battle Monsters");
			Console.WriteLine("---------------------------------------------------");

			foreach (BattleMonster yourBattleMonster in yourBattleMonsters)
			{

				Console.WriteLine(yourBattleMonster.AllBattleMonsters());

			}
			Console.WriteLine("---------------------------------------------------");

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
            gilroy.monsterElement = BattleMonster.Element.GRASS;
            gilroy.monsterSize = BattleMonster.Size.LARGE;

            return gilroy;
        }

        static BattleMonster InstantiateBattleMonsterKitten()
        {
            BattleMonster kitten = new BattleMonster();

            kitten.Name = "Kitten";
            kitten.monsterElement = BattleMonster.Element.WATER;
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