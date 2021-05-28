using System;
using System.Collections.Generic;
using RpgGame.Concrete;
using RpgGame.Concrete.Armors;
using RpgGame.Concrete.Weapons;
using RpgGame.Interfaces;

namespace RpgGame
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int round = 1;

            Console.WriteLine("Enter your player name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Choose a fighter type: (Troll/Ninja/Brute) ");
            string fighter = Console.ReadLine().ToLower();

            Console.WriteLine("Choose a weapon: (Crossbow/Fists/Sword)");
            string weapon = Console.ReadLine().ToLower();

            Console.WriteLine("Choose an armor set: (Helmet/Shield/Shirt)");
            string armor = Console.ReadLine().ToLower();

            IWeapon playerWeapon = ChooseWeapon(weapon);

            IArmor playerArmor = ChooseArmor(armor);

            IFighter player = ChooseFighter(fighter, playerWeapon, playerArmor, 100, name, true);

            List<List<IFighter>> board;

            while (player.Health > 0 && round < 223)
            {
                board = GenerateBoard(player, round);
                bool roundFinished = false;
                while (!roundFinished && player.Health > 0)
                {
                    DisplayBoard(board);
                    Console.WriteLine("Press the directional key where you would like to move next.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.DownArrow:
                            board = PlayerMove(board, keyInfo.Key);
                            break;
                        default:
                            Console.WriteLine("Not A Valid Key");
                            break;
                    }

                    if (board[14].IndexOf(player) == 14 && player.Health > 0)
                    {
                        roundFinished = true;
                        round++;
                    }
                }
            }
            Console.WriteLine("You survived " + (round - 1) + " rounds!");
        }

        static List<List<IFighter>> PlayerMove(List<List<IFighter>> board, ConsoleKey key)
        {
            int playerRow = int.MinValue;
            int playerCol = int.MinValue;

            for(int i = 0; i < board.Count; i++)
            {
                for(int j = 0; j < board[i].Count; j++)
                {
                    if(board[i][j] != null && board[i][j].Name != "enemy")
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            bool playerWon = false;
            IFighter player = board[playerRow][playerCol], enemy = null;
            int enemyRow = int.MaxValue, enemyCol = int.MaxValue;
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    if(playerRow > 0)
                    {
                        enemyRow = playerRow - 1;
                        enemyCol = playerCol;
                        enemy = board[enemyRow][enemyCol];
                        playerWon = Battle(player, enemy);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move up from this position!");
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(playerRow < 14)
                    {
                        enemyRow = playerRow + 1;
                        enemyCol = playerCol;
                        enemy = board[enemyRow][enemyCol];
                        playerWon = Battle(player, enemy);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move down from this position!");
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(playerCol < 14)
                    {
                        enemyCol = playerCol + 1;
                        enemyRow = playerRow;
                        enemy = board[enemyRow][enemyCol];
                        playerWon = Battle(player, enemy);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move right from this position!");
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(playerCol > 0)
                    {
                        enemyCol = playerCol - 1;
                        enemyRow = playerRow;
                        enemy = board[enemyRow][enemyCol];
                        playerWon = Battle(player, enemy);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move left from this position!");
                    }
                    break;
                default:
                    Console.WriteLine("Something went very wrong!");
                    break;
            }

            if(playerWon)
            {
                board[enemyRow][enemyCol] = player;
                board[playerRow][playerCol] = null;
            }

            return board;
        }

        static bool Battle(IFighter player, IFighter enemy)
        {
            if(enemy == null)
            {
                return true;
            }
           
            IFighter attacker = player,
                defender = enemy,
                temp;
            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine(attacker.Name + " health: " + attacker.Health);
                Console.WriteLine(defender.Name + " health: " + defender.Health);
                Console.WriteLine(attacker.Name + " is attacking " + defender.Name);
                Console.WriteLine("---------------------");

                defender.Defend(attacker.Attack(defender));

                temp = attacker;
                attacker = defender;
                defender = temp;

                if(player.Health <= 0 && player.HasPotion)
                {
                    player.Health = 100;
                    player.HasPotion = false;
                    Console.WriteLine("Your one and only potion has been used!");
                }

            }

            return player.Health > 0;
        }

        static void DisplayBoard(List<List<IFighter>> board)
        {
            foreach (List<IFighter> row in board)
            {
                //Console.WriteLine("-----------------");
                //Console.Write('|');
                foreach (IFighter space in row)
                {
                    if (space == null)
                    {
                        Console.Write('-');
                    }
                    else if (space.Name == "enemy")
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write('O');
                    }
                }
                //Console.Write('|');
                Console.WriteLine();
            }
        }

        static List<List<IFighter>> GenerateBoard(IFighter player, int round)
        {
            List<List<IFighter>> board = InitializeBoard();
            int maxEnemies = round, col, row;
            board[0][0] = player;
            board[14][14] = null;
            while (maxEnemies > 0)
            {
                col = random.Next(0, 15);
                row = random.Next(0, 15);
                if ((col != 0 && row != 0) && (col != 14 && row != 14))
                {
                    board[row][col] = GenerateRandomEnemy();
                    maxEnemies--;
                }
            }

            return board;
        }

        static List<List<IFighter>> InitializeBoard()
        {
            List<List<IFighter>> board = new List<List<IFighter>>();
            for(int i = 0; i < 15; i++)
            {
                List<IFighter> row = new List<IFighter>();
                for(int j = 0; j < 15; j++)
                {
                    row.Add(null);
                }
                board.Add(row);
            }
            return board;
        }

        static IFighter ChooseFighter(string fighter, IWeapon weapon, IArmor armor, int health, string name, bool hasPotion)
        {
            if (fighter == "brute")
                return new Brute(health, name, armor, weapon, hasPotion);
            else if (fighter == "ninja")
                return new Ninja(health, name, armor, weapon, hasPotion);
            else
                return new Troll(health, name, armor, weapon, hasPotion);
        }

        static IWeapon ChooseWeapon(string weapon)
        {
            if (weapon == "crossbow")
                return new Crossbow();
            else if (weapon == "fists")
                return new Fists();
            else
                return new Sword();
        }

        static IArmor ChooseArmor(string armor)
        {
            if (armor == "helmet")
                return new Helmet();
            else if (armor == "shield")
                return new Shield();
            else
                return new Shirt();
        }

        static IFighter GenerateRandomEnemy()
        {
            string[] fighters = { "brute", "ninja", "troll" };
            string[] weapons = { "crossbow", "fists", "sword" };
            string[] armor = { "helmet", "shield", "shirt" };

            IWeapon enemyWeapon = ChooseWeapon(weapons[random.Next(0, 3)]);

            IArmor enemyArmor = ChooseArmor(armor[random.Next(0, 3)]);

            IFighter enemyFighter = ChooseFighter(fighters[random.Next(0, 3)], enemyWeapon,
                enemyArmor, 25, "enemy", false);

            return enemyFighter;
        }
    }
}
