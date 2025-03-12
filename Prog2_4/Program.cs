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
            Console.WriteLine("      WELCOME TO PINOY LEAGUES RPG!         ");
            Console.WriteLine("   A TURN-BASED BATTLE EXPERIENCE   ");
            Console.WriteLine("=====================================");
            Console.WriteLine("\nEach player takes turns choosing to \nATTACK or HEAL.");
            Console.WriteLine("Be strategic and outlast your opponent!");
            Console.WriteLine("\nNOTE: Enter your choice carefully \n[invalid inputs will cost you a turn!]");
            Console.WriteLine("=====================================\n");


            Random rng = new Random();
            int plr1Health = 100;
            int plr2Health = 100;
            int healthbar1;
            int healthbar2;
            int turn = 1;
            string abltInput;
            int roundCounter = 1;
            int plr1Atk = 1;
            int plr1Hlt = 1;
            int plr2Atk = 1;
            int plr2Hlt = 1;
            
            

            Console.Write("\nEnter Player 1 Name: ");
            string name1 =  Console.ReadLine();
            Console.Write("\nEnter Player 2 Name: ");
            string name2 = Console.ReadLine();
            while (plr1Health > 0 && plr2Health > 0) 
            {

                if (turn == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Round [{roundCounter}]");
                    healthbar1 = plr1Health / 10;
                    healthbar2 = plr2Health / 10;

                    Console.WriteLine($"{name1}'s HP BAR\t[{plr1Health} HP]");
                    Console.WriteLine("------------------- ");
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
                    for ( int i = 0;i < 10 - healthbar1; i++)
                    {
                        Console.Write("- ");
                    }
                    Console.WriteLine("\n------------------- \n");

                    Console.WriteLine($"{name2}'s HP BAR\t[{plr2Health} HP]");
                    Console.WriteLine("------------------- ");
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
                    Console.WriteLine("\n------------------- \n ");

                    Console.WriteLine($"[{name1}'s Turn]");
                    Console.Write($"Pick an Ability\nType [Attack] or [Heal]: ");
                    abltInput = Console.ReadLine().ToUpper();

                    if (abltInput == "ATTACK")
                    {
                        plr2Health = plr2Health - rng.Next((1 * plr1Atk),(6 * plr1Atk));
                    }

                    else if (abltInput == "HEAL")
                    {
                        plr1Health = plr1Health + rng.Next((1 * plr1Hlt), (5 * plr1Hlt));
                        if (plr1Health >= 100)
                            plr1Health = 100;
                    }
                    else
                        Console.WriteLine("You Lost Your Turn!");

                    turn = 2;

                }
                
                
                if (turn == 2) 
                {
                    Console.Clear();
                    Console.WriteLine($"Round [{roundCounter}]");
                    healthbar1 = plr1Health / 10;
                    healthbar2 = plr2Health / 10;

                    Console.WriteLine($"{name1}'s HP BAR\t[{plr1Health} HP]");
                    Console.WriteLine("------------------- ");
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
                    Console.WriteLine("\n------------------- \n ");

                    Console.WriteLine($"{name2}'s HP BAR\t[{plr2Health} HP]");
                    Console.WriteLine("------------------- ");
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
                    Console.WriteLine("\n------------------- \n");

                    Console.WriteLine($"[{name2}'s Turn]");
                    Console.Write($"Pick an Ability\nType [Attack] or [Heal]: ");
                    abltInput = Console.ReadLine().ToUpper();

                    if (abltInput == "ATTACK")
                    {
                        plr1Health = plr1Health - rng.Next((1 * plr2Atk),(6 * plr2Atk));
                    }

                    else if (abltInput == "HEAL")
                    {
                        plr2Health = plr2Health + rng.Next((1 * plr2Hlt), (5 * plr2Hlt));
                        if (plr2Health >= 100)
                            plr2Health = 100;
                    }
                    else
                        Console.WriteLine("You Lost Your Turn!");

                    turn = 1;
                    roundCounter++;
                }

                if (roundCounter % 4 == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Round[{roundCounter}]\nUPGRADE YOUR ABILITIES\n" +
                        $"Type one [Attack] or [Heal]");
                    Console.Write($"Player 1: ");
                    string upgUI1 = Console.ReadLine().ToUpper();
                    if (upgUI1 == "ATTACK")
                        plr1Atk += 2;
                    else if (upgUI1 == "HEAL")
                        plr1Hlt += 1;

                    Console.Write($"Player 2: ");
                    string upgUI2 = Console.ReadLine().ToUpper();
                    if (upgUI2 == "ATTACK")
                        plr2Atk += 2;
                    else if (upgUI2 == "HEAL")
                        plr2Hlt += 1;
                }

            }
            Console.Clear();
            if (plr2Health > plr1Health)
            {
                Console.WriteLine("\n=====================================");
                Console.WriteLine("        *** CONGRATULATIONS! ***         ");
                Console.WriteLine("=====================================");
                Console.WriteLine($"        >>> {name2} IS THE WINNER! <<<       ");
                Console.WriteLine("=====================================\n");
            }
            else
            {
                Console.WriteLine("\n=====================================");
                Console.WriteLine("         *** CONGRATULATIONS! ***         ");
                Console.WriteLine("=====================================");
                Console.WriteLine($"        >>> {name1} IS THE WINNER! <<<      ");
                Console.WriteLine("=====================================\n");
            }

        }
    }
}
