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
			// **************************************************
			//
			// Title: Battle Monsters
			// Description: Game
			// Application Type: Console
			// Author: (Beau B DeYoung)
			// Dated Created: (12/08/2018)
			// Last Modified: (12/10/2018)
			//
			// **************************************************

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
                DisplayHeader("Battle Monsters Main Menu");
                Console.WriteLine();
                Console.WriteLine("A) Display All Battle Monsters");
                Console.WriteLine("B) Create your own Battle Monsters");
                Console.WriteLine("C) Battle Enemy Battle Monster");
                Console.WriteLine("D) Show Battle Tree");
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
						DisplayBattleBothBattleMonsters(enemyBattleMonsters, yourBattleMonsters);
						break;
                    case "D":
                        DisplayBattleTree();
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

        static void DisplayBattleTree()
        {
            DisplayHeader("\tBattle Tree");

            Console.WriteLine("\t\t Battle trees rotate clockwise.");
            Console.WriteLine();
            Console.WriteLine("\t----------------------------------------");
            Console.WriteLine("\t|         GRASS --->|      SMALL   --->|");
            Console.WriteLine("\t|         /  \\      |     /    \\       |");
            Console.WriteLine("\t|        /    \\     |    /      \\      |");
            Console.WriteLine("\t|     FIRE----WATER | MEDIUM----LARGE  |");
            Console.WriteLine("\t----------------------------------------");

            DisplayContinuePrompt();
        }

        static void DisplayBattleBothBattleMonsters(List<BattleMonster> enemyBattleMonsters, List<BattleMonster> yourBattleMonsters)
		{

			BattleMonster enemyEquippedMonster = null;
			BattleMonster equippedMonster = null;

			equippedMonster = DisplayAndEquipYourBattleMonster(yourBattleMonsters, equippedMonster);

			enemyEquippedMonster = DisplayAndEquipEnemyBattleMonster(enemyBattleMonsters, enemyEquippedMonster, equippedMonster);


			//
			// begin the battle
			//

			DisplayContinuePrompt();

			DisplayCompareElements(enemyBattleMonsters, enemyEquippedMonster, yourBattleMonsters, equippedMonster);


		}

		static void DisplayCompareElements(List<BattleMonster> enemyBattleMonsters, BattleMonster enemyEquippedMonster, List<BattleMonster> yourBattleMonsters, BattleMonster equippedMonster)
		{

            //
            // grass / grass
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.GRASS && enemyEquippedMonster.monsterElement == BattleMonster.Element.GRASS)
			{
				DisplayHeader("\t Battle Has Begun");

				Console.WriteLine($"It seems that {equippedMonster.Name}'s {equippedMonster.monsterElement} element and {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element have the two in a stailmate!");
				Console.WriteLine();
				Console.WriteLine("\t Press any key to continue the battle.");
				Console.ReadKey();

				DisplayCompareSize(enemyBattleMonsters, enemyEquippedMonster, yourBattleMonsters, equippedMonster);
			}

            //
            // grass / water
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.GRASS && enemyEquippedMonster.monsterElement == BattleMonster.Element.WATER)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterElement} element has overpowered {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element!");
                Console.WriteLine($"{enemyEquippedMonster.Name} faints.");
                Console.WriteLine();
                enemyBattleMonsters.Remove(enemyEquippedMonster); 
                Console.WriteLine("\t Press any key to leave the battle.");
                Console.ReadKey();
            }

            //
            // grass / fire
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.GRASS && enemyEquippedMonster.monsterElement == BattleMonster.Element.FIRE)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterElement} element is weak against {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element!");
                Console.WriteLine($"{equippedMonster.Name} faints.");
                Console.WriteLine();
                yourBattleMonsters.Remove(equippedMonster);
                Console.WriteLine("\t Press any key to leave the battle.");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // water / grass
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.WATER && enemyEquippedMonster.monsterElement == BattleMonster.Element.GRASS)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterElement} element is weak against {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element!");
                Console.WriteLine($"{equippedMonster.Name} faints.");
                Console.WriteLine();
                yourBattleMonsters.Remove(equippedMonster);
                Console.WriteLine("\t Press any key to leave the battle.");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // water / water
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.WATER && enemyEquippedMonster.monsterElement == BattleMonster.Element.WATER)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"It seems that {equippedMonster.Name}'s {equippedMonster.monsterElement} element and {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element have the two in a stailmate!");
                Console.WriteLine();
                Console.WriteLine("\t Press any key to continue the battle.");
                Console.ReadKey();

                DisplayCompareSize(enemyBattleMonsters, enemyEquippedMonster, yourBattleMonsters, equippedMonster);
            }

            //
            // water / fire
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.WATER && enemyEquippedMonster.monsterElement == BattleMonster.Element.FIRE)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterElement} element has overpowered {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element!");
                Console.WriteLine($"{enemyEquippedMonster.Name} faints.");
                Console.WriteLine();
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine("\t Press any key to leave the battle.");
                Console.ReadKey();
            }

            //
            // fire / grass
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.FIRE && enemyEquippedMonster.monsterElement == BattleMonster.Element.GRASS)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterElement} element has overpowered {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element!");
                Console.WriteLine($"{enemyEquippedMonster.Name} faints.");
                Console.WriteLine();
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine("\t Press any key to leave the battle.");
                Console.ReadKey();
            }

            //
            // fire / water
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.FIRE && enemyEquippedMonster.monsterElement == BattleMonster.Element.WATER)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterElement} element is weak against {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element!");
                Console.WriteLine($"{equippedMonster.Name} faints.");
                Console.WriteLine();
                yourBattleMonsters.Remove(equippedMonster);
                Console.WriteLine("\t Press any key to leave the battle.");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // fire / fire
            //
			if (equippedMonster.monsterElement == BattleMonster.Element.FIRE && enemyEquippedMonster.monsterElement == BattleMonster.Element.FIRE)
			{
                DisplayHeader("\t Battle Has Begun");

                Console.WriteLine($"It seems that {equippedMonster.Name}'s {equippedMonster.monsterElement} element and {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterElement} element have the two in a stailmate!");
                Console.WriteLine();
                Console.WriteLine("\t Press any key to continue the battle.");
                Console.ReadKey();

                DisplayCompareSize(enemyBattleMonsters, enemyEquippedMonster, yourBattleMonsters, equippedMonster);
            }
            if ((equippedMonster.monsterElement == BattleMonster.Element.FIRE || equippedMonster.monsterElement == BattleMonster.Element.GRASS || equippedMonster.monsterElement == BattleMonster.Element.WATER) && enemyEquippedMonster.monsterElement == BattleMonster.Element.returnToMenu)
            {
                DisplayHeader("\tReturning to Battle Monsters Menu");
                Console.WriteLine("Press any key to return to menu.");
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.ReadKey();          
            }
			
		}

		static void DisplayCompareSize(List<BattleMonster> enemyBattleMonsters, BattleMonster enemyEquippedMonster, List<BattleMonster> yourBattleMonsters, BattleMonster equippedMonster)
		{   
            
            //
            // small / small
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.SMALL && enemyEquippedMonster.monsterSize == BattleMonster.Size.SMALL)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"Both {equippedMonster.Name} and {enemyEquippedMonster.Name} have given it there all have.");
                Console.WriteLine($"With {equippedMonster.Name}'s {equippedMonster.monsterSize} size and {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size, they have exausted everything and both faint.");
                yourBattleMonsters.Remove(equippedMonster);
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // small / medium
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.SMALL && enemyEquippedMonster.monsterSize == BattleMonster.Size.MEDIUM)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterSize} size is overpowered by {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size.");
                Console.WriteLine($"{equippedMonster.Name} faints.");
                yourBattleMonsters.Remove(equippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // small / large
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.SMALL && enemyEquippedMonster.monsterSize == BattleMonster.Size.LARGE)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterSize} size is to fast for {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size to hit.");
                Console.WriteLine($"{enemyEquippedMonster.Name} faints from exhaustion.");
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
            }

            //
            // medium / small
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.MEDIUM && enemyEquippedMonster.monsterSize == BattleMonster.Size.SMALL)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterSize} size overpowers {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size.");
                Console.WriteLine($"{enemyEquippedMonster.Name} faints.");
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
            }

            //
            // medium / medium
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.MEDIUM && enemyEquippedMonster.monsterSize == BattleMonster.Size.MEDIUM)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"Both {equippedMonster.Name} and {enemyEquippedMonster.Name} have given it there all have.");
                Console.WriteLine($"With {equippedMonster.Name}'s {equippedMonster.monsterSize} size and {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size, they have exausted everything and both faint.");
                yourBattleMonsters.Remove(equippedMonster);
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // medium / large
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.MEDIUM && enemyEquippedMonster.monsterSize == BattleMonster.Size.LARGE)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterSize} size is overpowered by {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size.");
                Console.WriteLine($"{equippedMonster.Name} faints.");
                yourBattleMonsters.Remove(equippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // large / small
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.LARGE && enemyEquippedMonster.monsterSize == BattleMonster.Size.SMALL)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterSize} size is to slow to hit {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size.");
                Console.WriteLine($"{equippedMonster.Name} faints from exhaustion.");
                yourBattleMonsters.Remove(equippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
                DisplayBattleTree();
            }

            //
            // large / medium
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.LARGE && enemyEquippedMonster.monsterSize == BattleMonster.Size.MEDIUM)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"{equippedMonster.Name}'s {equippedMonster.monsterSize} size overpowers {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size.");
                Console.WriteLine($"{enemyEquippedMonster.Name} faints.");
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
            }

            //
            // large / large
            //
			if (equippedMonster.monsterSize == BattleMonster.Size.LARGE && enemyEquippedMonster.monsterSize == BattleMonster.Size.LARGE)
			{
                DisplayHeader("The Battle Continues");

                Console.WriteLine($"Both {equippedMonster.Name} and {enemyEquippedMonster.Name} have given it there all have.");
                Console.WriteLine($"With {equippedMonster.Name}'s {equippedMonster.monsterSize} size and {enemyEquippedMonster.Name}'s {enemyEquippedMonster.monsterSize} size, they have exausted everything and both faint.");
                yourBattleMonsters.Remove(equippedMonster);
                enemyBattleMonsters.Remove(enemyEquippedMonster);
                Console.WriteLine();
                Console.WriteLine("\t Press any key to leave the battle ");
                Console.ReadKey();
                DisplayBattleTree();
            }
		}

		static BattleMonster DisplayAndEquipEnemyBattleMonster(List<BattleMonster> enemyBattleMonsters, BattleMonster enemyEquippedMonster, BattleMonster equippedMonster)
		{
            string userResponse;
			bool monsterNotFound = true;
			string monsterChoice;

			while (monsterNotFound)
			{
                Console.Clear();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Your Currently Equipped Monster: {equippedMonster.AllBattleMonsters()}");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("\tEnemy Battle Monsters");
                Console.WriteLine("---------------------------------------------------");

                foreach (BattleMonster enemyBattleMonster in enemyBattleMonsters)
                {

                    Console.WriteLine(enemyBattleMonster.AllBattleMonsters());

                }
                Console.WriteLine("---------------------------------------------------");

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
					Console.Write("Are there any more Monster to Battle [YES or NO]:");
					userResponse = Console.ReadLine().ToUpper();
                    if (userResponse == "NO")
                    {
                        BattleMonster returnToMenu = new BattleMonster();
                        returnToMenu.Name = "Returntomenu";
                        returnToMenu.monsterElement = BattleMonster.Element.returnToMenu;
                        returnToMenu.monsterSize = BattleMonster.Size.returnToMenu;

                        enemyEquippedMonster = returnToMenu;
                        monsterNotFound = false;
                    }
				}
			}
			return enemyEquippedMonster;
		}

		static BattleMonster DisplayAndEquipYourBattleMonster(List<BattleMonster> yourBattleMonsters, BattleMonster equippedMonster)
        {
            string userResponse;
			bool monsterNotFound = true;
			string monsterChoice;

			while (monsterNotFound)
			{
				Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tYour Battle Monsters");
                Console.WriteLine("---------------------------------------------------");

                foreach (BattleMonster yourBattleMonster in yourBattleMonsters)
                {

                    Console.WriteLine(yourBattleMonster.AllBattleMonsters());

                }
                Console.WriteLine("---------------------------------------------------");

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
                    Console.Write("Would you like to create a Battle Monster to equip? [YES or NO]: ");
                    userResponse = Console.ReadLine().ToUpper();
                    if (userResponse == "YES")
                    {
                        DisplayCreateYourOwnBattleMonster(yourBattleMonsters);
                    }

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
                    Console.WriteLine("Please enter a valid element. [GRASS, WATER, FIRE]");
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
            gargle.monsterSize = BattleMonster.Size.LARGE;

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

            Console.WriteLine("\nBattle Monsters!");
            
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
            Console.WriteLine("Thank you for playing Battle Monsters.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }


    }
}