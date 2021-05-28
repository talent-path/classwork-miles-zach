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
        static void Main(string[] args)
        {
            int round = 1;

            bool playerNotDead = true;

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

            IFighter player = ChooseFighter(fighter, playerWeapon, playerArmor, 100, name);

            List<List<IFighter>> board;

            while (playerNotDead)
            {
                board = GenerateBoard(player, round);
                

                
            }

            
        }

        static List<List<IFighter>> GenerateBoard(IFighter player, int round)
        {
            List<List<IFighter>> board = new List<List<IFighter>>();
            int maxEnemies = round;
            for(int i = 0; i < 15; i++)
            {
                List<IFighter> row = new List<IFighter>();
                for(int j = 0; j < 15; j++)
                {
                    if(i == 0 && j == 0)
                    {
                        row.Add(player);
                    }
                    else
                    {
                        IFighter enemy = Rng(maxEnemies);
                        row.Add(enemy);
                        if(enemy != null)
                        {
                            maxEnemies--;
                        }
                    }
                }
                board.Add(row);
            }
            return board;
        }

        static IFighter Rng(int maxEnemies)
        {
            if(maxEnemies > 0)
            {
                Random random = new Random();
                int roll = random.Next(2);
                if(roll == 1)
                {
                    return GenerateRandomEnemy();
                }
            }
            return null;
        }

        static IFighter ChooseFighter(string fighter, IWeapon weapon, IArmor armor, int health, string name)
        {
            if (fighter == "brute")
                return new Brute(health, name, armor, weapon);
            else if (fighter == "ninja")
                return new Ninja(health, name, armor, weapon);
            else
                return new Troll(health, name, armor, weapon);
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
            string[] enemies = {"David Smelser", "Little Finger", "The Hound", "Walter White",
                "Wicked Witch of the West", "Roberto", "Mr. X", "Teemo", "Beebo" };
            string[] fighters = { "brute", "ninja", "troll" };
            string[] weapons = { "crossbow", "fists", "sword" };
            string[] armor = { "helmet", "shield", "shirt" };

            Random random = new Random();

            IWeapon enemyWeapon = ChooseWeapon(weapons[random.Next(0, 3)]);

            IArmor enemyArmor = ChooseArmor(armor[random.Next(0, 3)]);

            IFighter enemyFighter = ChooseFighter(fighters[random.Next(0, 3)], enemyWeapon,
                enemyArmor, 25, enemies[random.Next(0, 9)]);

            return enemyFighter;
        }
    }
}
