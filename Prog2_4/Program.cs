using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prog2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    WELCOME TO PINOY LEAGUES RPG!      ");
            Console.WriteLine("   A TURN-BASED BATTLE EXPERIENCE   ");
            Console.ResetColor();
            Console.WriteLine("=====================================");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nEach player takes turns choosing to \nATTACK or HEAL.");
            Console.WriteLine("Be strategic and outlast your opponent!");
            Console.WriteLine("\nNOTE: Enter your choice carefully \n[invalid inputs will cost you a turn!]\n");
            Console.ResetColor();
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
            bool procted1 = false;
            bool procted2 = false;
            int dmg = 0;
            bool crit1 = false;
            bool crit2 = false;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nEnter Player 1 Name: ");
            string name1 =  Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nEnter Player 2 Name: ");
            string name2 = Console.ReadLine();
            Console.ResetColor();
            while (plr1Health > 0 && plr2Health > 0) 
            {

                if (turn == 1)
                {
                    Console.Clear();
                    if (crit2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[{name2}] Did a CRITICAL STRIKE!! [-{dmg}]");
                        Thread.Sleep(10);
                        Console.Beep(3800, 100);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine($"[{name2}] Did a CRITICAL STRIKE!! [-{dmg}]");
                        crit2 = false;
                    }
                    if (procted1 == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Beep(5100, 70);
                        Console.WriteLine($"[{name1}] REFLECTED THE DAMAGE!!");
                    }
                    procted1 = false;


                    Console.ResetColor();
                    
                    Console.WriteLine($"\t\t    ----- Round [{roundCounter}] -----");
                    healthbar1 = plr1Health / 10;
                    healthbar2 = plr2Health / 10;

                    Console.WriteLine($"{name1}'s HP BAR   [{plr1Health} HP]    \t      {name2}'s HP BAR   [{plr2Health} HP]");
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

                    Console.WriteLine("\n-------------------\t\t\t-------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Console.ResetColor();
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
                        int damage = rng.Next((plr1Atk+1+(plr1Atk/2)), (6+plr1Atk*2 + (plr1Atk / 2)));
                        if (plr2Hlt >= 4)
                        {
                            int plr2Ref = plr2Hlt / 4;
                            if (plr2Hlt >= 8)
                            {
                                plr2Ref = 3;
                            }
                            int chance = rng.Next(plr2Ref, 5);
                            if (chance == 4)
                            {
                                plr1Health = plr1Health - (damage-(plr1Hlt-1));
                                plr2Health = plr2Health + (rng.Next(2, plr2Atk+1));
                                procted2 = true;
                            }
                        }
                        plr2Health = plr2Health - damage;
                        if (damage >= 10)
                            crit1 = true;
                        dmg = damage;
                    }

                    else if (abltInput == "2")
                    {
                        plr1Health = plr1Health + rng.Next((plr1Hlt), (5+plr1Hlt*2));
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
                    if (crit1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[{name1}] Did a CRITICAL STRIKE!! [-{dmg}]");
                        Thread.Sleep(10);
                        Console.Beep(3800, 100);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine($"[{name1}] Did a CRITICAL STRIKE!! [-{dmg}]");
                        crit1 = false;
                    }
                    if (procted2 == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Beep(5100, 70);
                        Console.WriteLine($"[{name2}] REFLECTED THE DAMAGE!!");
                    }
                    procted2 = false;
                    Console.ResetColor();
                    Console.WriteLine($"\t\t    ----- Round [{roundCounter}] -----");
                    healthbar1 = plr1Health / 10;
                    healthbar2 = plr2Health / 10;

                    Console.WriteLine($"{name1}'s HP BAR   [{plr1Health} HP]    \t      {name2}'s HP BAR   [{plr2Health} HP]");
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

                    Console.WriteLine("\n-------------------\t\t\t-------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                    Console.ResetColor();
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
                        int damage = rng.Next((plr2Atk+1+(plr2Atk/2)), (6+plr2Atk*2 + (plr2Atk / 2)));
                        if (plr1Hlt >= 4)
                        {
                            int plr1Ref = plr1Hlt / 4;
                            if (plr1Hlt >= 8)
                            {
                                plr1Ref = 3;
                            }
                            int chance = rng.Next(plr1Ref, 5);
                            if (chance == 4) 
                            {
                                plr2Health = plr2Health - (damage-plr2Hlt);
                                plr2Health = plr2Health + (rng.Next(2, plr1Atk+1));
                                procted1 = true;
                            }
                        }
                        plr1Health = plr1Health - damage;
                        if (damage >= 10)
                            crit2 = true;
                        dmg = damage;
                    }

                    else if (abltInput == "2")
                    {
                        plr2Health = plr2Health + rng.Next((plr2Hlt), (5+plr2Hlt*2));
                        if (plr2Health >= 100)
                            plr2Health = 100;
                    }
                    else
                        Console.WriteLine("You Lost Your Turn!");

                    turn = 1;
                    roundCounter++;
                }
                bool announce = false;
                if (roundCounter % 4 == 0)
                {
                    Console.WriteLine("UPGRADE ABILITIES Tap Enter to Proceed.");
                    Console.ReadKey();
                    Console.Clear();
                    for (int u = 1; u < 4;u++)
                    {
                        if (announce)
                        {
                            if (plr1Hlt >= 4 && u == 2)
                            {
                                if (plr1Hlt == 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"[{name1}] Has Unlocked 'REFLECT I'");
                                    Thread.Sleep(10);
                                    Console.Beep(600, 200);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine($"[{name1}] Has Unlocked 'REFLECT I'");
                                }
                                else if (plr1Hlt == 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"[{name1}] Has Unlocked 'REFLECT II'");
                                    Thread.Sleep(10);
                                    Console.Beep(600, 200);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine($"[{name1}] Has Unlocked 'REFLECT II'");
                                }
                                Console.ResetColor();
                            }
                            if (plr2Hlt >= 4 && u == 3)
                            {
                                if (plr2Hlt == 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"[{name2}] Has Unlocked 'REFLECT I'");
                                    Thread.Sleep(10);
                                    Console.Beep(600, 200);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine($"[{name2}] Has Unlocked 'REFLECT I'");
                                }
                                else if (plr2Hlt == 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"[{name2}] Has Unlocked 'REFLECT II'");
                                    Thread.Sleep(10);
                                    Console.Beep(1000, 200);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine($"[{name2}] Has Unlocked 'REFLECT II'");
                                }
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine($"UPGRADE TIME\n" +
                        $"[{name1}]'s Stats");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"-+-+-+-+-+-+-+-+-");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[LVL {plr1Atk}] ATTACK = ");
                        Console.ResetColor();
                        for (int i = 0; i < (plr1Atk); i++)
                            Console.Write("| ");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n[LVL {plr1Hlt}]  HEAL  = ");
                        Console.ResetColor();
                        for (int i = 0; i < plr1Hlt; i++)
                            Console.Write("| ");

                        Console.WriteLine($"\n" +
                       $"[{name2}]'s Stats");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[LVL {plr2Atk}] ATTACK = ");
                        Console.ResetColor();
                        for (int i = 0; i < (plr2Atk); i++)
                            Console.Write("| ");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n[LVL {plr2Hlt}]  HEAL  = ");
                        Console.ResetColor();
                        for (int i = 0; i < plr2Hlt; i++)
                            Console.Write("| ");
                        if (u == 1)
                        {
                            Console.Write($"\n[{name1}] Choose an Ability [1]Attack or [2] Heal : ");
                            string upgUI1 = Console.ReadLine().ToUpper();
                            if (upgUI1 == "1")
                                plr1Atk += 1;
                            else if (upgUI1 == "2")
                            {
                                plr1Hlt += 1;
                                if (plr1Hlt == 4 || plr1Hlt == 8)
                                    announce = true;
                            }
                            Console.Clear();
                        }
                        else if (u == 2)
                        {
                            Console.Write($"\n[{name2}] Choose an Ability [1] Attack or [2] Heal : ");
                            string upgUI2 = Console.ReadLine().ToUpper();
                            if (upgUI2 == "1")
                                plr2Atk += 1;
                            else if (upgUI2 == "2")
                            {
                                plr2Hlt += 1;
                                if (plr2Hlt == 4 || plr2Hlt == 8)
                                    announce = true;
                            }
                            Console.Clear();
                        }
                    }
                    Console.WriteLine("\nClick Enter to Procceed...");
                    Console.ReadKey();
                }

            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (plr2Health <=00 && plr1Health <=00)
            {
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       ***     A DRAW!!     ***         ");
                Console.WriteLine("=====================================");

            }
            else if (plr2Health > plr1Health)
            {
                Console.WriteLine("\n=====================================");
                Console.WriteLine("       *** CONGRATULATIONS! ***         ");
                Console.WriteLine("=====================================");
                Console.WriteLine($"      >>> [{name2}] IS THE WINNER! <<<      ");
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
