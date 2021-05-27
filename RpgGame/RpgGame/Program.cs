using System;
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
            int winCount = 0;

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

            while (playerNotDead)
            {
                IFighter attacker, defender;
                attacker = player;
                IFighter enemyFighter = GenerateRandomEnemy();
                defender = enemyFighter;

                while (enemyFighter.Health > 0 && playerNotDead)
                {
                    IFighter temp;

                    Console.WriteLine();
                    Console.WriteLine("---------------------");
                    Console.WriteLine(attacker.Name + " health: " + attacker.Health);
                    Console.WriteLine(defender.Name + " health: " + defender.Health);
                    Console.WriteLine(attacker.Name + " is attacking " + defender.Name);
                    Console.WriteLine("---------------------");

                    defender.Defend(attacker.Attack(defender));

                    if (player.Health <= 0)
                        playerNotDead = false;

                    temp = attacker;
                    attacker = defender;
                    defender = temp;

                }
                if (playerNotDead)
                    winCount++;
            }

            Console.WriteLine("Win Count: " + winCount);
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
