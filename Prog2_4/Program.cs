using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RPG - Turn Based game
            Console.WriteLine("=====================================");
            Console.WriteLine("    WELCOME TO PINOY LEAGUES RPG!      ");
            Console.WriteLine("   A TURN-BASED BATTLE EXPERIENCE   ");
            Console.WriteLine("=====================================");
            Console.WriteLine("\nEach player takes turns choosing to \nATTACK or HEAL.");
            Console.WriteLine("Be strategic and outlast your opponent!");
            Console.WriteLine("\nNOTE: Enter your choice carefully \n[invalid inputs will cost you a turn!]");
            Console.WriteLine("=====================================\n");


            Random rng = new Random();
            int plr1Health = 23;
            int plr2Health = 10;
            int healthbar1;
            int healthbar2;
            int turn = 1;
            string abltInput;
            int roundCounter = 5;
            int plr1Atk = 1;
            int plr1Hlt = 1;
            int plr2Atk = 1;
            int plr2Hlt = 1;
            
            

            Console.Write("\nEnter Player 1 Name: ");
            string name1 =  Console.ReadLine();
            Console.Write("\nEnter Player 2 Name: ");
            string name2 = Console.ReadLine();
            var textColor = Console.ForegroundColor;
            while (plr1Health > 0 && plr2Health > 0) 
            {

                if (turn == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"\t\t    ----- Round [{roundCounter}] -----");
                    healthbar1 = plr1Health / 10;
                    healthbar2 = plr2Health / 10;

                    Console.WriteLine($"{name1}'s HP BAR   [{plr1Health} HP]\t\t\t{name2}'s HP BAR   [{plr2Health} HP]");
                    Console.WriteLine("___________________ \t\t\t___________________ ");
                    for ( int i = 0; i <healthbar1;i++)
                    {
                        if (i < 8)
                            Console.ForegroundColor = ConsoleColor.Green;
                        if (i < 5)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        if (i < 2)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("/ ");
                    }
                    Console.ResetColor();
                    for (int i = 0; i < 10 - healthbar1; i++)
                    {
                        Console.Write("- ");
                    }
                    Console.Write("\t\t\t");
                    for (int i = 0; i < healthbar2; i++)
                    {
                        if (i < 8)
                            Console.ForegroundColor = ConsoleColor.Green;
                        if (i < 5)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        if (i < 2)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("/ ");
                    }
                    Console.ResetColor();
                    for (int i = 0; i < 10 - healthbar2; i++)
                    {
                        Console.Write("- ");
                    }
                    Console.ResetColor();

                    Console.WriteLine("\n-------------------\t\t\t------------------- \n");


                    Console.WriteLine($"\t\t\t[{name1}'s Turn]");
                    Console.Write($"\t\t       Pick an Ability");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n\t\t       [1]");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t   [2]");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n\t\t      ATTACK");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t   HEAL");
                    Console.ResetColor();
                    Console.Write("\n\t\t     Type [1] or [2]: ");
                    abltInput = Console.ReadLine().ToUpper();

                    if (abltInput == "1")
                    {
                        plr2Health = plr2Health - rng.Next((1 * plr1Atk),(6 * plr1Atk));
                    }

                    else if (abltInput == "2")
                    {
                        plr1Health = plr1Health + rng.Next((1 * plr1Hlt), (5 * plr1Hlt));
                        if (plr1Health >= 100)
                            plr1Health = 100;
                    }
                    else
                        Console.WriteLine("\t\t\tYou Lost Your Turn!");

                    turn = 2;
                    if (plr1Health <= 0 || plr2Health <= 0)
                        break;

                }
                
                
                if (turn == 2) 
                {
                    Console.Clear();
                    Console.WriteLine($"\t\t    ----- Round [{roundCounter}] -----");
                    healthbar1 = plr1Health / 10;
                    healthbar2 = plr2Health / 10;

                    Console.WriteLine($"{name1}'s HP BAR   [{plr1Health} HP]\t\t\t{name2}'s HP BAR   [{plr2Health} HP]");
                    Console.WriteLine("___________________ \t\t\t___________________ ");
                    for (int i = 0; i < healthbar1; i++)
                    {
                        if (i < 8)
                            Console.ForegroundColor = ConsoleColor.Green;
                        if (i < 5)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        if (i < 2)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("/ ");
                    }
                    Console.ResetColor();
                    for (int i = 0; i < 10 - healthbar1; i++)
                    {
                        Console.Write("- ");
                    }
                    Console.Write("\t\t\t");
                    for (int i = 0; i < healthbar2; i++)
                    {
                        if (i < 8)
                            Console.ForegroundColor = ConsoleColor.Green;
                        if (i < 5)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        if (i < 2)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("/ ");
                    }
                    Console.ResetColor();
                    for (int i = 0; i < 10 - healthbar2; i++)
                    {
                        Console.Write("- ");
                    }
                    Console.ResetColor();

                    Console.WriteLine("\n-------------------\t\t\t------------------- \n");


                    Console.WriteLine($"\t\t\t[{name2}'s Turn]");
                    Console.Write($"\t\t       Pick an Ability");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n\t\t       [1]");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t   [2]");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n\t\t      ATTACK");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t   HEAL");
                    Console.ResetColor();
                    Console.Write("\n\t\t     Type [1] or [2]: ");
                    abltInput = Console.ReadLine().ToUpper();

                    if (abltInput == "1")
                    {
                        plr1Health = plr1Health - rng.Next((1 * plr2Atk+2),(6 * plr2Atk+2));
                    }

                    else if (abltInput == "2")
                    {
                        plr2Health = plr2Health + rng.Next((1 * plr2Hlt+1), (5 * plr2Hlt+1));
                        if (plr2Health >= 100)
                            plr2Health = 100;
                    }
                    else
                        Console.WriteLine("You Lost Your Turn!");

                    turn = 1;
                    roundCounter++;
                }

                if (roundCounter % 6 == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"UPGRADE TIME\n" +
                        $"[{name1}]'s Stats");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[LVL {(plr1Atk+1)/2}] ATTACK = ");
                    Console.ResetColor();
                    for (int i = 0; i < (plr1Atk+1)/2; i++)
                        Console.Write("| ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n[LVL {plr1Hlt}]  HEAL  = ");
                    Console.ResetColor();
                    for (int i = 0; i < plr1Hlt; i++)
                        Console.Write("| ");

                    Console.Write($"\n[{name1}] Choose an Ability [1]Attack or 2[Heal] : ");
                    string upgUI1 = Console.ReadLine().ToUpper();
                    if (upgUI1 == "1")
                        plr1Atk += 2;
                    else if (upgUI1 == "2")
                        plr1Hlt += 1;

                    Console.WriteLine($"\n" +
                        $"[{name2}]'s Stats");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[LVL {(plr2Atk + 1) / 2}] ATTACK = ");
                    Console.ResetColor();
                    for (int i = 0; i < (plr2Atk + 1) / 2; i++)
                        Console.Write("| ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n[LVL {plr2Hlt}]  HEAL  = ");
                    Console.ResetColor();
                    for (int i = 0; i < plr2Hlt; i++)
                        Console.Write("| ");

                    Console.Write($"\n[{name2}] Choose an Ability [1]Attack or 2[Heal] : ");
                    string upgUI2 = Console.ReadLine().ToUpper();
                    if (upgUI2 == "1")
                        plr2Atk += 2;
                    else if (upgUI2 == "2")
                        plr2Hlt += 1;
                }

            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (plr2Health > plr1Health)
            {
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       *** CONGRATULATIONS! ***         ");
                Console.WriteLine("=====================================");
                Console.WriteLine($"      >>> [{name2}] IS THE WINNER! <<<       ");
                Console.WriteLine("=====================================\n");
            }
            else
            {
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       *** CONGRATULATIONS! ***         ");
                Console.WriteLine("=====================================");
                Console.WriteLine($"      >>> [{name1}] IS THE WINNER! <<<      ");
                Console.WriteLine("=====================================\n");
            }
            Console.ReadKey();

        }
    }
}
